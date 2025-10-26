using MimumuToolkit;
using MimumuToolkit.Constants;
using MimumuToolkit.CustomControls;
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

            CclbList.DisplayMember = "DisplayData";
            SetList();
        }

        private void CclbList_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        public void SetList()
        {
            CclbList.IsDataSetting = true;

            CclbList.Items.Clear();
            DateTime now = DateTime.Now;
            int date = ConvUtil.DatetimeToIntDate(now);
            var dayOfWeek = ConvUtil.DayOfWeekToDayOfWeekFlags(now.DayOfWeek);

            // まとめてもよかったんだけど、見やすさ優先で分けた
            var reminderList = ReminderManager.ReminderList.Where(r => r.GroupNo == MimumuToolkitManager.GroupNo);
            reminderList = reminderList.Where(x => x.Date == date || x.Date == 99999999).OrderBy(r => r.Time).ThenBy(r => r.No);
            reminderList = reminderList.OrderBy(r => r.Time).ThenBy(r => r.No);
            foreach (var reminder in reminderList)
            {
                var daysOfWeek = reminder.GetDaysOfWeek;
                // Noneではないない場合の処理
                if (daysOfWeek != CommonConstants.DayOfWeekFlags.None)
                {
                    // 曜日が一致していなかったら
                    if ((reminder.GetDaysOfWeek & dayOfWeek) != dayOfWeek)
                    {
                        continue;
                    }
                }
                CclbList.Items.Add(reminder);
            }

            CclbList.IsDataSetting = false;
        }


        private void RbnList_Click(object sender, EventArgs e)
        {
            using (ReminderListDialog dialog = new ReminderListDialog())
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

        private void RbtnAdd_Click(object sender, EventArgs e)
        {
            using(ReminderInputDialog dialog = new ReminderInputDialog(null))
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

    }
}
