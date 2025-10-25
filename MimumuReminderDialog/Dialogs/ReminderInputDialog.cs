using MimumuReminderDialog.Database.Entities;
using MimumuReminderDialog.Database.Queries;
using MimumuToolkit.CustomControls;
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
    public partial class ReminderInputDialog : CustomForm
    {
        public ReminderInputDialog()
        {
            InitializeComponent();
        }

        private void RbtnOK_Click(object sender, EventArgs e)
        {
            // todo:
            ReminderDataEntity reminderData = new ReminderDataEntity();

            ReminderQuery.SetReminder(reminderData);
        }
    }
}
