using MimumuToolkit.Constants;
using MimumuToolkit.Utilities;

namespace MimumuToolkit
{
    public sealed class MimumuSDKManager
    {
        //private static readonly Lazy<MimumuSDKManager> lazy = new(() => new MimumuSDKManager());

        //public static MimumuSDKManager Instance { get { return lazy.Value; } }

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
    }
}