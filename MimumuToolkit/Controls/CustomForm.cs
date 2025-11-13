using MimumuToolkit.Constants;
using MimumuToolkit.Entities;
using MimumuToolkit.Utilities;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MimumuToolkit.Controls
{
    public class CustomForm : Form
    {
        private bool m_hideOnClose = false;
        private bool m_hasBeenShown = false;

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
        /// サイズ変更可否
        /// </summary>
        [Category("Custom")]
        [Description("フォームのサイズ変更を許可するかどうかを設定します。")]
        [DefaultValue(true)]
        public bool Resizable { get; set; } = true;

        /// <summary>
        /// 初回起動時のみフォームを右下に表示するかどうか
        /// </summary>
        [Category("Custom")]
        [Description("初回起動時のみフォームを右下に表示するかどうかを設定します。")]
        [DefaultValue(false)]
        public bool ShowInBottomRightOnce { get; set; } = false;

        [Category("Custom")]
        [Description("フォームの位置をアプリケーション設定に保存し、次回起動時に復元するかどうかを設定します。")]
        [DefaultValue(true)]
        public bool SaveFormLocation { get; set; } = true;

        /// <summary>
        /// フォント プロパティのオーバーライド
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AutoScaleMode AutoScaleMode
        {
            get { return base.AutoScaleMode; }
            set { base.AutoScaleMode = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomForm()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.Font = new Font("BIZ UDゴシック", 12f);
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void CustomShow()
        {
            if (m_hasBeenShown == true)
            {
                this.TopMost = true;
                this.Visible = true;
                this.TopMost = false;
            }
            else
            {
                m_hideOnClose = true;
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (m_hideOnClose == true)
                {
                    this.Visible = false;
                    e.Cancel = true;
                }
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

       protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            m_hasBeenShown = true;
            if (MimumuToolkitManager.IsDarkModeEnabled)
            {
                FormUtil.SetDarkMode(this, 2);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Maximized)
            {
                // 最大化時は上のPaddingをなくす
                base.Padding = new Padding(FormConstants.PaddingSize, 0, FormConstants.PaddingSize, FormConstants.PaddingSize);
            }
            else
            {
                base.Padding = new Padding(FormConstants.PaddingSize);
            }
        }

        /// <summary>
        /// 登録されたタイマーアクションのリスト
        /// </summary>
        private List<Action> m_timerActions = [];

        private bool m_isDisposed = false;
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (m_isDisposed == false)
            {
                foreach (var action in m_timerActions)
                {
                    MimumuToolkitManager.RemoveTimer(action);
                }
                m_timerActions.Clear();

                m_isDisposed = true;
            }
            base.OnHandleDestroyed(e);
        }


        protected void SetTimer(int intervalSeconds, Action action, bool executeFirst = true)
        {
            MimumuToolkitManager.SetTimer(intervalSeconds, action, executeFirst);
            m_timerActions.Add(action);
        }

        public void SetDailyTimer(Action action)
        {
            MimumuToolkitManager.SetDailyTimer(action);
            m_timerActions.Add(action);
        }

        [DllImport("dwmapi.dll")]
        public static extern bool DwmIsCompositionEnabled();
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private const int DWMWA_WINDOW_CORNER_PREFERENCE = 33;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            try
            {
                // ウィンドウの角の丸み具合を設定します 2か3がいい感じに丸くて　3のほうが角ばってる
                int cornerPreference = 2;
                // DWM (Desktop Window Manager) を使用してウィンドウの角を丸くします
                // DWM が利用できない場合は、この処理は効果がありません
                _ = DwmSetWindowAttribute(this.Handle, DWMWA_WINDOW_CORNER_PREFERENCE, ref cornerPreference, sizeof(int));
            }
            catch (Exception ex)
            {
                // 予期しない例外が発生した場合の処理
                Debug.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        private const int WM_NCHITTEST = 0x0084;
        private const int WM_SIZING = 0x0214;
        //private const int HTCLIENT = 0x0001;
        private const int HTLEFT = 0x000A;
        private const int HTRIGHT = 0x000B;
        private const int HTTOP = 0x000C;
        private const int HTTOPLEFT = 0x000D;
        private const int HTTOPRIGHT = 0x000E;
        private const int HTBOTTOM = 0x000F;
        private const int HTBOTTOMLEFT = 0x0010;
        private const int HTBOTTOMRIGHT = 0x0011;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_SIZING)
            {
                HandleWmSizing(ref m);
            }
            else if (m.Msg == WM_NCHITTEST)
            {
                if (Resizable == false || this.WindowState == FormWindowState.Maximized)
                {
                    return;
                }

                // 符号なし整数として座標を取得
                int lParam = m.LParam.ToInt32();
                int x = (short)(lParam & 0xFFFF);
                int y = (short)(lParam >> 16);
                    
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

        private void HandleWmSizing(ref Message m)
        {
            if (Resizable == false || this.WindowState == FormWindowState.Maximized)
            {
                return;
            }

            RECT rect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT))!;
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;

            // MinimumSize をチェック
            if (this.MinimumSize != Size.Empty)
            {
                if (width < this.MinimumSize.Width)
                    rect.Right = rect.Left + this.MinimumSize.Width;
                if (height < this.MinimumSize.Height)
                    rect.Bottom = rect.Top + this.MinimumSize.Height;
            }

            // MaximumSize をチェック
            if (this.MaximumSize != Size.Empty)
            {
                if (width > this.MaximumSize.Width)
                    rect.Right = rect.Left + this.MaximumSize.Width;
                if (height > this.MaximumSize.Height)
                    rect.Bottom = rect.Top + this.MaximumSize.Height;
            }

            Marshal.StructureToPtr(rect, m.LParam, false);
            m.Result = (IntPtr)1; // TRUE: サイズ変更を継続
        }

        private string GetLocationXKey() => string.Format(CommonConstants.AppConfigKeys.LocationXKeyFormat, Name);
        private string GetLocationYKey() => string.Format(CommonConstants.AppConfigKeys.LocationYKeyFormat, Name);

        private void LoadFormLocation()
        {
            if (SaveFormLocation == false)
            {
                return;
            }
            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            try
            {
                // 保存された位置がない場合
                if (CommonUtil.ContainsConfigurationSettingKey(GetLocationXKey()) == false)
                {
                    // 初回起動時のみ右下に表示
                    if (ShowInBottomRightOnce == true)
                    {
                        var primaryScreen = Screen.PrimaryScreen;
                        if (primaryScreen != null)
                        {
                            int locX = primaryScreen.WorkingArea.Width - Width - 10;
                            int locY = primaryScreen.WorkingArea.Height - Height - 10;
                            Location = new Point(locX, locY);
                        }
                    }
                    // 既定の位置で保存
                    FormUtil.SaveFormLocation(this);
                    return;
                }
                int x = CommonUtil.GetIntAppSetting(GetLocationXKey());
                int y = CommonUtil.GetIntAppSetting(GetLocationYKey());

                // 保存された位置がスクリーン内にあるかを検証
                var screen = Screen.FromPoint(new Point(x, y));
                if (screen != null)
                {
                    if (screen.WorkingArea.Contains(x, y) == false)
                    {
                        // 画面外に出ないように位置を調整
                        x = Math.Max(screen.WorkingArea.X, Math.Min(x, screen.WorkingArea.X + screen.WorkingArea.Width - Width));
                        y = Math.Max(screen.WorkingArea.Y, Math.Min(y, screen.WorkingArea.Y + screen.WorkingArea.Height - Height));

                        Location = new Point(x, y);
                        FormUtil.SaveFormLocation(this);
                    }
                    else
                    {
                        Location = new Point(x, y);
                    }
                }
            }
            catch (Exception ex)
            {
                // 設定の読み込みに失敗した場合の処理
                Debug.WriteLine($"Failed to load form location: {ex.Message}");
                // 既定の位置を使用するか、または何もしない
            }
        }
    }
}
