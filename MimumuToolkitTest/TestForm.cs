using MimumuToolkit;
using MimumuToolkit.Constants;
using MimumuToolkit.CustomControls;
using MimumuToolkit.Dialogs;
using MimumuToolkit.Utilities;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MimumuToolkitTest
{
    public partial class TestForm : CustomForm
    {
        public TestForm()
        {
            InitializeComponent();
            InitializeCommon(TbTitle);

            CbDarkMode.Checked = MimumuToolkitManager.IsDarkModeEnabled;
            TxtDiscordKey.PlaceholderText = "Discord Bot Token";
        }

        private void BtnSpeek_Click(object sender, EventArgs e)
        {
            CommonUtil.SpeakText(TxtSpeek.Text, TbSpeed.Value, TbVolume.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MimumuToolkitManager.ShowNotification("Test Title", "This is a test message.");
        }

        private void CbDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (CbDarkMode.Checked == true)
            {
                MimumuToolkitManager.IsDarkModeEnabled = true;
            }
            else
            {
                MimumuToolkitManager.IsDarkModeEnabled = false;
            }
        }
    }
}
