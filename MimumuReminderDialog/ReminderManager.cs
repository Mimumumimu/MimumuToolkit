using MimumuReminderDialog.Database.Entities;
using MimumuReminderDialog.Database.Queries;
using MimumuToolkit;
using MimumuToolkit.Constants;
using MimumuToolkit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimumuReminderDialog
{
    internal class ReminderManager
    {
        public static int SnoozeInterval { get; set; } = ReminderConstant.DefaultSnoozeMinute;

        public static List<ReminderDataEntity> ReminderList
        {
            get
            {
                if (m_reminderList == null)
                {
                    m_reminderList = ReminderQuery.GetReminder();
                }
                return m_reminderList;
            }
        }
        private static List<ReminderDataEntity>? m_reminderList = null;

        public static List<ReminderStateDataEntity> ReminderStates
        {
            get
            {
                if (m_reminderStates == null)
                {
                    m_reminderStates = ReminderQuery.GetReminderState();
                }
                return m_reminderStates;
            }
        }
        private static List<ReminderStateDataEntity>? m_reminderStates = null;
    }
}
