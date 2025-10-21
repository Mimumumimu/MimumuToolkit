namespace MimumuToolkit.CustomControls
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
            LblTitle = new Label();
            BtnClose = new Button();
            SuspendLayout();
            // 
            // LblTitle
            // 
            LblTitle.AutoSize = true;
            LblTitle.BackColor = Color.Transparent;
            LblTitle.Location = new Point(3, 7);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(27, 16);
            LblTitle.TabIndex = 0;
            LblTitle.Text = "title";
            LblTitle.TextAlign = ContentAlignment.MiddleLeft;
            LblTitle.MouseDown += LblTitle_MouseDown;
            // 
            // BtnClose
            // 
            BtnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(199, 64, 49);
            BtnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(218, 62, 68);
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI Variable Display", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnClose.Location = new Point(592, -10);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(30, 38);
            BtnClose.TabIndex = 1;
            BtnClose.Text = "×";
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            BtnClose.MouseEnter += BtnClose_MouseEnter;
            BtnClose.MouseLeave += BtnClose_MouseLeave;
            // 
            // TitleBarControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(LblTitle);
            Controls.Add(BtnClose);
            DoubleBuffered = true;
            Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TitleBarControl";
            Size = new Size(618, 30);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblTitle;
        public Button BtnClose;
    }
}
