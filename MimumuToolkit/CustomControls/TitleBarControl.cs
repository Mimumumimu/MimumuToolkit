using MimumuToolkit.Constants;
using MimumuToolkit.Utilities;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MimumuToolkit.CustomControls
{
    public partial class TitleBarControl : UserControl
    {
        private const int DoubleClickTime = 500; // ミリ秒

        private DateTime m_lastMouseDownTime;
        private Color m_closeButtonBaseForeColor = SystemColors.ControlText;

        /// <summary>
        /// Dock プロパティのオーバーライド
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }

        public TitleBarControl()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ParentForm != null)
            {
                LblTitle.Text = ParentForm.Text;
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }

        private void TitleBarControl_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            m_closeButtonBaseForeColor = BtnClose.ForeColor;
            BtnClose.ForeColor = ColorConstants.CloseButtonMouseEnterForeColor;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            BtnClose.ForeColor = m_closeButtonBaseForeColor;
        }

        #region マウス操作系処理

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            DateTime now = DateTime.Now;
            if ((now - m_lastMouseDownTime).TotalMilliseconds <= DoubleClickTime)
            {
                if (ParentForm != null)
                {
                    if (ParentForm.WindowState == FormWindowState.Normal)
                    {
                        ParentForm.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        ParentForm.WindowState = FormWindowState.Normal;
                    }
                }
                m_lastMouseDownTime = DateTime.MinValue;
            }
            else
            {
                if (ParentForm != null)
                {
                    FormUtil.DragWindow(ParentForm);
                }
                m_lastMouseDownTime = now;
            }
        }

        private void LblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        #endregion
    }
}
