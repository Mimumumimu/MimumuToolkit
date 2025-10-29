using MimumuReminderDialog.Database.Entities;
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
    public partial class ReminderListDialog : CustomForm
    {
        public ReminderListDialog()
        {
            InitializeComponent();

            DgvtxtcDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvtxtcDaysOfWeek.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DgvtxtcDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvtxtcDaysOfWeek.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in DgvList.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            LoadReminder();

        }


        private void ReminderListDialog_Shown(object sender, EventArgs e)
        {
            DgvList.ClearSelection();
            DgvList.CurrentCell = null;
        }


        private void RbtnAdd_Click(object sender, EventArgs e)
        {
            using (ReminderInputDialog dialog = new ReminderInputDialog(null))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadReminder();
                }
            }
        }

        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvList.Rows[e.RowIndex].Tag is ReminderDataEntity reminder)
            {
                using (ReminderInputDialog dialog = new ReminderInputDialog(reminder))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadReminder();
                    }
                }
            }
        }

        private void DgvList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    DgvList.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void LoadReminder()
        {
            DgvList.Rows.Clear();

            var reminderList = ReminderManager.ReminderList.OrderBy(r => r.Date).ThenBy(r => r.Time).ThenBy(r => r.Seq).ToList();
            foreach (var reminder in reminderList)
            {
                string date;
                if (reminder.Date == 99999999)
                {
                    date = "－";
                }
                else
                {
                    date = ConvUtil.IntDateToDatetime(reminder.Date).ToString("yyyy/MM/dd");
                }
                string daysOfWeek;
                if (reminder.GetDaysOfWeek == CommonConstants.DayOfWeekFlags.None)
                {
                    daysOfWeek = "－";
                }
                else
                {
                    daysOfWeek = ConvUtil.DayOfWeekFlagsToString(reminder.GetDaysOfWeek);
                }
                string time = ConvUtil.IntTimeToDatetime(reminder.Time).ToString("HH:mm");

                DgvList.Rows.Add();
                int rowIndex = DgvList.Rows.Count - 1;
                DgvList.Rows[rowIndex].Tag = reminder;
                //DgvList.Rows[rowIndex].Cells[DgvtxtcUser.Index].Value = reminder.UserNo;
                DgvList.Rows[rowIndex].Cells[DgvtxtcUser.Index].Value = "－";
                DgvList.Rows[rowIndex].Cells[DgvtxtcDate.Index].Value = date;
                DgvList.Rows[rowIndex].Cells[DgvtxtcDaysOfWeek.Index].Value = daysOfWeek;
                DgvList.Rows[rowIndex].Cells[DgvtxtcTime.Index].Value = time;
                DgvList.Rows[rowIndex].Cells[DgvtxtcSubject.Index].Value = reminder.Subject;
                //DgvList.Rows[rowIndex].Cells[DgvtxtcRegister.Index].Value = reminder.CreateUser;
                DgvList.Rows[rowIndex].Cells[DgvtxtcRegister.Index].Value = "－";
            }
        }

    }
}
