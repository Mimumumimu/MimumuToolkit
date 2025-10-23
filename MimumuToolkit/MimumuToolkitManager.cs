using MimumuToolkit.Constants;
using MimumuToolkit.Dialogs;
using MimumuToolkit.Entities;
using MimumuToolkit.Utilities;

namespace MimumuToolkit
{
    public sealed class MimumuToolkitManager
    {
        //private static readonly Lazy<MimumuSDKManager> lazy = new(() => new MimumuSDKManager());

        //public static MimumuSDKManager Instance { get { return lazy.Value; } }


        private static NotificationDialog? m_notificationDialog = null;

        public static void ShowNotification(string title, string url = "", string remarks = "")
        {
            LinkEntity link = new(title, url, remarks);
            ShowNotification([link]);
        }

        public static void ShowNotification(List<LinkEntity> links)
        {
            if (m_notificationDialog == null)
            {
                m_notificationDialog = new NotificationDialog();
                m_notificationDialog.Opacity = 0;
                m_notificationDialog.Show();
                m_notificationDialog.Visible = false;
                m_notificationDialog.Opacity = 1;
            }
            m_notificationDialog.ShowNotification(links);
        }


        private static bool? m_isDarkModeEnabled;
        public static bool IsDarkModeEnabled
        {
            get
            {
                if (m_isDarkModeEnabled == null)
                {
                    if (CommonUtil.ContainsConfigurationSettingKey(CommonConstants.AppConfigKeys.DarkModeEnabledKey) == true)
                    {
                        m_isDarkModeEnabled = CommonUtil.GetBoolAppSetting(CommonConstants.AppConfigKeys.DarkModeEnabledKey);
                    }
                    else
                    {
                        m_isDarkModeEnabled = false;
                        CommonUtil.SetSetting(CommonConstants.AppConfigKeys.DarkModeEnabledKey, m_isDarkModeEnabled.Value.ToString());
                    }
                }
                return m_isDarkModeEnabled.Value;
            }
            set
            {
                m_isDarkModeEnabled = value;
                if (m_isDarkModeEnabled == null)
                {
                    m_isDarkModeEnabled = false;
                }
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
                    if (CommonUtil.ContainsConfigurationSettingKey(CommonConstants.AppConfigKeys.NotificationSoundEnabledKey) == true)
                    {
                        m_isNotificationSoundEnabled = CommonUtil.GetBoolAppSetting(CommonConstants.AppConfigKeys.NotificationSoundEnabledKey);
                    }
                    else
                    {
                        m_isNotificationSoundEnabled = true;
                        CommonUtil.SetSetting(CommonConstants.AppConfigKeys.NotificationSoundEnabledKey, m_isNotificationSoundEnabled.Value.ToString());
                    }
                }
                return m_isNotificationSoundEnabled.Value;
            }
            set
            {
                m_isNotificationSoundEnabled = value;
                if (m_isNotificationSoundEnabled == null)
                {
                    m_isNotificationSoundEnabled = true;
                }
                CommonUtil.SetSetting(CommonConstants.AppConfigKeys.NotificationSoundEnabledKey, m_isNotificationSoundEnabled.Value.ToString());
            }
        }

        #region タイマー関連

        private static SynchronizationContext? m_uiContext;
        private static PeriodicTimer? m_periodicTimer;
        private static readonly List<TimerEntity> m_timers = [];

        public static void SetTimer(int intervalseconds, Action action)
        {
            if (m_uiContext == null)
            {
                StartPeriodicTimer();
            }

            var timer = m_timers.FirstOrDefault(t => t.ElapsedAction == action);
            if (timer == null)
            {
                timer = new TimerEntity(intervalseconds, action);
                m_timers.Add(timer);
            }
            else
            {
                // 既存のタイマーがある場合はカウンターをリセット
                timer.LastElapsedTime = DateTime.MinValue;
                return;
            }
        }

        /// <summary>
        /// タイマーからアクションを削除します。
        /// </summary>
        /// <param name="action">削除するアクション</param>
        public static void RemoveTimer(Action action)
        {
            var timer = m_timers.FirstOrDefault(t => t.ElapsedAction == action);
            if (timer == null)
            {
                return;
            }

            timer.ElapsedAction = null;
            m_timers.Remove(timer);

            // タイマーが空になったらタイマーを停止する
            if (m_timers.Count == 0)
            {
                StopAllTimer();
            }
        }

        public static void StopAllTimer()
        {
            foreach (var timer in m_timers)
            {
                timer.ElapsedAction = null;
            }
            m_timers.Clear();
            if (m_periodicTimer != null)
            {
                m_periodicTimer.Dispose();
                m_periodicTimer = null;
            }
            m_uiContext = null;
        }

        private static async void StartPeriodicTimer()
        {
            m_uiContext = SynchronizationContext.Current;
            if (m_periodicTimer != null)
            {
                m_periodicTimer.Dispose();
                m_periodicTimer = null;
            }
            m_periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            while (await m_periodicTimer.WaitForNextTickAsync())
            {
                DateTime now = DateTime.Now;
                foreach (var timer in m_timers)
                {
                    // 時間が閾値を超えたかチェック
                    if ((now - timer.LastElapsedTime).TotalSeconds >= timer.IntervalSeconds)
                    {
                        // 経過時間を更新
                        timer.LastElapsedTime = now;

                        // UIスレッドでアクションを実行
                        m_uiContext?.Post(_ =>
                        {
                            timer.ElapsedAction?.Invoke();
                        }, null);
                    }
                }
            }
        }

        #endregion


    }
}