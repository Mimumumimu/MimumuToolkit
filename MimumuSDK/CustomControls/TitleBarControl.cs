using MimumuSDK.Constants;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MimumuSDK.CustomControls
{
    public partial class TitleBarControl : UserControl
    {
        private Color m_closeButtonBaseForeColor = SystemColors.ControlText;
        private Color m_closeButtonMouseEnterForeColor = Color.FromArgb(250, 238, 237);

        public Button GetCloseButton { get { return BtnClose; } }

        public TitleBarControl()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ParentForm != null)
            {
                LblTitlle.Text = ParentForm.Text;
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            //this.ParentChanged -= TitleBarControl_ParentChanged;
            base.OnHandleDestroyed(e);
        }

        private void TitleBarControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y >= FormConstant.ResizeBorderWidth)
            {
                DragWindow();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            m_closeButtonBaseForeColor = BtnClose.ForeColor;
            BtnClose.ForeColor = m_closeButtonMouseEnterForeColor;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            BtnClose.ForeColor = m_closeButtonBaseForeColor;
        }

        #region マウスドラッグでウィンドウを移動する処理

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        protected void DragWindow()
        {
            if (ParentForm != null)
            {
                ReleaseCapture();
                _ = SendMessage(ParentForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        #endregion


    }
}
