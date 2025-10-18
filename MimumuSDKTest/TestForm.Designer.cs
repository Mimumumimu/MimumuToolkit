namespace MimumuSDKTest
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
            TbTitle = new MimumuSDK.CustomControls.TitleBarControl();
            PnlFill = new Panel();
            button1 = new Button();
            TxtDiscordKey = new TextBox();
            TbSpeed = new TrackBar();
            LblSpeed = new Label();
            LblVolume = new Label();
            TbVolume = new TrackBar();
            BtnSpeek = new Button();
            TxtSpeek = new TextBox();
            PnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TbSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TbVolume).BeginInit();
            SuspendLayout();
            // 
            // TbTitle
            // 
            TbTitle.Dock = DockStyle.Top;
            TbTitle.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TbTitle.Location = new Point(4, 4);
            TbTitle.Margin = new Padding(3, 4, 3, 4);
            TbTitle.Name = "TbTitle";
            TbTitle.Size = new Size(792, 30);
            TbTitle.TabIndex = 0;
            // 
            // PnlFill
            // 
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
            // button1
            // 
            button1.Location = new Point(12, 140);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TxtDiscordKey
            // 
            TxtDiscordKey.Location = new Point(12, 105);
            TxtDiscordKey.Name = "TxtDiscordKey";
            TxtDiscordKey.Size = new Size(304, 29);
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
            LblSpeed.Size = new Size(53, 21);
            LblSpeed.TabIndex = 8;
            LblSpeed.Text = "Speed";
            // 
            // LblVolume
            // 
            LblVolume.AutoSize = true;
            LblVolume.Location = new Point(302, 24);
            LblVolume.Name = "LblVolume";
            LblVolume.Size = new Size(63, 21);
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
            TxtSpeek.Size = new Size(286, 29);
            TxtSpeek.TabIndex = 3;
            TxtSpeek.Text = "せんごくさんは今日も元気だなあ";
            // 
            // TestForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(PnlFill);
            Controls.Add(TbTitle);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TestForm";
            Text = "TestForm";
            PnlFill.ResumeLayout(false);
            PnlFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TbSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)TbVolume).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MimumuSDK.CustomControls.TitleBarControl TbTitle;
        private Panel PnlFill;
        private TextBox TxtSpeek;
        private Button BtnSpeek;
        private TrackBar TbVolume;
        private TrackBar TbSpeed;
        private Label LblSpeed;
        private Label LblVolume;
        private TextBox TxtDiscordKey;
        private Button button1;
    }
}