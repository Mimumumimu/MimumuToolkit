namespace MimumuToolkit.Constants
{
    public class CommonConstants
    {

        internal const int DefaultGroupNo = 1;
        internal const int DefaultUserNo = 1;

        internal static class AppConfigKeys
        {
            internal const string SDKPrefix = "MimumuToolkit_";

            internal const string DarkModeEnabledKey = SDKPrefix + "IsDarkModeEnabled";
            internal const string NotificationSoundEnabledKey = SDKPrefix + "IsNotificationSoundEnabled";
            internal const string NotificationFlashEnabledKey = SDKPrefix + "IsNotificationFlashEnabled";
            internal const string LocationXKeyFormat = SDKPrefix + "{0}_LocationX";
            internal const string LocationYKeyFormat = SDKPrefix + "{0}_LocationY";
        }

        /// <summary>
        /// 曜日を表すフラグのセットです。
        /// </summary>
        /// <example>
        /// [複数の曜日を組み合わせる(月曜日と水曜日)]
        /// DayOfWeekFlags mondayAndWednesday = DayOfWeekFlags.Monday | DayOfWeekFlags.Wednesday;
        /// 
        /// [曜日が含まれているか確認する]
        ///  bool isMondayIncluded = (mondayAndWednesday & DayOfWeekFlags.Monday) == DayOfWeekFlags.Monday; // true
        ///  bool isTuesdayIncluded = (mondayAndWednesday & DayOfWeekFlags.Tuesday) == DayOfWeekFlags.Tuesday; // false
        /// </example>
        [Flags]
        public enum DayOfWeekFlags
        {
            None = 0,
            Monday = 1 << 0,
            Tuesday = 1 << 1,
            Wednesday = 1 << 2,
            Thursday = 1 << 3,
            Friday = 1 << 4,
            Saturday = 1 << 5,
            Sunday = 1 << 6,
            All = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday
        }
    }
}
