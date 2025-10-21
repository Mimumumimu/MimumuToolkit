namespace MimumuToolkit.Utilities
{
    public class ConvUtil
    {
        /// <summary>
        /// オブジェクトを整数に変換
        /// </summary>
        /// <param name="obj">変換するオブジェクト</param>
        /// <returns>変換された整数。変換できない場合は0を返します</returns>
        public static int ToInt(object obj, int defaultValue = 0)
        {
            return int.TryParse(obj?.ToString(), out var result) ? result : defaultValue;
        }

        /// <summary>
        /// オブジェクトを文字列に変換
        /// </summary>
        /// <param name="obj">変換するオブジェクト</param>
        /// <returns>変換された文字列 nullの場合は空文字列を返します</returns>
        public static string ToString(object obj)
        {
            return obj?.ToString() ?? string.Empty;
        }

        public static bool ToBool(object obj, bool defaultValue = false)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            if (obj is bool b)
            {
                return b;
            }
            if (obj is int i)
            {
                // 0以外はtrueとみなす
                return (i != 0);
            }
            if (obj is string s)
            {
                return s.Equals("true", StringComparison.OrdinalIgnoreCase) || s == "1";
            }
            return defaultValue;
        }

        /// <summary>
        /// DateTimeオブジェクトをYYYYMMDD形式の整数に変換
        /// </summary>
        /// <param name="dt">変換するDateTimeオブジェクト</param>
        /// <returns>変換された整数</returns>
        public static int DatetimeToIntDate(DateTime dt)
        {
            return ToInt(dt.ToString("yyyyMMdd"));
        }
        public static DateTime IntDateToDatetime(int intDate)
        {
            var strDate = intDate.ToString("D8");
            if (strDate.Length != 8)
            {
                throw new ArgumentException("Invalid date format", nameof(intDate));
            }
            int year = ToInt(strDate.Substring(0, 4));
            int month = ToInt(strDate.Substring(4, 2));
            int day = ToInt(strDate.Substring(6, 2));
            return new DateTime(year, month, day);
        }

        /// <summary>
        /// DateTimeオブジェクトをHHmm形式の整数に変換
        /// </summary>
        /// <param name="dt">変換するDateTimeオブジェクト</param>
        /// <returns>変換された整数</returns>
        public static int DatetimeToIntTime(DateTime dt)
        {
            return ToInt(dt.ToString("HHmm"));
        }

        public static DateTime IntTimeToDatetime(int intTime)
        {
            var strTime = intTime.ToString("D4");
            if (strTime.Length != 4)
            {
                throw new ArgumentException("Invalid time format", nameof(intTime));
            }
            int hour = ToInt(strTime.Substring(0, 2));
            int minute = ToInt(strTime.Substring(2, 2));
            DateTime now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, hour, minute, 0);
        }

        public static string DayOfWeekToString(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Sunday => "日",
                DayOfWeek.Monday => "月",
                DayOfWeek.Tuesday => "火",
                DayOfWeek.Wednesday => "水",
                DayOfWeek.Thursday => "木",
                DayOfWeek.Friday => "金",
                DayOfWeek.Saturday => "土",
                _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null)
            };
        }
    }
}
