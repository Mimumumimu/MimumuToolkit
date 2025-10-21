using MimumuToolkit.Constants;
using MimumuToolkit.Utilities;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace MimumuToolkit.CustomControls
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
        private Padding m_padding = new(FormConstants.PaddingSize);

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
            if (MimumuSDKManager.IsDarkModeEnabled)
            {
                FormUtil.SetDarkMode(this, 2);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            base.Padding = m_padding;
            LoadFormLocation();
        }

        protected void InitializeCommon(TitleBarControl? titleBar = null)
        {
            m_titleBar = titleBar;
            if (m_titleBar != null)
            {
                m_titleBar.GetCloseButton.Click += CloseButtonClicked;
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            SaveFormLocation();
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
        //private int m_resizeBoxSize = 4;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    return;
                }

                // 符号なし整数として座標を取得
                int lParam = m.LParam.ToInt32();
                int x = (short)(lParam & 0xFFFF);
                int y = (short)(lParam >> 16);

                //Point pos = new(x, y);
                //pos = this.PointToClient(pos);

                // クライアント領域のRectangleをスクリーン座標に変換
                Rectangle clientRect = RectangleToScreen(this.ClientRectangle);

                int w = clientRect.Width;
                int h = clientRect.Height;
                int sz = FormConstants.PaddingSize;

                // スクリーン座標をクライアント領域に対する相対座標に変換
                int relativeX = x - clientRect.Left;
                int relativeY = y - clientRect.Top;

                if (relativeX <= sz && relativeY <= sz)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (relativeX >= w - sz && relativeY <= sz)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (relativeX <= sz && relativeY >= h - sz)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (relativeX >= w - sz && relativeY >= h - sz)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (relativeX <= sz)
                    m.Result = (IntPtr)HTLEFT;
                else if (relativeX >= w - sz)
                    m.Result = (IntPtr)HTRIGHT;
                else if (relativeY <= sz)
                    m.Result = (IntPtr)HTTOP;
                else if (relativeY >= h - sz)
                    m.Result = (IntPtr)HTBOTTOM;
            }
        }

        protected void CloseButtonClicked(object? sender, EventArgs e)
        {
            this.Close();
        }

        private string GetLocationXKey() => string.Format(CommonConstants.AppConfigKeys.LocationXKeyFormat, Name);
        private string GetLocationYKey() => string.Format(CommonConstants.AppConfigKeys.LocationYKeyFormat, Name);

        private void LoadFormLocation()
        {
            if (string.IsNullOrEmpty(Name)) return;

            try
            {
                // 保存された位置がない場合
                if (CommonUtil.ContainsConfigurationSettingKey(GetLocationXKey()) == false)
                {
                    // 既定の位置で保存
                    SaveFormLocation();
                    return;
                }
                int x = CommonUtil.GetIntAppSetting(GetLocationXKey());
                int y = CommonUtil.GetIntAppSetting(GetLocationYKey());

                // 画面外に出ている場合
                var screen = Screen.FromPoint(new Point(x, y));
                if (screen == null || screen.WorkingArea.Contains(x, y) == false)
                {
                    // 既定の位置で保存
                    SaveFormLocation();
                    return;
                }

                // 画面外に出ないように位置を調整
                x = Math.Max(screen.WorkingArea.X, Math.Min(x, screen.WorkingArea.X + screen.WorkingArea.Width - Width));
                y = Math.Max(screen.WorkingArea.Y, Math.Min(y, screen.WorkingArea.Y + screen.WorkingArea.Height - Height));

                Location = new Point(x, y);
            }
            catch (Exception ex)
            {
                // 設定の読み込みに失敗した場合の処理
                Debug.WriteLine($"Failed to load form location: {ex.Message}");
                // 既定の位置を使用するか、または何もしない
            }
        }

        private void SaveFormLocation()
        {
            if (string.IsNullOrEmpty(Name)) return;
            try
            {
                CommonUtil.SetSetting(GetLocationXKey(), Location.X.ToString());
                CommonUtil.SetSetting(GetLocationYKey(), Location.Y.ToString());
            }
            catch (Exception ex)
            {
                // 設定の保存に失敗した場合の処理
                Debug.WriteLine($"Failed to save form location: {ex.Message}");
            }
        }
    }
}
