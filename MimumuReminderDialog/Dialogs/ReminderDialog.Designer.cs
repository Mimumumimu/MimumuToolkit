namespace MimumuReminderDialog.Dialogs
{
    partial class ReminderDialog
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
            ClbList = new MimumuToolkit.CustomControls.CustomCheckedListBox();
            TbTitle = new MimumuToolkit.CustomControls.TitleBarControl();
            RbtnAdd = new MimumuToolkit.CustomControls.RoundButton();
            RbnList = new MimumuToolkit.CustomControls.RoundButton();
            SuspendLayout();
            // 
            // ClbList
            // 
            ClbList.BorderStyle = BorderStyle.None;
            ClbList.Dock = DockStyle.Fill;
            ClbList.Items.AddRange(new object[] { "Dummy01", "Dummy02", "Dummy03", "Dummy04", "Dummy05", "Dummy06", "Dummy07", "Dummy08", "Dummy09", "Dummy10", "Dummy01", "Dummy02", "Dummy03", "Dummy04", "Dummy05", "Dummy06", "Dummy07", "Dummy08", "Dummy09", "Dummy10" });
            ClbList.Location = new Point(4, 34);
            ClbList.Name = "ClbList";
            ClbList.Size = new Size(192, 234);
            ClbList.TabIndex = 0;
            ClbList.ItemCheck += ClbList_ItemCheck;
            // 
            // TbTitle
            // 
            TbTitle.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TbTitle.Location = new Point(4, 4);
            TbTitle.Margin = new Padding(3, 4, 3, 4);
            TbTitle.Name = "TbTitle";
            TbTitle.Size = new Size(192, 30);
            TbTitle.TabIndex = 0;
            // 
            // RbtnAdd
            // 
            RbtnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RbtnAdd.BackColor = Color.Transparent;
            RbtnAdd.BorderColor = Color.LightGray;
            RbtnAdd.BorderWidth = 1;
            RbtnAdd.ButtonColor = Color.FromArgb(144, 202, 249);
            RbtnAdd.ClickColor = Color.FromArgb(66, 135, 245);
            RbtnAdd.CornerRadius = 15;
            RbtnAdd.FlatAppearance.BorderSize = 0;
            RbtnAdd.FlatStyle = FlatStyle.Flat;
            RbtnAdd.ForeColor = Color.Black;
            RbtnAdd.HighlightColor = Color.FromArgb(66, 165, 245);
            RbtnAdd.Location = new Point(163, 235);
            RbtnAdd.Name = "RbtnAdd";
            RbtnAdd.ParentControl = ClbList;
            RbtnAdd.Size = new Size(30, 30);
            RbtnAdd.TabIndex = 1;
            RbtnAdd.Text = "＋";
            RbtnAdd.UseVisualStyleBackColor = false;
            RbtnAdd.Click += RbtnAdd_Click;
            // 
            // RbnList
            // 
            RbnList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RbnList.BackColor = Color.Transparent;
            RbnList.BorderColor = Color.LightGray;
            RbnList.BorderWidth = 1;
            RbnList.ButtonColor = Color.FromArgb(144, 202, 249);
            RbnList.ClickColor = Color.FromArgb(66, 135, 245);
            RbnList.CornerRadius = 15;
            RbnList.FlatAppearance.BorderSize = 0;
            RbnList.FlatStyle = FlatStyle.Flat;
            RbnList.ForeColor = Color.Black;
            RbnList.HighlightColor = Color.FromArgb(66, 165, 245);
            RbnList.Location = new Point(163, 41);
            RbnList.Name = "RbnList";
            RbnList.ParentControl = ClbList;
            RbnList.Size = new Size(30, 30);
            RbnList.TabIndex = 2;
            RbnList.Text = "≡";
            RbnList.UseVisualStyleBackColor = false;
            RbnList.Click += RbnList_Click;
            // 
            // ReminderDialog
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(200, 272);
            Controls.Add(RbnList);
            Controls.Add(RbtnAdd);
            Controls.Add(ClbList);
            Controls.Add(TbTitle);
            Name = "ReminderDialog";
            Text = "リマインダー";
            ResumeLayout(false);
        }

        #endregion

        private MimumuToolkit.CustomControls.CustomCheckedListBox ClbList;
        private MimumuToolkit.CustomControls.TitleBarControl TbTitle;
        private MimumuToolkit.CustomControls.RoundButton RbtnAdd;
        private MimumuToolkit.CustomControls.RoundButton RbnList;
    }
}