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
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            groupBox1 = new GroupBox();
            checkBox7 = new FlatCheckBox();
            checkBox6 = new FlatCheckBox();
            checkBox5 = new FlatCheckBox();
            checkBox4 = new FlatCheckBox();
            checkBox3 = new FlatCheckBox();
            checkBox2 = new FlatCheckBox();
            checkBox1 = new FlatCheckBox();
            PnlDock = new Panel();
            checkBox8 = new FlatCheckBox();
            groupBox2 = new GroupBox();
            comboBox2 = new ComboBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            RbtnOK = new RoundButton();
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            PnlDock.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TbTitle
            // 
            TbTitle.Dock = DockStyle.Top;
            TbTitle.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TbTitle.Location = new Point(4, 4);
            TbTitle.Margin = new Padding(3, 4, 3, 4);
            TbTitle.Name = "TbTitle";
            TbTitle.Size = new Size(567, 30);
            TbTitle.TabIndex = 1;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BorderStyle = BorderStyle.None;
            checkedListBox1.Dock = DockStyle.Left;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "未実装" });
            checkedListBox1.Location = new Point(4, 34);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(143, 309);
            checkedListBox1.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy/MM/dd(ddd)";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(6, 13);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.Size = new Size(175, 23);
            dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(105, 42);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Size = new Size(76, 23);
            dateTimePicker2.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(checkBox7);
            groupBox1.Controls.Add(checkBox6);
            groupBox1.Controls.Add(checkBox5);
            groupBox1.Controls.Add(checkBox4);
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Location = new Point(203, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(194, 101);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "曜日";
            // 
            // checkBox7
            // 
            checkBox7.Location = new Point(100, 64);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(41, 31);
            checkBox7.TabIndex = 6;
            checkBox7.Text = "日";
            checkBox7.TextAlign = ContentAlignment.MiddleCenter;
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.Location = new Point(53, 64);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(41, 31);
            checkBox6.TabIndex = 5;
            checkBox6.Text = "土";
            checkBox6.TextAlign = ContentAlignment.MiddleCenter;
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.Location = new Point(6, 64);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(41, 31);
            checkBox5.TabIndex = 4;
            checkBox5.Text = "金";
            checkBox5.TextAlign = ContentAlignment.MiddleCenter;
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.Location = new Point(147, 27);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(41, 31);
            checkBox4.TabIndex = 3;
            checkBox4.Text = "木";
            checkBox4.TextAlign = ContentAlignment.MiddleCenter;
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.Location = new Point(100, 27);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(41, 31);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "水";
            checkBox3.TextAlign = ContentAlignment.MiddleCenter;
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.Location = new Point(53, 27);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(41, 31);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "火";
            checkBox2.TextAlign = ContentAlignment.MiddleCenter;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.Location = new Point(6, 27);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(41, 31);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "月";
            checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // PnlDock
            // 
            PnlDock.Controls.Add(checkBox8);
            PnlDock.Controls.Add(groupBox2);
            PnlDock.Controls.Add(textBox2);
            PnlDock.Controls.Add(textBox1);
            PnlDock.Controls.Add(groupBox1);
            PnlDock.Controls.Add(dateTimePicker2);
            PnlDock.Controls.Add(dateTimePicker1);
            PnlDock.Dock = DockStyle.Fill;
            PnlDock.Location = new Point(147, 34);
            PnlDock.Name = "PnlDock";
            PnlDock.Size = new Size(424, 309);
            PnlDock.TabIndex = 3;
            // 
            // checkBox8
            // 
            checkBox8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox8.Location = new Point(303, 121);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(104, 31);
            checkBox8.TabIndex = 8;
            checkBox8.Text = "音声通知";
            checkBox8.TextAlign = ContentAlignment.MiddleCenter;
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(6, 204);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(415, 97);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "外部通知";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Discord：なし" });
            comboBox2.Location = new Point(99, 27);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(302, 24);
            comboBox2.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 31);
            label2.Name = "label2";
            label2.Size = new Size(39, 16);
            label2.TabIndex = 8;
            label2.Text = "ntfy";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Discord：なし" });
            comboBox1.Location = new Point(99, 62);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(302, 24);
            comboBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 66);
            label1.Name = "label1";
            label1.Size = new Size(63, 16);
            label1.TabIndex = 7;
            label1.Text = "Discord";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(12, 164);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "備考";
            textBox2.Size = new Size(395, 23);
            textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(12, 125);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "件名";
            textBox1.Size = new Size(285, 23);
            textBox1.TabIndex = 4;
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
            RbtnOK.DialogResult = DialogResult.OK;
            RbtnOK.FlatAppearance.BorderSize = 0;
            RbtnOK.FlatStyle = FlatStyle.Flat;
            RbtnOK.ForeColor = Color.Black;
            RbtnOK.HighlightColor = Color.FromArgb(66, 165, 245);
            RbtnOK.Location = new Point(441, 2);
            RbtnOK.Name = "RbtnOK";
            RbtnOK.ParentControl = null;
            RbtnOK.Size = new Size(120, 40);
            RbtnOK.TabIndex = 9;
            RbtnOK.Text = "ＯＫ";
            RbtnOK.UseVisualStyleBackColor = false;
            RbtnOK.Click += RbtnOK_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(RbtnOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(4, 343);
            panel1.Name = "panel1";
            panel1.Size = new Size(567, 49);
            panel1.TabIndex = 10;
            // 
            // ReminderInputDialog
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(575, 396);
            Controls.Add(PnlDock);
            Controls.Add(checkedListBox1);
            Controls.Add(TbTitle);
            Controls.Add(panel1);
            Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReminderInputDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "リマインダー入力";
            groupBox1.ResumeLayout(false);
            PnlDock.ResumeLayout(false);
            PnlDock.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MimumuToolkit.CustomControls.TitleBarControl TbTitle;
        private CheckedListBox checkedListBox1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private GroupBox groupBox1;
        private FlatCheckBox checkBox7;
        private FlatCheckBox checkBox6;
        private FlatCheckBox checkBox5;
        private FlatCheckBox checkBox4;
        private FlatCheckBox checkBox3;
        private FlatCheckBox checkBox2;
        private FlatCheckBox checkBox1;
        private Panel PnlDock;
        private TextBox textBox2;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private MimumuToolkit.CustomControls.RoundButton RbtnOK;
        private FlatCheckBox checkBox8;
        private ComboBox comboBox2;
        private Label label2;
        private Label label1;
        private Panel panel1;
    }
}