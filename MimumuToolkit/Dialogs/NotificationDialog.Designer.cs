namespace MimumuToolkit.Dialogs
{
    partial class NotificationDialog
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
            components = new System.ComponentModel.Container();
            LblTitle = new Label();
            LLblMessage = new LinkLabel();
            TmFlash = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // LblTitle
            // 
            LblTitle.AutoSize = true;
            LblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblTitle.Location = new Point(15, 15);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(73, 15);
            LblTitle.TabIndex = 0;
            LblTitle.Text = "Notification";
            LblTitle.MouseDown += NotificationDialog_MouseDown;
            // 
            // LLblMessage
            // 
            LLblMessage.AutoSize = true;
            LLblMessage.Location = new Point(20, 40);
            LLblMessage.Name = "LLblMessage";
            LLblMessage.Size = new Size(103, 32);
            LLblMessage.TabIndex = 1;
            LLblMessage.TabStop = true;
            LLblMessage.Text = "リマインダー\r\n　19:00 目薬";
            LLblMessage.LinkClicked += LLblMessage_LinkClicked;
            LLblMessage.MouseUp += LLblMessage_MouseUp;
            // 
            // TmFlash
            // 
            TmFlash.Interval = 50;
            TmFlash.Tick += TmFlash_Tick;
            // 
            // NotificationDialog
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(400, 100);
            Controls.Add(LLblMessage);
            Controls.Add(LblTitle);
            Name = "NotificationDialog";
            Resizable = false;
            ShowInBottomRightOnce = true;
            ShowInTaskbar = false;
            Text = "NotificationDialog";
            MouseDown += NotificationDialog_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblTitle;
        private LinkLabel LLblMessage;
        private System.Windows.Forms.Timer TmFlash;
    }
}