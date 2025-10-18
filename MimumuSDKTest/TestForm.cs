using MimumuSDK.Constants;
using MimumuSDK.CustomControls;
using MimumuSDK.Utilities;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MimumuSDKTest
{
    public partial class TestForm : CustomForm
    {
        public TestForm()
        {
            InitializeComponent();
            InitializeCommon(TbTitle);
            //SetSizable(this);
            //SetSizable(PnlFill);

            FormUtil.SetDarkMode(this, 2);
            TxtDiscordKey.PlaceholderText = "Discord Bot Token";
        }

        private void BtnSpeek_Click(object sender, EventArgs e)
        {
            CommonUtil.SpeakText(TxtSpeek.Text, TbSpeed.Value, TbVolume.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
