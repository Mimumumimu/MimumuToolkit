using MimumuToolkit.CustomControls;
using MimumuToolkit.Entities;
using MimumuToolkit.Utilities;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace MimumuToolkit.Dialogs
{
    public partial class NotificationDialog : CustomForm
    {
        private Color m_originalBackColor;
        private string m_speakMessage = string.Empty;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get { return LblTitle.Text; }
            set { LblTitle.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message
        {
            get { return LLblMessage.Text; }
            set { LLblMessage.Text = value; }
        }

        public NotificationDialog()
        {
            InitializeComponent();
        }

        private void LLblMessage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link?.LinkData == null)
            {
                return;
            }
            CommonUtil.ProcessStart(e.Link.LinkData.ToString());
        }

        private void TmFlash_Tick(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Yellow)
            {
                this.BackColor = m_originalBackColor;
            }
            else
            {
                this.BackColor = Color.Yellow;
            }
        }

        public void ShowNotification(List<LinkEntity> links)
        {
            // 現在の位置とサイズを保存
            Point originalLocation = this.Location;
            Size originalSize = this.Size;

            LLblMessage.Links.Clear();

            StringBuilder sb = new();
            StringBuilder sbSpeak = new();
            int currentPos = 0;
            string lineBreak = "\n";
            foreach (var linkInfo in links)
            {
                string linkValue = string.Format("{0}{1}　{2}{1}", linkInfo.Title, lineBreak, linkInfo.Remarks);
                sb.Append(linkValue);

                if (sbSpeak.Length > 0)
                {
                    sbSpeak.Append("、続いて、");
                }
                sbSpeak.Append(linkInfo.Title);

                //LinkLabel.Linkを作成して追加
                LinkLabel.Link link = new(currentPos, linkInfo.Title.Length)
                {
                    LinkData = linkInfo.Url
                };
                LLblMessage.Links.Add(link);

                currentPos += linkValue.Length;
            }
            LLblMessage.Text = sb.ToString();
            m_speakMessage = sbSpeak.ToString();

            // テキストのサイズを測定してフォームの高さを調整する
            using (Graphics g = this.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(LLblMessage.Text, LLblMessage.Font, LLblMessage.Width);
                int lineCount = (int)Math.Ceiling(textSize.Height / LLblMessage.Font.GetHeight(g));

                // 行数に基づいてフォームの高さを調整する
                if (lineCount > 3)
                {
                    // フォントの高さを取得
                    float fontHeight = LLblMessage.Font.GetHeight();

                    // 必要な追加の高さを計算
                    int additionalHeight = (int)((lineCount - 3) * fontHeight);
                    // 基本の高さ100に加算
                    this.Height = 100 + additionalHeight;
                }
                else
                {
                    this.Height = 100;
                }
            }

            // サイズの差分を計算
            int deltaWidth = this.Width - originalSize.Width;
            int deltaHeight = this.Height - originalSize.Height;

            // 位置を調整 (上に伸びるように)
            this.Location = new Point(originalLocation.X - deltaWidth, originalLocation.Y - deltaHeight);

            this.TopMost = true;
            this.Visible = true;
            this.TopMost = false;
            if (MimumuToolkitManager.IsNotificationSoundEnabled == true)
            {
                CommonUtil.SpeakText(m_speakMessage, volume: 50);
            }
            FlashForm();
        }

        private async void FlashForm()
        {
            m_originalBackColor = this.BackColor;
            TmFlash.Start();
            await Task.Delay(300);
            TmFlash.Stop();
            this.BackColor = m_originalBackColor;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }

            return;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

        }

        private void NotificationDialog_MouseDown(object sender, MouseEventArgs e)
        {
            Point initialLocation = new(this.Location.X, this.Location.Y);
            FormUtil.DragWindow(this);
            SaveFormLocation();
            if (initialLocation.X == this.Location.X &&
                initialLocation.Y == this.Location.Y)
            {
                Close();
            }
        }

        private void LLblMessage_MouseUp(object sender, MouseEventArgs e)
        {
            NotificationDialog_MouseDown(sender, e);
        }
    }
}
