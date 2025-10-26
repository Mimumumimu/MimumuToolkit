namespace MimumuReminderDialog.Dialogs
{
    partial class ReminderListDialog
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            TbTitle = new MimumuToolkit.CustomControls.TitleBarControl();
            RbtnAdd = new MimumuToolkit.CustomControls.RoundButton();
            PnlTop = new Panel();
            flatCheckBox2 = new MimumuToolkit.CustomControls.FlatCheckBox();
            flatCheckBox1 = new MimumuToolkit.CustomControls.FlatCheckBox();
            DgvList = new MimumuToolkit.CustomControls.CustomDataGridView();
            DgvtxtcUser = new DataGridViewTextBoxColumn();
            DgvtxtcDate = new DataGridViewTextBoxColumn();
            DgvtxtcDaysOfWeek = new DataGridViewTextBoxColumn();
            DgvtxtcTime = new DataGridViewTextBoxColumn();
            DgvtxtcSubject = new DataGridViewTextBoxColumn();
            DgvtxtcRegister = new DataGridViewTextBoxColumn();
            PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvList).BeginInit();
            SuspendLayout();
            // 
            // TbTitle
            // 
            TbTitle.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TbTitle.Location = new Point(4, 4);
            TbTitle.Margin = new Padding(3, 4, 3, 4);
            TbTitle.Name = "TbTitle";
            TbTitle.Size = new Size(792, 30);
            TbTitle.TabIndex = 0;
            // 
            // RbtnAdd
            // 
            RbtnAdd.BackColor = Color.Transparent;
            RbtnAdd.BorderColor = Color.LightGray;
            RbtnAdd.BorderWidth = 1;
            RbtnAdd.ButtonColor = Color.FromArgb(144, 202, 249);
            RbtnAdd.ClickColor = Color.FromArgb(66, 135, 245);
            RbtnAdd.CornerRadius = 5;
            RbtnAdd.FlatAppearance.BorderSize = 0;
            RbtnAdd.FlatStyle = FlatStyle.Flat;
            RbtnAdd.ForeColor = Color.Black;
            RbtnAdd.HighlightColor = Color.FromArgb(66, 165, 245);
            RbtnAdd.Location = new Point(3, 7);
            RbtnAdd.Name = "RbtnAdd";
            RbtnAdd.ParentControl = null;
            RbtnAdd.Size = new Size(120, 40);
            RbtnAdd.TabIndex = 1;
            RbtnAdd.Text = "新規追加";
            RbtnAdd.UseVisualStyleBackColor = false;
            RbtnAdd.Click += RbtnAdd_Click;
            // 
            // PnlTop
            // 
            PnlTop.Controls.Add(flatCheckBox2);
            PnlTop.Controls.Add(flatCheckBox1);
            PnlTop.Controls.Add(RbtnAdd);
            PnlTop.Dock = DockStyle.Top;
            PnlTop.Location = new Point(4, 34);
            PnlTop.Name = "PnlTop";
            PnlTop.Size = new Size(792, 60);
            PnlTop.TabIndex = 2;
            // 
            // flatCheckBox2
            // 
            flatCheckBox2.AutoSize = true;
            flatCheckBox2.FlatAppearance.BorderColor = Color.LightGray;
            flatCheckBox2.FlatAppearance.CheckedBackColor = Color.FromArgb(66, 135, 245);
            flatCheckBox2.FlatAppearance.MouseDownBackColor = Color.FromArgb(66, 135, 245);
            flatCheckBox2.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 165, 245);
            flatCheckBox2.Location = new Point(275, 14);
            flatCheckBox2.Name = "flatCheckBox2";
            flatCheckBox2.Size = new Size(81, 26);
            flatCheckBox2.TabIndex = 3;
            flatCheckBox2.Text = "削除表示";
            flatCheckBox2.TextAlign = ContentAlignment.MiddleCenter;
            flatCheckBox2.UseVisualStyleBackColor = true;
            // 
            // flatCheckBox1
            // 
            flatCheckBox1.AutoSize = true;
            flatCheckBox1.FlatAppearance.BorderColor = Color.LightGray;
            flatCheckBox1.FlatAppearance.CheckedBackColor = Color.FromArgb(66, 135, 245);
            flatCheckBox1.FlatAppearance.MouseDownBackColor = Color.FromArgb(66, 135, 245);
            flatCheckBox1.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 165, 245);
            flatCheckBox1.Location = new Point(172, 14);
            flatCheckBox1.Name = "flatCheckBox1";
            flatCheckBox1.Size = new Size(97, 26);
            flatCheckBox1.TabIndex = 2;
            flatCheckBox1.Text = "過去日表示";
            flatCheckBox1.TextAlign = ContentAlignment.MiddleCenter;
            flatCheckBox1.UseVisualStyleBackColor = true;
            // 
            // DgvList
            // 
            DgvList.AllowUserToAddRows = false;
            DgvList.AllowUserToDeleteRows = false;
            DgvList.AllowUserToResizeRows = false;
            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvList.BackgroundColor = Color.FromArgb(245, 245, 245);
            DgvList.BorderStyle = BorderStyle.None;
            DgvList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewCellStyle1.Font = new Font("BIZ UDゴシック", 12F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Padding = new Padding(0, 6, 0, 6);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            DgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvList.Columns.AddRange(new DataGridViewColumn[] { DgvtxtcUser, DgvtxtcDate, DgvtxtcDaysOfWeek, DgvtxtcTime, DgvtxtcSubject, DgvtxtcRegister });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("BIZ UDゴシック", 12F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.Padding = new Padding(0, 4, 0, 4);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(200, 225, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DgvList.DefaultCellStyle = dataGridViewCellStyle2;
            DgvList.Dock = DockStyle.Fill;
            DgvList.EnableHeadersVisualStyles = false;
            DgvList.GridColor = Color.FromArgb(230, 230, 230);
            DgvList.Location = new Point(4, 94);
            DgvList.MultiSelect = false;
            DgvList.Name = "DgvList";
            DgvList.ReadOnly = true;
            DgvList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvList.RowHeadersVisible = false;
            DgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvList.Size = new Size(792, 352);
            DgvList.TabIndex = 3;
            DgvList.CellDoubleClick += DgvList_CellDoubleClick;
            DgvList.CellMouseDown += DgvList_CellMouseDown;
            // 
            // DgvtxtcUser
            // 
            DgvtxtcUser.HeaderText = "ユーザー";
            DgvtxtcUser.Name = "DgvtxtcUser";
            DgvtxtcUser.ReadOnly = true;
            DgvtxtcUser.Width = 94;
            // 
            // DgvtxtcDate
            // 
            DgvtxtcDate.HeaderText = "日付";
            DgvtxtcDate.Name = "DgvtxtcDate";
            DgvtxtcDate.ReadOnly = true;
            DgvtxtcDate.Width = 62;
            // 
            // DgvtxtcDaysOfWeek
            // 
            DgvtxtcDaysOfWeek.HeaderText = "曜日";
            DgvtxtcDaysOfWeek.Name = "DgvtxtcDaysOfWeek";
            DgvtxtcDaysOfWeek.ReadOnly = true;
            DgvtxtcDaysOfWeek.Width = 62;
            // 
            // DgvtxtcTime
            // 
            DgvtxtcTime.HeaderText = "時刻";
            DgvtxtcTime.Name = "DgvtxtcTime";
            DgvtxtcTime.ReadOnly = true;
            DgvtxtcTime.Width = 62;
            // 
            // DgvtxtcSubject
            // 
            DgvtxtcSubject.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvtxtcSubject.HeaderText = "件名";
            DgvtxtcSubject.Name = "DgvtxtcSubject";
            DgvtxtcSubject.ReadOnly = true;
            // 
            // DgvtxtcRegister
            // 
            DgvtxtcRegister.HeaderText = "登録者";
            DgvtxtcRegister.Name = "DgvtxtcRegister";
            DgvtxtcRegister.ReadOnly = true;
            DgvtxtcRegister.Width = 78;
            // 
            // ReminderListDialog
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(DgvList);
            Controls.Add(PnlTop);
            Controls.Add(TbTitle);
            Name = "ReminderListDialog";
            SaveFormLocation = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "リマインダー一覧";
            Shown += ReminderListDialog_Shown;
            PnlTop.ResumeLayout(false);
            PnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MimumuToolkit.CustomControls.TitleBarControl TbTitle;
        private MimumuToolkit.CustomControls.RoundButton RbtnAdd;
        private Panel PnlTop;
        private MimumuToolkit.CustomControls.FlatCheckBox flatCheckBox1;
        private MimumuToolkit.CustomControls.FlatCheckBox flatCheckBox2;
        private MimumuToolkit.CustomControls.CustomDataGridView DgvList;
        private DataGridViewTextBoxColumn DgvtxtcUser;
        private DataGridViewTextBoxColumn DgvtxtcDate;
        private DataGridViewTextBoxColumn DgvtxtcDaysOfWeek;
        private DataGridViewTextBoxColumn DgvtxtcTime;
        private DataGridViewTextBoxColumn DgvtxtcSubject;
        private DataGridViewTextBoxColumn DgvtxtcRegister;
    }
}