using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimumuReminderDialog.Database.Entities
{
    public class ReminderCheckDataEntity
    {
        public const string JsonFileName = "ReminderCheckData.json";

        public const string TableName = "D_REMINDER_CHECK";
        public class Field
        {
            public const string SEQ = "REMINDER_CHECK_SEQ";
            public const string CREATE_USER = "REMINDER_CHECK_CREATE_USER";
            public const string UPDATE = "REMINDER_CHECK_UPDATE";
            public const string UPDATE_USER = "REMINDER_CHECK_UPDATE_USER";
            public const string DELETE = "REMINDER_CHECK_DELETE";
            public const string NO = "REMINDER_CHECK_NO";
            public const string USER_NO = "REMINDER_CHECK_USER_NO";
            public const string BASE_NO = "REMINDER_CHECK_BASE_NO";
            public const string DATE = "REMINDER_CHECK_DATE";
            public const string STATE = "REMINDER_CHECK_STATE";
        }

        public int Seq { get; set; }
        public int No { get; set; }
        public int UserNo { get; set; }
        public int BaseNo { get; set; }
        public int Date { get; set; }
        public int State { get; set; }

        public ReminderCheckDataEntity()
        {
        }
    }
}
