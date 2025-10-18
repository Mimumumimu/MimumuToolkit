using Accessibility;
using MimumuSDK.Constants;
using MimumuSDK.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MimumuSDK.CustomControls
{
    public class CustomForm : Form
    {
        /// <summary>
        /// タイトルバーのコントロール
        /// </summary>
        private TitleBarControl? m_titleBar = null;

        /// <summary>
        /// Padding の値
        /// </summary>
        private Padding m_padding = new(4);

        /// <summary>
        /// Padding プロパティのオーバーライド
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get { return m_padding; }
            set { m_padding = value; base.Padding = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomForm()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            base.Padding = m_padding;
        }

        protected void InitializeCommon(TitleBarControl? titleBar = null)
        {
            m_titleBar = titleBar;
            if (m_titleBar != null)
            {
                m_titleBar.GetCloseButton.Click += CloseButtonClicked;
                //SetSizable(m_titleBar.GetCloseButton);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            // イベントのサブスクリプションを解除
            if (m_titleBar != null)
            {
                m_titleBar.GetCloseButton.Click -= CloseButtonClicked;
                m_titleBar = null;
            }
        }


        [DllImport("dwmapi.dll")]
        public static extern bool DwmIsCompositionEnabled();
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private const int DWMWCP_ROUND = 3;
        private const int DWMWA_WINDOW_CORNER_PREFERENCE = 33;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            try
            {
                // DWM が利用可能かどうかを間接的に確認
                int cornerPreference = DWMWCP_ROUND;
                // ウィンドウの角を丸くする
                _ = DwmSetWindowAttribute(this.Handle, DWMWA_WINDOW_CORNER_PREFERENCE, ref cornerPreference, sizeof(int));
            }
            catch (Exception ex)
            {
                // 予期しない例外が発生した場合の処理
                Debug.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        private const int WM_NCHITTEST = 0x0084;
        //private const int HTCLIENT = 0x0001;
        private const int HTLEFT = 0x000A;
        private const int HTRIGHT = 0x000B;
        private const int HTTOP = 0x000C;
        private const int HTTOPLEFT = 0x000D;
        private const int HTTOPRIGHT = 0x000E;
        private const int HTBOTTOM = 0x000F;
        private const int HTBOTTOMLEFT = 0x0010;
        private const int HTBOTTOMRIGHT = 0x0011;
        private int m_resizeBoxSize = 10;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                Point pos = new Point(m.LParam.ToInt32() & 0xFFFF, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);

                int w = this.ClientSize.Width;
                int h = this.ClientSize.Height;
                int x = pos.X;
                int y = pos.Y;
                int sz = m_resizeBoxSize;

                if (x <= sz && y <= sz)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (x >= w - sz && y <= sz)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (x <= sz && y >= h - sz)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (x >= w - sz && y >= h - sz)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (x <= sz)
                    m.Result = (IntPtr)HTLEFT;
                else if (x >= w - sz)
                    m.Result = (IntPtr)HTRIGHT;
                else if (y <= sz)
                    m.Result = (IntPtr)HTTOP;
                else if (y >= h - sz)
                    m.Result = (IntPtr)HTBOTTOM;
            }
        }

        protected void CloseButtonClicked(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
