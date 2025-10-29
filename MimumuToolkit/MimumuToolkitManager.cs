using MimumuToolkit.Constants;
using MimumuToolkit.Dialogs;
using MimumuToolkit.Entities;
using MimumuToolkit.Utilities;
using System.Linq;
using System.Threading;

namespace MimumuToolkit
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 継承する意味がないので、sealed で明示的に「これは継承されるべきではない」と宣言しています
    /// </remarks>
    public sealed class MimumuToolkitManager
    {
        public static int GroupNo { get; set; } = CommonConstants.DefaultGroupNo;
        public static int UserNo { get; set; } = CommonConstants.DefaultUserNo;

        private static NotificationDialog? m_notificationDialog = null;

        public static void ShowNotification(string title, string url = "", string remarks = "")
        {
            LinkEntity link = new(title, url, remarks);
            ShowNotification([link]);
        }

        public static void ShowNotification(List<LinkEntity> links, Action? closeAction = null)
        {
            if (m_notificationDialog == null)
            {
                m_notificationDialog = new NotificationDialog();
            }
            m_notificationDialog.ShowNotification(links, closeAction);
        }


        private static bool? m_isDarkModeEnabled;
        public static bool IsDarkModeEnabled
        {
            get
            {
                if (m_isDarkModeEnabled == null)
                {
                    m_isDarkModeEnabled = GetSetting(CommonConstants.AppConfigKeys.DarkModeEnabledKey, false);
                }
                return m_isDarkModeEnabled.Value;
            }
            set
            {
                m_isDarkModeEnabled = value;
                CommonUtil.SetSetting(CommonConstants.AppConfigKeys.DarkModeEnabledKey, m_isDarkModeEnabled.Value.ToString());
            }
        }

        private static bool? m_isNotificationSoundEnabled;
        public static bool IsNotificationSoundEnabled
        {
            get
            {
                if (m_isNotificationSoundEnabled == null)
                {
                    m_isNotificationSoundEnabled = GetSetting(CommonConstants.AppConfigKeys.NotificationSoundEnabledKey, true);
                }
                return m_isNotificationSoundEnabled.Value;
            }
            set
            {
                m_isNotificationSoundEnabled = value;
                CommonUtil.SetSetting(CommonConstants.AppConfigKeys.NotificationSoundEnabledKey, m_isNotificationSoundEnabled.Value.ToString());
            }
        }

        private static bool? m_isNotificationFlashEnabled;
        public static bool IsNotificationFlashEnabled
        {
            get
            {
                if (m_isNotificationFlashEnabled == null)
                {
                    m_isNotificationFlashEnabled = GetSetting(CommonConstants.AppConfigKeys.NotificationFlashEnabledKey, true);
                }
                return m_isNotificationFlashEnabled.Value;
            }
            set
            {
                m_isNotificationFlashEnabled = value;
                CommonUtil.SetSetting(CommonConstants.AppConfigKeys.NotificationFlashEnabledKey, m_isNotificationFlashEnabled.Value.ToString());
            }
        }

        private static T GetSetting<T>(string key, T defaultValue)
        {
            string? stringValue;
            if (CommonUtil.ContainsConfigurationSettingKey(key))
            {
                stringValue = CommonUtil.GetAppSetting(key);
                if (stringValue == null)
                {
                    CommonUtil.SetSetting(key, defaultValue!.ToString() ?? string.Empty);
                    return defaultValue;
                }
            }
            else
            {
                CommonUtil.SetSetting(key, defaultValue!.ToString() ?? string.Empty);
                return defaultValue;
            }

            try
            {
                return (T)Convert.ChangeType(stringValue, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }

        #region タイマー関連

        private static SynchronizationContext? m_uiContext;
        private static PeriodicTimer? m_periodicTimer;
        private static CancellationTokenSource? m_cancellationTokenSource;
        private static Task? m_timerTask; 

        private static readonly List<TimerEntity> m_timers = [];
        private static readonly List<Action> m_dailyActions = [];

        public static void SetTimer(int intervalseconds, Action action, bool executeFirst = true)
        {
            if (m_uiContext == null)
            {
                StartPeriodicTimer();
            }

            var timer = m_timers.FirstOrDefault(t => t.ElapsedAction == action);
            if (timer == null)
            {
                timer = new TimerEntity(intervalseconds, action);
                if (executeFirst == false)
                {
                    timer.LastElapsedTime = DateTime.Now.AddSeconds(intervalseconds);
                }
                m_timers.Add(timer);
            }
            else
            {
                timer.LastElapsedTime = DateTime.MinValue;
            }
        }

        public static void SetDailyTimer(Action action)
        {
            if (m_uiContext == null)
            {
                StartPeriodicTimer();
            }

            if (!m_dailyActions.Contains(action))
            {
                m_dailyActions.Add(action);
            }
        }


        public static void RemoveTimer(Action action)
        {
            if (m_dailyActions.Contains(action))
            {
                m_dailyActions.Remove(action);
            }
            var timer = m_timers.FirstOrDefault(t => t.ElapsedAction == action);
            if (timer != null)
            {
                timer.ElapsedAction = null;
                m_timers.Remove(timer);
            }

            if (m_timers.Count == 0 && m_dailyActions.Count == 0)
            {
                StopAllTimer();
            }
        }

        /// <summary>
        /// すべてのタイマーを停止し、リソースを完全に解放します。
        /// </summary>
        public static void StopAllTimer()
        {
            foreach (var timer in m_timers)
            {
                timer.ElapsedAction = null;
            }
            m_timers.Clear();
            m_dailyActions.Clear();

            if (m_cancellationTokenSource != null)
            {
                try
                {
                    if (!m_cancellationTokenSource.IsCancellationRequested)
                    {
                        m_cancellationTokenSource.Cancel();
                    }
                }
                finally
                {
                    m_cancellationTokenSource.Dispose();
                    m_cancellationTokenSource = null;
                }
            }

            // PeriodicTimer を破棄（これが WaitForNextTickAsync を終了させる）
            if (m_periodicTimer != null)
            {
                m_periodicTimer.Dispose();
                m_periodicTimer = null;
            }

            m_uiContext = null;
        }

        /// <summary>
        /// 定期的にアクションを実行するタイマーループを開始します。
        /// </summary>
        private static void StartPeriodicTimer()  // ✅ async void ではなく fire-and-forget
        {
            m_uiContext = SynchronizationContext.Current;

            // 古いリソースを確実にクリーンアップ
            CleanupTimerResources();

            // 新しいリソースを作成
            m_periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(5));
            m_cancellationTokenSource = new CancellationTokenSource();

            // Task を保持して追跡可能に
            m_timerTask = RunTimerLoopAsync();
        }

        /// <summary>
        /// タイマーループを実行します（async Task版）
        /// </summary>
        private static async Task RunTimerLoopAsync()
        {
            try
            {
                DateTime lastDate = DateTime.Now.Date;
                while (await m_periodicTimer!.WaitForNextTickAsync(m_cancellationTokenSource!.Token))
                {
                    DateTime now = DateTime.Now;

                    // 日付が変わったかチェック
                    if (now.Date > lastDate)
                    {
                        lastDate = now.Date;

                        foreach (var action in m_dailyActions)
                        {
                            if (action != null)
                            {
                                m_uiContext?.Post(_ =>
                                {
                                    try
                                    {
                                        action.Invoke();
                                    }
                                    catch
                                    {
                                        // アクション内の例外は無視
                                    }
                                }, null);
                            }
                        }
                    }

                    // 各タイマーをチェック
                    for (int i = m_timers.Count - 1; i >= 0; i--)
                    {
                        var timer = m_timers[i];

                        if (timer?.ElapsedAction == null)
                        {
                            continue;
                        }

                        if ((now - timer.LastElapsedTime).TotalSeconds >= timer.IntervalSeconds)
                        {
                            timer.LastElapsedTime = now;

                            m_uiContext?.Post(_ =>
                            {
                                try
                                {
                                    timer.ElapsedAction?.Invoke();
                                }
                                catch
                                {
                                    // アクション内の例外は無視
                                }
                            }, null);
                        }
                    }

                    if (m_timers.Count == 0 && m_dailyActions.Count == 0)
                    {
                        break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // 正常なキャンセル
            }
            finally
            {
                CleanupTimerResources();
                m_uiContext = null;
                m_timerTask = null;
            }
        }

        private static void CleanupTimerResources()
        {
            if (m_periodicTimer != null)
            {
                m_periodicTimer.Dispose();
                m_periodicTimer = null;
            }

            if (m_cancellationTokenSource != null)
            {
                try
                {
                    if (!m_cancellationTokenSource.IsCancellationRequested)
                    {
                        m_cancellationTokenSource.Cancel();
                    }
                }
                finally
                {
                    m_cancellationTokenSource.Dispose();
                    m_cancellationTokenSource = null;
                }
            }
        }

        #endregion
    }
}