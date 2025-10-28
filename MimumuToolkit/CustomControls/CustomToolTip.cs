using System.ComponentModel;

namespace MimumuToolkit.CustomControls
{
    public class CustomToolTip : ToolTip
    {
        private Color _backColor = Color.FromArgb(45, 45, 48);
        private Color _foreColor = Color.FromArgb(241, 241, 241);
        private Font? _customFont;
        private const int Padding = 4;
        private const int MaxWidth = 300; // 最大幅を制限

        public CustomToolTip()
        {
            InitializeModernStyle();
        }

        private void InitializeModernStyle()
        {
            // モダンなダークテーマを適用
            BackColor = _backColor;
            ForeColor = _foreColor;
            _customFont = new Font("Segoe UI", 12f, FontStyle.Regular);
            OwnerDraw = true;
            Draw += CustomToolTip_Draw;
            Popup += CustomToolTip_Popup;
        }

        private void CustomToolTip_Popup(object? sender, PopupEventArgs e)
        {
            // テキストサイズを計算
            using (var graphics = e.AssociatedControl?.CreateGraphics())
            {
                if (graphics != null && _customFont != null)
                {
                    var textSize = graphics.MeasureString(this.GetToolTip(e.AssociatedControl), _customFont, MaxWidth);
                    
                    // ツールチップのサイズを設定
                    int width = (int)textSize.Width + (Padding * 2);
                    int height = (int)textSize.Height + (Padding * 2);
                    
                    e.ToolTipSize = new Size(
                        Math.Min(width, MaxWidth + (Padding * 2)),
                        height
                    );
                }
            }
        }

        private void CustomToolTip_Draw(object? sender, DrawToolTipEventArgs e)
        {
            // グラデーション背景を描画
            using (var brush = new SolidBrush(_backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // 枠線を描画
            using (var pen = new Pen(Color.FromArgb(100, 100, 100), 1))
            {
                e.Graphics.DrawRectangle(pen, e.Bounds.X, e.Bounds.Y, 
                    e.Bounds.Width - 1, e.Bounds.Height - 1);
            }

            // テキスト描画用の矩形を定義（パディング付き）
            var textRect = new Rectangle(
                e.Bounds.X + Padding, 
                e.Bounds.Y + Padding,
                e.Bounds.Width - (Padding * 2),
                e.Bounds.Height - (Padding * 2)
            );

            // テキストを描画
            using (var brush = new SolidBrush(_foreColor))
            using (var stringFormat = new StringFormat 
            { 
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            })
            {
                e.Graphics.DrawString(e.ToolTipText, _customFont!, 
                    brush, textRect, stringFormat);
            }
        }

        /// <summary>
        /// ツールチップの背景色を取得または設定します。
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                base.BackColor = value;
            }
        }

        /// <summary>
        /// ツールチップの前景色（テキスト色）を取得または設定します。
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get => _foreColor;
            set
            {
                _foreColor = value;
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// ツールチップのフォントを取得または設定します。
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font CustomFont
        {
            get => _customFont ?? throw new InvalidOperationException("CustomFont が null です。");
            set
            {
                _customFont?.Dispose();
                _customFont = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Draw -= CustomToolTip_Draw;
                Popup -= CustomToolTip_Popup;
                _customFont?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
