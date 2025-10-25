using MimumuToolkit.Constants;
using System.Text;
using System.Text.Json.Serialization;

namespace MimumuReminderDialog.Database.Entities
{
    public class ReminderDataEntity
    {
        public const string JsonFileName = "ReminderData.json";

        public const string TableName = "D_REMINDER";
        public class Field
        {
            public const string SEQ = "REMINDER_SEQ";
            public const string CREATE_USER = "REMINDER_CREATE_USER";
            public const string UPDATE = "REMINDER_UPDATE";
            public const string UPDATE_USER = "REMINDER_UPDATE_USER";
            public const string DELETE = "REMINDER_DELETE";
            public const string GROUP_NO = "REMINDER_GROUP_NO";
            public const string NO = "REMINDER_NO";
            public const string USER_NO = "REMINDER_USER_NO";
            public const string DATE = "REMINDER_DATE";
            public const string DAYOFWEEK = "REMINDER_DAYSOFWEEK";
            public const string TIME = "REMINDER_TIME";
            public const string SEND_NTFY_NO = "REMINDER_SEND_NTFY_NO";
            public const string SEND_DISCORD_NO = "REMINDER_SEND_DISCORD_NO";
            public const string SPEAK = "REMINDER_SPEAK";

            public const string SUBJECT = "REMINDER_SUBJECT";
            public const string REMARKS = "REMINDER_COMMENT";
            public const string LINK = "REMINDER_LINK";
        }

        public int Seq { get; set; }
        public int CreateUser { get; set; }
        public bool Delete { get; set; }
        public int GroupNo { get; set; }
        public int No { get; set; }
        public int UserNo { get; set; }
        public int Date { get; set; } = 99999999;
        public int Time { get; set; }
        public int DaysOfWeek { get; set; } = (int)CommonConstants.DayOfWeekFlags.None;
        public int SendNtfyNo { get; set; }
        public int SendDiscordNo { get; set; }
        public bool IsSpeak { get; set; }

        public string Subject { get; set; }
        public string Remarks { get; set; }
        public string Link { get; set; }

        public ReminderDataEntity()
        {
            Subject = string.Empty;
            Remarks = string.Empty;
            Link = string.Empty;
            GroupNo = MimumuToolkit.MimumuToolkitManager.GroupNo;
        }

        [JsonIgnore]
        public string DisplayData
        {
            get
            {
                var result = new StringBuilder();

                result.AppendFormat("{0:00}:{1:00} ", (Time / 100), (Time % 100));
                if (string.IsNullOrWhiteSpace(Link) == false)
                {
                    result.Append("(L)");
                }
                result.Append(Subject);

                return result.ToString();
            }
        }

        public CommonConstants.DayOfWeekFlags GetDaysOfWeek
        {
            get
            {
                // 有効範囲チェック
                if (DaysOfWeek < 0 || DaysOfWeek > (int)CommonConstants.DayOfWeekFlags.All)
                {
                    // 無効値はNoneで返す
                    return CommonConstants.DayOfWeekFlags.None;
                }

                return (CommonConstants.DayOfWeekFlags)DaysOfWeek;
            }
        }
    }
}
