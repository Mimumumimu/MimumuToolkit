using MimumuToolkit.Constants;
using MimumuToolkit.Dialogs;
using MimumuToolkit.Utilities;

namespace MimumuToolkit
{
    public sealed class MimumuToolkitManager
    {
        //private static readonly Lazy<MimumuSDKManager> lazy = new(() => new MimumuSDKManager());

        //public static MimumuSDKManager Instance { get { return lazy.Value; } }

        private static bool? m_isDarkModeEnabled;

        private static NotificationDialog? m_notificationDialog = null;

        public static void ShowNotification(string title, string message)
        {
            if (m_notificationDialog == null)
            {
                m_notificationDialog = new NotificationDialog();
                m_notificationDialog.Show();
                return;
            }
            //dlg.Title = title;
            //dlg.Message = message;
            m_notificationDialog.Visible = true;
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