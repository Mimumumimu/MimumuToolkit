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
        private enum ResizeDirection
        {
            None,
            Left,
            Right,
            Top,
            Bottom,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        }

        private bool m_isResizing = false;
        private ResizeDirection m_resizeDirection;
        private TitleBarControl? m_titleBar = null;
        private List<Control>? m_sizableControls = new List<Control>();

        public CustomForm()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        protected void InitializeCommon(TitleBarControl? titleBar = null)
        {
            m_titleBar = titleBar;
            if (m_titleBar != null)
            {
                m_titleBar.GetCloseButton.Click += CloseButtonClicked;
                SetSizable(m_titleBar.GetCloseButton);
            }
        }

        protected void SetSizable(Control control)
        {
            control.MouseDown += Form_MouseDown;
            control.MouseMove += Form_MouseMove;
            control.MouseUp += Form_MouseUp;
            m_sizableControls?.Add(control);
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
            if (m_sizableControls != null)
            {
                foreach (var control in m_sizableControls)
                {
                    if (control != null)
                    {
                        control.MouseDown -= Form_MouseDown;
                        control.MouseMove -= Form_MouseMove;
                        control.MouseUp -= Form_MouseUp;
                    }
                }
                m_sizableControls.Clear();
                m_sizableControls = null;
            }
        }

        private void C_MouseDown(object? sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // ちらつきを抑える
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected void CloseButtonClicked(object? sender, EventArgs e)
        {
            if (m_isResizing == true)
            {
                return;
            }
            this.Close();
        }

        protected void Form_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && m_resizeDirection != ResizeDirection.None)
            {
                m_isResizing = true;
            }
        }

        protected void Form_MouseUp(object? sender, MouseEventArgs e)
        {
            m_isResizing = false;
        }

        protected void Form_MouseMove(object? sender, MouseEventArgs e)
        {
            // 送信元のコントロールと、そのコントロール上でのマウス座標を取得
            Control control = (Control)sender!;
            Point controlClientPoint = e.Location;
            // フォーム全体のクライアント座標に変換
            Point formClientPoint = this.PointToClient(control.PointToScreen(controlClientPoint));

            if (m_isResizing)
            {
                // リサイズ処理
                Point screenPoint = control.PointToScreen(controlClientPoint);
                int newX = this.Left;
                int newY = this.Top;
                int newWidth = this.Width;
                int newHeight = this.Height;

                // 右辺・下辺の計算
                if (m_resizeDirection.ToString().Contains("Right"))
                {
                    newWidth = screenPoint.X - this.Left;
                }
                if (m_resizeDirection.ToString().Contains("Bottom"))
                {
                    newHeight = screenPoint.Y - this.Top;
                }
                // 左辺・上辺の計算
                if (m_resizeDirection.ToString().Contains("Left"))
                {
                    newWidth = this.Right - screenPoint.X;
                    newX = screenPoint.X;
                }
                if (m_resizeDirection.ToString().Contains("Top"))
                {
                    newHeight = this.Bottom - screenPoint.Y;
                    newY = screenPoint.Y;
                }

                this.SetBounds(newX, newY, newWidth, newHeight);
            }
            else
            {
                // カーソル変更処理
                bool onLeft = formClientPoint.X < FormConstant.ResizeBorderWidth;
                bool onRight = formClientPoint.X > this.ClientSize.Width - FormConstant.ResizeBorderWidth;
                bool onTop = formClientPoint.Y < FormConstant.ResizeBorderWidth;
                bool onBottom = formClientPoint.Y > this.ClientSize.Height - FormConstant.ResizeBorderWidth;

                if (onTop && onLeft) m_resizeDirection = ResizeDirection.TopLeft;
                else if (onTop && onRight) m_resizeDirection = ResizeDirection.TopRight;
                else if (onBottom && onLeft) m_resizeDirection = ResizeDirection.BottomLeft;
                else if (onBottom && onRight) m_resizeDirection = ResizeDirection.BottomRight;
                else if (onLeft) m_resizeDirection = ResizeDirection.Left;
                else if (onRight) m_resizeDirection = ResizeDirection.Right;
                else if (onTop) m_resizeDirection = ResizeDirection.Top;
                else if (onBottom) m_resizeDirection = ResizeDirection.Bottom;
                else m_resizeDirection = ResizeDirection.None;

                switch (m_resizeDirection)
                {
                    case ResizeDirection.TopLeft:
                    case ResizeDirection.BottomRight:
                        this.Cursor = Cursors.SizeNWSE;
                        break;
                    case ResizeDirection.TopRight:
                    case ResizeDirection.BottomLeft:
                        this.Cursor = Cursors.SizeNESW;
                        break;
                    case ResizeDirection.Left:
                    case ResizeDirection.Right:
                        this.Cursor = Cursors.SizeWE;
                        break;
                    case ResizeDirection.Top:
                    case ResizeDirection.Bottom:
                        this.Cursor = Cursors.SizeNS;
                        break;
                    default:
                        this.Cursor = Cursors.Default;
                        break;
                }
            }
        }

    }
}
