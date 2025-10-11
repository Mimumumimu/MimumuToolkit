namespace MimumuSDK.CustomControls
{
    partial class TitleBarControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            LblTitlle = new Label();
            BtnClose = new Button();
            SuspendLayout();
            // 
            // LblTitlle
            // 
            LblTitlle.AutoSize = true;
            LblTitlle.Location = new Point(3, 7);
            LblTitlle.Name = "LblTitlle";
            LblTitlle.Size = new Size(27, 16);
            LblTitlle.TabIndex = 0;
            LblTitlle.Text = "title";
            LblTitlle.TextAlign = ContentAlignment.MiddleLeft;
            LblTitlle.MouseDown += TitleBarControl_MouseDown;
            // 
            // BtnClose
            // 
            BtnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            BtnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI Variable Display", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnClose.Location = new Point(588, -9);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(30, 40);
            BtnClose.TabIndex = 1;
            BtnClose.Text = "×";
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.MouseDown += BtnClose_MouseDown;
            BtnClose.MouseMove += BtnClose_MouseMove;
            BtnClose.MouseUp += BtnClose_MouseUp;
            // 
            // TitleBarControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(LblTitlle);
            Controls.Add(BtnClose);
            DoubleBuffered = true;
            Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TitleBarControl";
            Size = new Size(618, 30);
            MouseDown += TitleBarControl_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblTitlle;
        public Button BtnClose;
    }
}
