using System;
using System.Windows.Forms;

namespace MimumuSDKTest
{
    internal static class Program
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ���̍s��ǉ��܂��͊m�F���Ă�������
            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestForm());
        }
    }
}