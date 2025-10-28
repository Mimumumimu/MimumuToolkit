using MimumuToolkit.CustomControls;

namespace MimumuReminderDialog.Dialogs
{
    partial class ReminderInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TbTitle = new TitleBarControl();
            checkedListBox1 = new CheckedListBox();
            DtpDate = new DateTimePicker();
            DtpTime = new DateTimePicker();
            GbDaysOfWeek = new GroupBox();
            CbSunday = new FlatCheckBox();
            CbSaturday = new FlatCheckBox();
            CbFriday = new FlatCheckBox();
            CbThursday = new FlatCheckBox();
            CbWednesday = new FlatCheckBox();
            CbTuesday = new FlatCheckBox();
            CbMonday = new FlatCheckBox();
            PnlDock = new Panel();
            TxtLink = new TextBox();
            CbSoundNotification = new FlatCheckBox();
            GbExternalNotification = new GroupBox();
            CmbNtfy = new ComboBox();
            TxtNtfy = new Label();
            CmbDiscord = new ComboBox();
            TxtDiscord = new Label();
            TxtRemarks = new TextBox();
            TxtSubject = new TextBox();
            RbtnOK = new RoundButton();
            panel1 = new Panel();
            TpCommon = new CustomToolTip();
            GbDaysOfWeek.SuspendLayout();
            PnlDock.SuspendLayout();
            GbExternalNotification.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TbTitle
            // 
            TbTitle.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TbTitle.Location = new Point(4, 4);
            TbTitle.Margin = new Padding(3, 4, 3, 4);
            TbTitle.Name = "TbTitle";
            TbTitle.Size = new Size(567, 30);
            TbTitle.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BorderStyle = BorderStyle.None;
            checkedListBox1.Dock = DockStyle.Left;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "未実装" });
            checkedListBox1.Location = new Point(4, 34);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(143, 347);
            checkedListBox1.TabIndex = 1;
            // 
            // DtpDate
            // 
            DtpDate.CustomFormat = "yyyy/MM/dd(ddd)";
            DtpDate.Format = DateTimePickerFormat.Custom;
            DtpDate.Location = new Point(6, 13);
            DtpDate.Name = "DtpDate";
            DtpDate.ShowCheckBox = true;
            DtpDate.Size = new Size(175, 23);
            DtpDate.TabIndex = 0;
            DtpDate.ValueChanged += DtpDate_ValueChanged;
            // 
            // DtpTime
            // 
            DtpTime.CustomFormat = "HH:mm";
            DtpTime.Format = DateTimePickerFormat.Custom;
            DtpTime.Location = new Point(105, 42);
            DtpTime.Name = "DtpTime";
            DtpTime.ShowUpDown = true;
            DtpTime.Size = new Size(76, 23);
            DtpTime.TabIndex = 1;
            // 
            // GbDaysOfWeek
            // 
            GbDaysOfWeek.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GbDaysOfWeek.Controls.Add(CbSunday);
            GbDaysOfWeek.Controls.Add(CbSaturday);
            GbDaysOfWeek.Controls.Add(CbFriday);
            GbDaysOfWeek.Controls.Add(CbThursday);
            GbDaysOfWeek.Controls.Add(CbWednesday);
            GbDaysOfWeek.Controls.Add(CbTuesday);
            GbDaysOfWeek.Controls.Add(CbMonday);
            GbDaysOfWeek.Location = new Point(203, 7);
            GbDaysOfWeek.Name = "GbDaysOfWeek";
            GbDaysOfWeek.Size = new Size(194, 101);
            GbDaysOfWeek.TabIndex = 2;
            GbDaysOfWeek.TabStop = false;
            GbDaysOfWeek.Text = "曜日";
            // 
            // CbSunday
            // 
            CbSunday.Location = new Point(100, 64);
            CbSunday.Name = "CbSunday";
            CbSunday.Size = new Size(41, 31);
            CbSunday.TabIndex = 6;
            CbSunday.Text = "日";
            CbSunday.TextAlign = ContentAlignment.MiddleCenter;
            CbSunday.UseVisualStyleBackColor = true;
            // 
            // CbSaturday
            // 
            CbSaturday.Location = new Point(53, 64);
            CbSaturday.Name = "CbSaturday";
            CbSaturday.Size = new Size(41, 31);
            CbSaturday.TabIndex = 5;
            CbSaturday.Text = "土";
            CbSaturday.TextAlign = ContentAlignment.MiddleCenter;
            CbSaturday.UseVisualStyleBackColor = true;
            // 
            // CbFriday
            // 
            CbFriday.Location = new Point(6, 64);
            CbFriday.Name = "CbFriday";
            CbFriday.Size = new Size(41, 31);
            CbFriday.TabIndex = 4;
            CbFriday.Text = "金";
            CbFriday.TextAlign = ContentAlignment.MiddleCenter;
            CbFriday.UseVisualStyleBackColor = true;
            // 
            // CbThursday
            // 
            CbThursday.Location = new Point(147, 27);
            CbThursday.Name = "CbThursday";
            CbThursday.Size = new Size(41, 31);
            CbThursday.TabIndex = 3;
            CbThursday.Text = "木";
            CbThursday.TextAlign = ContentAlignment.MiddleCenter;
            CbThursday.UseVisualStyleBackColor = true;
            // 
            // CbWednesday
            // 
            CbWednesday.Location = new Point(100, 27);
            CbWednesday.Name = "CbWednesday";
            CbWednesday.Size = new Size(41, 31);
            CbWednesday.TabIndex = 2;
            CbWednesday.Text = "水";
            CbWednesday.TextAlign = ContentAlignment.MiddleCenter;
            CbWednesday.UseVisualStyleBackColor = true;
            // 
            // CbTuesday
            // 
            CbTuesday.Location = new Point(53, 27);
            CbTuesday.Name = "CbTuesday";
            CbTuesday.Size = new Size(41, 31);
            CbTuesday.TabIndex = 1;
            CbTuesday.Text = "火";
            CbTuesday.TextAlign = ContentAlignment.MiddleCenter;
            CbTuesday.UseVisualStyleBackColor = true;
            // 
            // CbMonday
            // 
            CbMonday.Location = new Point(6, 27);
            CbMonday.Name = "CbMonday";
            CbMonday.Size = new Size(41, 31);
            CbMonday.TabIndex = 0;
            CbMonday.Text = "月";
            CbMonday.TextAlign = ContentAlignment.MiddleCenter;
            CbMonday.UseVisualStyleBackColor = true;
            // 
            // PnlDock
            // 
            PnlDock.Controls.Add(TxtLink);
            PnlDock.Controls.Add(CbSoundNotification);
            PnlDock.Controls.Add(GbExternalNotification);
            PnlDock.Controls.Add(TxtRemarks);
            PnlDock.Controls.Add(TxtSubject);
            PnlDock.Controls.Add(GbDaysOfWeek);
            PnlDock.Controls.Add(DtpTime);
            PnlDock.Controls.Add(DtpDate);
            PnlDock.Dock = DockStyle.Fill;
            PnlDock.Location = new Point(147, 34);
            PnlDock.Name = "PnlDock";
            PnlDock.Size = new Size(424, 347);
            PnlDock.TabIndex = 2;
            // 
            // TxtLink
            // 
            TxtLink.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtLink.Location = new Point(12, 205);
            TxtLink.Name = "TxtLink";
            TxtLink.PlaceholderText = "Link";
            TxtLink.Size = new Size(395, 23);
            TxtLink.TabIndex = 7;
            // 
            // CbSoundNotification
            // 
            CbSoundNotification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CbSoundNotification.Location = new Point(303, 121);
            CbSoundNotification.Name = "CbSoundNotification";
            CbSoundNotification.Size = new Size(104, 31);
            CbSoundNotification.TabIndex = 4;
            CbSoundNotification.Text = "音声通知";
            CbSoundNotification.TextAlign = ContentAlignment.MiddleCenter;
            CbSoundNotification.UseVisualStyleBackColor = true;
            // 
            // GbExternalNotification
            // 
            GbExternalNotification.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GbExternalNotification.Controls.Add(CmbNtfy);
            GbExternalNotification.Controls.Add(TxtNtfy);
            GbExternalNotification.Controls.Add(CmbDiscord);
            GbExternalNotification.Controls.Add(TxtDiscord);
            GbExternalNotification.Location = new Point(6, 244);
            GbExternalNotification.Name = "GbExternalNotification";
            GbExternalNotification.Size = new Size(415, 97);
            GbExternalNotification.TabIndex = 6;
            GbExternalNotification.TabStop = false;
            GbExternalNotification.Text = "外部通知";
            // 
            // CmbNtfy
            // 
            CmbNtfy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CmbNtfy.FormattingEnabled = true;
            CmbNtfy.Items.AddRange(new object[] { "Discord：なし" });
            CmbNtfy.Location = new Point(99, 27);
            CmbNtfy.Name = "CmbNtfy";
            CmbNtfy.Size = new Size(302, 24);
            CmbNtfy.TabIndex = 1;
            // 
            // TxtNtfy
            // 
            TxtNtfy.AutoSize = true;
            TxtNtfy.Location = new Point(6, 31);
            TxtNtfy.Name = "TxtNtfy";
            TxtNtfy.Size = new Size(39, 16);
            TxtNtfy.TabIndex = 0;
            TxtNtfy.Text = "ntfy";
            // 
            // CmbDiscord
            // 
            CmbDiscord.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CmbDiscord.FormattingEnabled = true;
            CmbDiscord.Items.AddRange(new object[] { "Discord：なし" });
            CmbDiscord.Location = new Point(99, 62);
            CmbDiscord.Name = "CmbDiscord";
            CmbDiscord.Size = new Size(302, 24);
            CmbDiscord.TabIndex = 3;
            // 
            // TxtDiscord
            // 
            TxtDiscord.AutoSize = true;
            TxtDiscord.Location = new Point(6, 66);
            TxtDiscord.Name = "TxtDiscord";
            TxtDiscord.Size = new Size(63, 16);
            TxtDiscord.TabIndex = 2;
            TxtDiscord.Text = "Discord";
            // 
            // TxtRemarks
            // 
            TxtRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtRemarks.ImeMode = ImeMode.Hiragana;
            TxtRemarks.Location = new Point(12, 165);
            TxtRemarks.Name = "TxtRemarks";
            TxtRemarks.PlaceholderText = "備考";
            TxtRemarks.Size = new Size(395, 23);
            TxtRemarks.TabIndex = 5;
            // 
            // TxtSubject
            // 
            TxtSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtSubject.ImeMode = ImeMode.Hiragana;
            TxtSubject.Location = new Point(12, 125);
            TxtSubject.Name = "TxtSubject";
            TxtSubject.PlaceholderText = "件名";
            TxtSubject.Size = new Size(285, 23);
            TxtSubject.TabIndex = 3;
            // 
            // RbtnOK
            // 
            RbtnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RbtnOK.BackColor = Color.Transparent;
            RbtnOK.BorderColor = Color.LightGray;
            RbtnOK.BorderWidth = 1;
            RbtnOK.ButtonColor = Color.FromArgb(144, 202, 249);
            RbtnOK.ClickColor = Color.FromArgb(66, 135, 245);
            RbtnOK.CornerRadius = 5;
            RbtnOK.FlatAppearance.BorderSize = 0;
            RbtnOK.FlatStyle = FlatStyle.Flat;
            RbtnOK.ForeColor = Color.Black;
            RbtnOK.HighlightColor = Color.FromArgb(66, 165, 245);
            RbtnOK.Location = new Point(441, 2);
            RbtnOK.Name = "RbtnOK";
            RbtnOK.ParentControl = null;
            RbtnOK.Size = new Size(120, 40);
            RbtnOK.TabIndex = 0;
            RbtnOK.Text = "ＯＫ";
            RbtnOK.UseVisualStyleBackColor = false;
            RbtnOK.Click += RbtnOK_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(RbtnOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(4, 381);
            panel1.Name = "panel1";
            panel1.Size = new Size(567, 49);
            panel1.TabIndex = 3;
            // 
            // TpCommon
            // 
            TpCommon.OwnerDraw = true;
            // 
            // ReminderInputDialog
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(575, 434);
            Controls.Add(PnlDock);
            Controls.Add(checkedListBox1);
            Controls.Add(TbTitle);
            Controls.Add(panel1);
            Name = "ReminderInputDialog";
            SaveFormLocation = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "リマインダー入力";
            GbDaysOfWeek.ResumeLayout(false);
            PnlDock.ResumeLayout(false);
            PnlDock.PerformLayout();
            GbExternalNotification.ResumeLayout(false);
            GbExternalNotification.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MimumuToolkit.CustomControls.TitleBarControl TbTitle;
        private CheckedListBox checkedListBox1;
        private DateTimePicker DtpDate;
        private DateTimePicker DtpTime;
        private GroupBox GbDaysOfWeek;
        private FlatCheckBox CbSunday;
        private FlatCheckBox CbSaturday;
        private FlatCheckBox CbFriday;
        private FlatCheckBox CbThursday;
        private FlatCheckBox CbWednesday;
        private FlatCheckBox CbTuesday;
        private FlatCheckBox CbMonday;
        private Panel PnlDock;
        private TextBox TxtRemarks;
        private TextBox TxtSubject;
        private GroupBox GbExternalNotification;
        private ComboBox CmbDiscord;
        private MimumuToolkit.CustomControls.RoundButton RbtnOK;
        private FlatCheckBox CbSoundNotification;
        private ComboBox CmbNtfy;
        private Label TxtNtfy;
        private Label TxtDiscord;
        private Panel panel1;
        private TextBox TxtLink;
        private CustomToolTip TpCommon;
    }
}