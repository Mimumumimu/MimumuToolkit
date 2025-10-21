using System.Runtime.InteropServices;

namespace MimumuToolkit.Utilities
{
    public class FormUtil
    {
        private static readonly Color DarkModeForeColor = Color.FromArgb(220, 220, 220);

        public static void SetDarkMode(Form form, int level)
        {
            form.BackColor = GetDarkColor(level);
            form.ForeColor = DarkModeForeColor;
            foreach (Control control in form.Controls)
            {
                SetDarkMode(control, level);
            }
        }

        public static void SetDarkMode(Control control, int level)
        {
            if (control.BackColor != Color.Transparent)
            {
                if (control is Button btn)
                {
                    if (IsCloseButton(control) == true)
                    {
                        control.BackColor = GetDarkColor(level);
                        btn.FlatAppearance.BorderColor = control.BackColor;
                    }
                    else
                    {
                        level += 2;
                        control.BackColor = GetDarkColor(level);
                    }
                }
                else
                {
                    if (control.BackColor != GetDarkColor(level))
                    {
                        level += 2;
                        control.BackColor = GetDarkColor(level);
                    }
                }
            }
            control.ForeColor = DarkModeForeColor;

            foreach (Control childControl in control.Controls)
            {
                SetDarkMode(childControl, level);
            }
        }

        private static bool IsCloseButton(Control control)
        {
            return control is Button btn && (btn.Name == "BtnClose" || btn.Text == "×");
        }

        public static Color GetDarkColor(int level)
        {
            if (level < 0)
            {
                level = 0;
            }

            int rgbValue = 15 * level;
            if (rgbValue > 255)
            {
                rgbValue = 255;
            }

            return Color.FromArgb(rgbValue, rgbValue, rgbValue);
        }

        // マウスドラッグでウィンドウを移動する処理
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public static void DragWindow(Form targetForm)
        {
            if (targetForm != null)
            {
                ReleaseCapture();
                _ = SendMessage(targetForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
