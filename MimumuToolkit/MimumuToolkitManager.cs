using MimumuToolkit.Constants;
using MimumuToolkit.Dialogs;
using MimumuToolkit.Entities;
using MimumuToolkit.Utilities;

namespace MimumuToolkit
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// �p������Ӗ����Ȃ��̂ŁAsealed �Ŗ����I�Ɂu����͌p�������ׂ��ł͂Ȃ��v�Ɛ錾���Ă��܂�
    /// </remarks>
    public sealed class MimumuToolkitManager
    {
        public static int GroupNo { get; set; } = CommonConstants.DefaultGroupNo;

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
                    m_isDarkModeEnabled = GetSetting(CommonConstants.AppConfigKeys.DarkModeEnabledKey, false);
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
                    m_isNotificationSoundEnabled = GetSetting(CommonConstants.AppConfigKeys.NotificationSoundEnabledKey, true);
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
                if (m_isNotificationFlashEnabled == null)
                {
                    m_isNotificationFlashEnabled = true;
                }
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

        #region �^�C�}�[�֘A

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
                // �����̃^�C�}�[������ꍇ�̓J�E���^�[�����Z�b�g
                timer.LastElapsedTime = DateTime.MinValue;
                return;
            }
        }

        /// <summary>
        /// �^�C�}�[����A�N�V�������폜���܂��B
        /// </summary>
        /// <param name="action">�폜����A�N�V����</param>
        public static void RemoveTimer(Action action)
        {
            var timer = m_timers.FirstOrDefault(t => t.ElapsedAction == action);
            if (timer == null)
            {
                return;
            }

            timer.ElapsedAction = null;
            m_timers.Remove(timer);

            // �^�C�}�[����ɂȂ�����^�C�}�[���~����
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
                    // ���Ԃ�臒l�𒴂������`�F�b�N
                    if ((now - timer.LastElapsedTime).TotalSeconds >= timer.IntervalSeconds)
                    {
                        // �o�ߎ��Ԃ��X�V
                        timer.LastElapsedTime = now;

                        // UI�X���b�h�ŃA�N�V���������s
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