using MimumuToolkit.Constants;
using MimumuToolkit.CustomControls;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

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
            if (control is RoundButton roundButton)
            {
                level += 2;
                roundButton.ButtonColor = GetDarkColor(level);
            }
            if (control is LinkLabel linkLabel)
            {
                linkLabel.LinkColor = Color.FromArgb(100, 149, 237); // コーンフラワーブルー
                linkLabel.ActiveLinkColor = Color.FromArgb(65, 105, 225); // ロイヤルブルー
                linkLabel.VisitedLinkColor = Color.FromArgb(123, 104, 238); // ミディアムスレートブルー
            }
            else if (control is FlatCheckBox checkBox)
            {
                if (checkBox.Appearance == Appearance.Button && checkBox.FlatStyle == FlatStyle.Flat)
                {
                    level += 2;
                    checkBox.BackColor = GetDarkColor(level);
                }
            }
            else if (control is CustomDataGridView customDataGridView)
            {
                customDataGridView.ApplyDarkMode();
            }
            else
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
                SaveFormLocation(targetForm);
            }
        }


        public static void SaveFormLocation(Form targetForm)
        {
            CommonUtil.SetSetting(string.Format(CommonConstants.AppConfigKeys.LocationXKeyFormat, targetForm.Name), targetForm.Location.X.ToString());
            CommonUtil.SetSetting(string.Format(CommonConstants.AppConfigKeys.LocationYKeyFormat, targetForm.Name), targetForm.Location.Y.ToString());
        }
    }
}
