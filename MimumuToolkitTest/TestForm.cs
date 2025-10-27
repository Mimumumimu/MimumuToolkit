
using MimumuReminderDialog.Dialogs;
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

            CbDarkMode.Checked = MimumuToolkitManager.IsDarkModeEnabled;
            TxtDiscordKey.PlaceholderText = "Discord Bot Token";
        }

        private void BtnSpeek_Click(object sender, EventArgs e)
        {
            CommonUtil.SpeakText(TxtSpeek.Text, TbSpeed.Value, TbVolume.Value);
        }



        ReminderDialog dialog = new ReminderDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            //MimumuToolkitManager.SetTimer(5, ShowTest);
            
            dialog.Show();

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
                List<LinkEntity> links = CommonUtil.LoadFromJsonFile<List<LinkEntity>>("links.json") ?? [];
                if (links.Count == 0)
                {
                    links.Add(new LinkEntity("Google", "https://www.google.com", "検索エンジンの大手"));
                    links.Add(new LinkEntity("Yahoo!", "https://www.yahoo.co.jp", "日本で人気のポータルサイト"));
                    links.Add(new LinkEntity("Bing", "https://www.bing.com", "Microsoftの検索エンジン"));
                    links.Add(new LinkEntity("DuckDuckGo", "https://duckduckgo.com", "プライバシー重視の検索エンジン"));
                }

                MimumuToolkitManager.ShowNotification(links);
                a = true;


                CommonUtil.SaveToJsonFile(links, "links.json");
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
