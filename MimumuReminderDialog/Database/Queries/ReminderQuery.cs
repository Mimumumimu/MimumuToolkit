using MimumuReminderDialog.Database.Entities;
using MimumuToolkit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimumuReminderDialog.Database.Queries
{
    internal class ReminderQuery
    {
        public static List<ReminderDataEntity> GetReminder()
        {
            var results = CommonUtil.LoadFromJsonFile<List<ReminderDataEntity>>(ReminderDataEntity.JsonFileName);
            if (results == null)
            {
                results = [];
            }

            return results;
        }

        public static void SetReminder(ReminderDataEntity reminderData)
        {
            if (reminderData.GroupNo == 0)
            {
                return;
            }

            if (reminderData.Seq == 0)
            {
                if (ReminderManager.ReminderList.Count > 0)
                {
                    reminderData.Seq = ReminderManager.ReminderList.Max(x => x.Seq) + 1;
                    var groupReminders = ReminderManager.ReminderList.Where(x => x.GroupNo == reminderData.GroupNo).ToList();
                    reminderData.No = groupReminders.Count > 0 ? groupReminders.Max(x => x.No) + 1 : 1;
                }
                else
                {
                    reminderData.Seq = 1;
                    reminderData.No = 1;
                }

                ReminderManager.ReminderList.Add(reminderData);
            }
            CommonUtil.SaveToJsonFile(ReminderManager.ReminderList, ReminderDataEntity.JsonFileName);
        }
    }
}
