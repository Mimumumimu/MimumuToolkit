using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimumuReminderDialog.Database.Entities
{
    public class ReminderStateDataEntity
    {
        public const string JsonFileName = "ReminderStateData.json";

        public const string TableName = "D_REMINDER_STATE";
        public class Field
        {
            public const string SEQ = "REMINDER_STATE_SEQ";
            public const string CREATE = "REMINDER_STATE_CREATE";
            public const string CREATE_USER = "REMINDER_STATE_CREATE_USER";
            public const string UPDATE = "REMINDER_STATE_UPDATE";
            public const string UPDATE_USER = "REMINDER_STATE_UPDATE_USER";
            public const string DELETE = "REMINDER_STATE_DELETE";
            public const string GROUP_NO = "REMINDER_STATE_GROUP_NO";
            public const string NO = "REMINDER_STATE_NO";
            public const string USER_NO = "REMINDER_STATE_USER_NO";
            public const string BASE_NO = "REMINDER_STATE_BASE_NO";
            public const string DATE = "REMINDER_STATE_DATE";
            public const string VALUE = "REMINDER_STATE_VALUE";
        }

        public int Seq { get; set; }
        public int GroupNo { get; set; }
        public int No { get; set; }
        public int UserNo { get; set; }
        public int BaseNo { get; set; }
        public int Date { get; set; }
        public int Value { get; set; }

        public ReminderStateDataEntity()
        {
            //CreateUser = MimumuToolkit.MimumuToolkitManager.UserNo;
            //UpdateUser = MimumuToolkit.MimumuToolkitManager.UserNo;
            GroupNo = MimumuToolkit.MimumuToolkitManager.GroupNo;
            UserNo = MimumuToolkit.MimumuToolkitManager.UserNo;
        }
    }
}
