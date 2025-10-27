using MimumuReminderDialog.Database.Entities;
using MimumuToolkit;
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
            results = results.Where(r => r.GroupNo == MimumuToolkitManager.GroupNo).ToList();

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

        public static List<ReminderStateDataEntity> GetReminderState()
        {
            var results = CommonUtil.LoadFromJsonFile<List<ReminderStateDataEntity>>(ReminderStateDataEntity.JsonFileName);
            if (results == null)
            {
                results = [];
            }
            results = results.Where(r => r.GroupNo == MimumuToolkitManager.GroupNo).ToList();
            results = results.Where(r => r.UserNo == MimumuToolkitManager.UserNo).ToList();

            return results;
        }

        public static void SetReminderState(ReminderStateDataEntity reminderState)
        {
            if (reminderState.GroupNo == 0 || reminderState.UserNo == 0)
            {
                return;
            }

            if (reminderState.Seq == 0)
            {
                if (ReminderManager.ReminderList.Count > 0)
                {
                    reminderState.Seq = ReminderManager.ReminderList.Max(r => r.Seq) + 1;
                    var groupReminders = ReminderManager.ReminderList.Where(r => r.GroupNo == reminderState.GroupNo).ToList();
                    if (groupReminders.Count > 0)
                    {
                        reminderState.No = groupReminders.Max(r => r.No) + 1;
                    }
                    else
                    {
                        reminderState.No = 1;
                    }
                }
                else
                {
                    reminderState.Seq = 1;
                    reminderState.No = 1;
                }

                ReminderManager.ReminderStates.Add(reminderState);
            }
            CommonUtil.SaveToJsonFile(ReminderManager.ReminderStates, ReminderStateDataEntity.JsonFileName);
        }
    }
}
