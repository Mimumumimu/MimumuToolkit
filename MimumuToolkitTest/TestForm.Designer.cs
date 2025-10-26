namespace MimumuToolkitTest
{
    partial class TestForm
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
            PnlFill = new Panel();
            roundButton2 = new MimumuToolkit.CustomControls.RoundButton();
            checkedListBox1 = new CheckedListBox();
            CbDarkMode = new CheckBox();
            button1 = new Button();
            TxtDiscordKey = new TextBox();
            TbSpeed = new TrackBar();
            LblSpeed = new Label();
            LblVolume = new Label();
            TbVolume = new TrackBar();
            BtnSpeek = new Button();
            TxtSpeek = new TextBox();
            titleBarControl1 = new MimumuToolkit.CustomControls.TitleBarControl();
            PnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TbSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TbVolume).BeginInit();
            SuspendLayout();
            // 
            // PnlFill
            // 
            PnlFill.Controls.Add(roundButton2);
            PnlFill.Controls.Add(checkedListBox1);
            PnlFill.Controls.Add(CbDarkMode);
            PnlFill.Controls.Add(button1);
            PnlFill.Controls.Add(TxtDiscordKey);
            PnlFill.Controls.Add(TbSpeed);
            PnlFill.Controls.Add(LblSpeed);
            PnlFill.Controls.Add(LblVolume);
            PnlFill.Controls.Add(TbVolume);
            PnlFill.Controls.Add(BtnSpeek);
            PnlFill.Controls.Add(TxtSpeek);
            PnlFill.Dock = DockStyle.Fill;
            PnlFill.Location = new Point(4, 34);
            PnlFill.Margin = new Padding(0);
            PnlFill.Name = "PnlFill";
            PnlFill.Size = new Size(792, 412);
            PnlFill.TabIndex = 1;
            // 
            // roundButton2
            // 
            roundButton2.BackColor = Color.Transparent;
            roundButton2.BorderColor = Color.LightGray;
            roundButton2.BorderWidth = 1;
            roundButton2.ButtonColor = Color.FromArgb(144, 202, 249);
            roundButton2.ClickColor = Color.FromArgb(66, 135, 245);
            roundButton2.CornerRadius = 15;
            roundButton2.FlatAppearance.BorderSize = 0;
            roundButton2.FlatStyle = FlatStyle.Flat;
            roundButton2.ForeColor = Color.Black;
            roundButton2.HighlightColor = SystemColors.Highlight;
            roundButton2.Location = new Point(471, 155);
            roundButton2.Name = "roundButton2";
            roundButton2.ParentControl = null;
            roundButton2.Size = new Size(30, 30);
            roundButton2.TabIndex = 15;
            roundButton2.Text = "＋";
            roundButton2.UseVisualStyleBackColor = false;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "ああ", "あ", "あ", "あ" });
            checkedListBox1.Location = new Point(431, 166);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(138, 112);
            checkedListBox1.TabIndex = 18;
            // 
            // CbDarkMode
            // 
            CbDarkMode.AutoSize = true;
            CbDarkMode.Location = new Point(12, 207);
            CbDarkMode.Name = "CbDarkMode";
            CbDarkMode.Size = new Size(98, 20);
            CbDarkMode.TabIndex = 13;
            CbDarkMode.Text = "checkBox1";
            CbDarkMode.UseVisualStyleBackColor = true;
            CbDarkMode.CheckedChanged += CbDarkMode_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 140);
            button1.Name = "button1";
            button1.Size = new Size(291, 61);
            button1.TabIndex = 11;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TxtDiscordKey
            // 
            TxtDiscordKey.Location = new Point(12, 105);
            TxtDiscordKey.Name = "TxtDiscordKey";
            TxtDiscordKey.Size = new Size(304, 23);
            TxtDiscordKey.TabIndex = 10;
            // 
            // TbSpeed
            // 
            TbSpeed.Location = new Point(371, 72);
            TbSpeed.Minimum = -10;
            TbSpeed.Name = "TbSpeed";
            TbSpeed.Size = new Size(104, 45);
            TbSpeed.TabIndex = 9;
            TbSpeed.TickFrequency = 2;
            // 
            // LblSpeed
            // 
            LblSpeed.AutoSize = true;
            LblSpeed.Location = new Point(302, 72);
            LblSpeed.Name = "LblSpeed";
            LblSpeed.Size = new Size(47, 16);
            LblSpeed.TabIndex = 8;
            LblSpeed.Text = "Speed";
            // 
            // LblVolume
            // 
            LblVolume.AutoSize = true;
            LblVolume.Location = new Point(302, 24);
            LblVolume.Name = "LblVolume";
            LblVolume.Size = new Size(55, 16);
            LblVolume.TabIndex = 7;
            LblVolume.Text = "Volume";
            // 
            // TbVolume
            // 
            TbVolume.Location = new Point(371, 21);
            TbVolume.Maximum = 100;
            TbVolume.Name = "TbVolume";
            TbVolume.Size = new Size(104, 45);
            TbVolume.TabIndex = 6;
            TbVolume.TickFrequency = 10;
            TbVolume.Value = 100;
            // 
            // BtnSpeek
            // 
            BtnSpeek.FlatStyle = FlatStyle.Flat;
            BtnSpeek.Location = new Point(481, 19);
            BtnSpeek.Name = "BtnSpeek";
            BtnSpeek.Size = new Size(150, 30);
            BtnSpeek.TabIndex = 5;
            BtnSpeek.Text = "音声出力テスト";
            BtnSpeek.UseVisualStyleBackColor = true;
            BtnSpeek.Click += BtnSpeek_Click;
            // 
            // TxtSpeek
            // 
            TxtSpeek.Location = new Point(10, 21);
            TxtSpeek.Name = "TxtSpeek";
            TxtSpeek.Size = new Size(286, 23);
            TxtSpeek.TabIndex = 3;
            TxtSpeek.Text = "せんごくさんは今日も元気だなあ";
            // 
            // titleBarControl1
            // 
            titleBarControl1.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleBarControl1.Location = new Point(4, 4);
            titleBarControl1.Margin = new Padding(3, 4, 3, 4);
            titleBarControl1.Name = "titleBarControl1";
            titleBarControl1.Size = new Size(792, 30);
            titleBarControl1.TabIndex = 19;
            // 
            // TestForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(PnlFill);
            Controls.Add(titleBarControl1);
            Name = "TestForm";
            Text = "TestForm";
            PnlFill.ResumeLayout(false);
            PnlFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TbSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)TbVolume).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel PnlFill;
        private TextBox TxtSpeek;
        private Button BtnSpeek;
        private TrackBar TbVolume;
        private TrackBar TbSpeed;
        private Label LblSpeed;
        private Label LblVolume;
        private TextBox TxtDiscordKey;
        private Button button1;
        private CheckBox CbDarkMode;
        private MimumuToolkit.CustomControls.RoundButton roundButton2;
        private CheckedListBox checkedListBox1;
        private MimumuToolkit.CustomControls.TitleBarControl titleBarControl1;
    }
}