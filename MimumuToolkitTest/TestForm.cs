using MimumuToolkit.Constants;
using MimumuToolkit.CustomControls;
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
