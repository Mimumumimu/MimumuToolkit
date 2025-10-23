using MimumuToolkit;
using MimumuToolkit.Constants;
using MimumuToolkit.CustomControls;
using MimumuToolkit.Dialogs;
using MimumuToolkit.Entities;
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
            MimumuToolkitManager.SetTimer(30, ShowTest);

        }

        bool a = true;
        private void ShowTest()
        {
            if (a)
            {
                MimumuToolkitManager.ShowNotification("あああ");
                a = false;
            }
            else
            {
                List<LinkEntity> links =
                [
                    new LinkEntity("Google", "https://www.google.com", "検索エンジンの大手"),
                    new LinkEntity("Yahoo!", "https://www.yahoo.co.jp", "日本で人気のポータルサイト"),
                    new LinkEntity("Bing", "https://www.bing.com", "Microsoftの検索エンジン"),
                    new LinkEntity("DuckDuckGo", "https://duckduckgo.com", "プライバシー重視の検索エンジン"),
                ];
                MimumuToolkitManager.ShowNotification(links);
                a = true;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            MimumuToolkitManager.RemoveTimer(ShowTest);
        }
    }
}
