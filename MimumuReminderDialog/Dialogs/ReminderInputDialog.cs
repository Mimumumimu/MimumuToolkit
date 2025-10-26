using MimumuReminderDialog.Database.Entities;
using MimumuReminderDialog.Database.Queries;
using MimumuToolkit.Constants;
using MimumuToolkit.CustomControls;
using MimumuToolkit.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MimumuReminderDialog.Dialogs
{
    public partial class ReminderInputDialog : CustomForm
    {
        private ReminderDataEntity m_reminder;
        public ReminderInputDialog(ReminderDataEntity? reminder)
        {
            InitializeComponent();

            if (reminder == null)
            {
                reminder = new ReminderDataEntity();
            }
            m_reminder = reminder;
            SetEntityToDisplay();
        }

        private void RbtnOK_Click(object sender, EventArgs e)
        {
            SetDisplayToEntity();

            ReminderQuery.SetReminder(m_reminder);
        }

        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (DtpDate.Checked == true)
            {
                GbDaysOfWeek.Enabled = false;
            }
            else
            {
                GbDaysOfWeek.Enabled = true;
            }
        }


        private void SetEntityToDisplay()
        {
            if (m_reminder.Date != 99999999)
            {
                DtpDate.Value = ConvUtil.IntDateToDatetime(m_reminder.Date);
                DtpDate.Checked = true;
                GbDaysOfWeek.Enabled = false;
            }
            else
            {
                DtpDate.Checked = false;
                GbDaysOfWeek.Enabled = true;

                CbSunday.Checked = (m_reminder.DaysOfWeek & (int)CommonConstants.DayOfWeekFlags.Sunday) != 0;
                CbMonday.Checked = (m_reminder.DaysOfWeek & (int)CommonConstants.DayOfWeekFlags.Monday) != 0;
                CbTuesday.Checked = (m_reminder.DaysOfWeek & (int)CommonConstants.DayOfWeekFlags.Tuesday) != 0;
                CbWednesday.Checked = (m_reminder.DaysOfWeek & (int)CommonConstants.DayOfWeekFlags.Wednesday) != 0;
                CbThursday.Checked = (m_reminder.DaysOfWeek & (int)CommonConstants.DayOfWeekFlags.Thursday) != 0;
                CbFriday.Checked = (m_reminder.DaysOfWeek & (int)CommonConstants.DayOfWeekFlags.Friday) != 0;
                CbSaturday.Checked = (m_reminder.DaysOfWeek & (int)CommonConstants.DayOfWeekFlags.Saturday) != 0;
            }
            DtpTime.Value = ConvUtil.IntTimeToDatetime(m_reminder.Time);

            TxtSubject.Text = m_reminder.Subject;
            TxtRemarks.Text = m_reminder.Remarks;
            TxtLink.Text = m_reminder.Link;
            CbSoundNotification.Checked = m_reminder.IsSpeak;
        }

        private void SetDisplayToEntity()
        {
            if (DtpDate.Checked == true)
            {
                m_reminder.Date = ConvUtil.DatetimeToIntDate(DtpDate.Value);
                m_reminder.DaysOfWeek = (int)CommonConstants.DayOfWeekFlags.None;
            }
            else
            {
                m_reminder.Date = 99999999;
                CommonConstants.DayOfWeekFlags daysOfWeek = CommonConstants.DayOfWeekFlags.None;
                if (CbSunday.Checked == true)
                {
                    daysOfWeek |= CommonConstants.DayOfWeekFlags.Sunday;
                }
                if (CbMonday.Checked == true)
                {
                    daysOfWeek |= CommonConstants.DayOfWeekFlags.Monday;
                }
                if (CbTuesday.Checked == true)
                {
                    daysOfWeek |= CommonConstants.DayOfWeekFlags.Tuesday;
                }
                if (CbWednesday.Checked == true)
                {
                    daysOfWeek |= CommonConstants.DayOfWeekFlags.Wednesday;
                }
                if (CbThursday.Checked == true)
                {
                    daysOfWeek |= CommonConstants.DayOfWeekFlags.Thursday;
                }
                if (CbFriday.Checked == true)
                {
                    daysOfWeek |= CommonConstants.DayOfWeekFlags.Friday;
                }
                if (CbSaturday.Checked == true)
                {
                    daysOfWeek |= CommonConstants.DayOfWeekFlags.Saturday;
                }
                m_reminder.DaysOfWeek = (int)daysOfWeek;
            }
            m_reminder.Time = ConvUtil.DatetimeToIntTime(DtpTime.Value);
   
            m_reminder.Subject = TxtSubject.Text;
            m_reminder.Remarks = TxtRemarks.Text;
            m_reminder.Link = TxtLink.Text;
            m_reminder.IsSpeak = CbSoundNotification.Checked;
        }
    }
}
