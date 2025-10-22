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

        private static bool? m_isDarkModeEnabled;

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
    }
}