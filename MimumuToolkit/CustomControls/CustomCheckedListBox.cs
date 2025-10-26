using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MimumuToolkit.CustomControls
{
    public class CustomCheckedListBox : CheckedListBox
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDataSetting { get; set; } = false;

        [DefaultValue(true)]
        public new bool CheckOnClick
        {
            get => base.CheckOnClick;
            set => base.CheckOnClick = value;
        }

        public CustomCheckedListBox()
        {
            CheckOnClick = true;
            Items.Clear();
        }

        protected override void OnItemCheck(ItemCheckEventArgs e)
        {
            if (IsDataSetting)
            {
                return;
            }

            // 次の状態に循環させる
            switch (e.CurrentValue)
            {
                case CheckState.Unchecked:
                    e.NewValue = CheckState.Indeterminate;
                    break;
                case CheckState.Indeterminate:
                    e.NewValue = CheckState.Checked;
                    break;
                case CheckState.Checked:
                    e.NewValue = CheckState.Unchecked;
                    break;
            }
            base.OnItemCheck(e);
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int index = IndexFromPoint(e.Location);
            if (index >= 0 && index < Items.Count)
            {
                // 右クリック時に項目を選択状態にする
                if (e.Button == MouseButtons.Right)
                {
                    SelectedIndex = index;
                }
            }
            else
            {
                ClearSelected();
            }

            base.OnMouseDown(e);
        }
    }
}
