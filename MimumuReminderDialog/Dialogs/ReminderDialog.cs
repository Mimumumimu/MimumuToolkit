using MimumuReminderDialog.Database.Entities;
using MimumuReminderDialog.Database.Queries;
using MimumuToolkit;
using MimumuToolkit.Constants;
using MimumuToolkit.Controls;
using MimumuToolkit.Entities;
using MimumuToolkit.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MimumuReminderDialog.Dialogs
{
    public partial class ReminderDialog : CustomForm
    {
        public ReminderDialog()
        {
            InitializeComponent();

            ClbList.DisplayMember = "DisplayData";

            SetTimer(60, CheckNotification);
            SetDailyTimer(SetList);

            SetList();
        }

        private void ClbList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // なぜか不要……
            //if (ClbList.IsDataSetting == true)
            //{
            //    return;
            //}

            if (ClbList.Items[e.Index] is ReminderDataEntity reminder)
            {
                var state = ReminderManager.ReminderStates.FirstOrDefault(r => r.BaseNo == reminder.No);
                if (state == null)
                {
                    state = new ReminderStateDataEntity
                    {
                        BaseNo = reminder.No,
                    };
                }
                state.Date = ConvUtil.DatetimeToIntDate(DateTime.Now);
                state.Value = (int)e.NewValue;

                ReminderQuery.SetReminderState(state);
            }
        }

        private void RbnList_Click(object sender, EventArgs e)
        {
            using (ReminderListDialog dialog = new ReminderListDialog())
            {
                //dialog.StartPosition = FormStartPosition.CenterParent;
                //dialog.GroupNo = MimumuToolkitManager.GroupNo;
                var result = dialog.ShowDialog(this);
                SetList();
            }
        }

        private void RbtnAdd_Click(object sender, EventArgs e)
        {
            using (ReminderInputDialog dialog = new ReminderInputDialog(null))
            {
                //dialog.StartPosition = FormStartPosition.CenterParent;
                //dialog.GroupNo = MimumuToolkitManager.GroupNo;
                var result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    SetList();
                }
            }
        }

        public void SetList()
        {
            ClbList.IsDataSetting = true;

            ClbList.Items.Clear();
            DateTime now = DateTime.Now;
            int date = ConvUtil.DatetimeToIntDate(now);
            var dayOfWeek = ConvUtil.DayOfWeekToDayOfWeekFlags(now.DayOfWeek);

            // まとめてもよかったんだけど、見やすさ優先で分けた
            var reminderList = ReminderManager.ReminderList.Where(r => r.GroupNo == MimumuToolkitManager.GroupNo);
            reminderList = reminderList.Where(x => x.Date == date || x.Date == 99999999);
            reminderList = reminderList.OrderBy(r => r.Time).ThenBy(r => r.No);
            foreach (var reminder in reminderList)
            {
                var daysOfWeek = reminder.GetDaysOfWeek;
                // Noneではない場合の処理
                if (daysOfWeek != CommonConstants.DayOfWeekFlags.None)
                {
                    // 曜日が一致していなかったら
                    if ((reminder.GetDaysOfWeek & dayOfWeek) != dayOfWeek)
                    {
                        continue;
                    }
                }
                ClbList.Items.Add(reminder);
                int index = ClbList.Items.Count - 1;

                // チェック状態の設定
                var state = ReminderManager.ReminderStates.FirstOrDefault(r => r.BaseNo == reminder.No);
                if (state != null)
                {
                    if (state.Date == date)
                    {
                        ClbList.SetItemCheckState(index, ConvUtil.ToCheckState(state.Value));
                    }
                }
            }

            ClbList.IsDataSetting = false;
        }

        private DateTime m_lastSnoozeTime = DateTime.MinValue;

        public void CheckNotification()
        {
            DateTime now = DateTime.Now;
            int nowTime = ConvUtil.DatetimeToIntTime(now);

            bool isSnoozeNotification = false;
            if (m_lastSnoozeTime != DateTime.MinValue)
            {
                if ((now - m_lastSnoozeTime).TotalMinutes >= 30)
                {
                    isSnoozeNotification = true;
                    m_lastSnoozeTime = now;
                }
            }
            else
            {
                m_lastSnoozeTime = now;
                // 初回は通知する
                isSnoozeNotification = true;
            }
            

            List<LinkEntity> links = [];
            for (int i = 0; i < ClbList.Items.Count; i++)
            {
                var item = ClbList.Items[i];
                if (item is ReminderDataEntity reminder)
                {
                    if (reminder.Time > nowTime)
                    {
                        continue;
                    }


                    switch (ClbList.GetItemCheckState(i))
                    {
                        case CheckState.Unchecked:
                            break;
                        case CheckState.Indeterminate:
                            if (isSnoozeNotification == false)
                            {
                                continue;
                            }
                            break;
                        case CheckState.Checked:
                            continue;

                    }

                    LinkEntity link = new(reminder.Subject, reminder.Link, reminder.Remarks);
                    links.Add(link);
                }
            }

            if (links.Count == 0)
            {
                return;
            }

            MimumuToolkitManager.ShowNotification(links, VisibleFromNotification);
        }

        private void VisibleFromNotification()
        {
            DateTime now = DateTime.Now;
            int nowTime = ConvUtil.DatetimeToIntTime(now);
            m_lastSnoozeTime = now;
            for (int i = 0; i < ClbList.Items.Count; i++)
            {
                if (ClbList.Items[i] is ReminderDataEntity reminder)
                {
                    if (reminder.Time > nowTime)
                    {
                        continue;
                    }
                }
                if (ClbList.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    ClbList.SetItemCheckState(i, CheckState.Indeterminate);
                }
            }
            CustomShow();
        }
    }
}
