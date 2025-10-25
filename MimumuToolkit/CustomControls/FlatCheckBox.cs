using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimumuToolkit.CustomControls
{
    public class FlatCheckBox : CheckBox
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Appearance Appearance
        {
            get => base.Appearance;
            set => base.Appearance = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FlatStyle FlatStyle
        {
            get => base.FlatStyle;
            set => base.FlatStyle = value;
        }

        public FlatCheckBox()
        {
            Appearance = Appearance.Button;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.LightGray;
            FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 165, 245);
            FlatAppearance.MouseDownBackColor = Color.FromArgb(66, 135, 245);
            FlatAppearance.CheckedBackColor = Color.FromArgb(66, 135, 245);
            TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
