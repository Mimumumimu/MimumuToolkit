using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimumuSDK.CustomControls
{
    public class RoundButton : Button
    {
        private int _cornerRadius = 5; // 角の丸みを小さく
        private Color _borderColor = Color.LightGray; // 薄いグレーの枠線
        private int _borderWidth = 1;
        private Color _buttonColor = Color.White; // ボタンの背景色
        private Color _highlightColor = Color.LightBlue; // ハイライト色

        [Category("Appearance")]
        [Description("ボタンの角の半径")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value;
                Invalidate(); // 再描画を要求
            }
        }

        [Category("Appearance")]
        [Description("ボタンの枠線の色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("ボタンの背景色")]
        [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("ボタンのハイライト色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HighlightColor
        {
            get { return _highlightColor; }
            set
            {
                _highlightColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("ボタンの枠線の太さ")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }

        public RoundButton()
        {
            // ControlStylesを設定して、カスタム描画を有効にする
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.SupportsTransparentBackColor,
                     true);
            BackColor = Color.Transparent; // 背景を透明にする
            ForeColor = Color.Black; // デフォルトの文字色
            FlatAppearance.BorderSize = 0; // 標準のButtonの枠線をなくす
            FlatStyle = FlatStyle.Flat; // FlatStyleをFlatに設定
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // アンチエイリアスを適用して、描画を滑らかにする
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // ボタンの領域を表すRectangleを作成
            Rectangle rect = new Rectangle(0, 0, Width, Height);

            // 角丸のパスを作成
            GraphicsPath path = RoundedRect(rect, _cornerRadius);

            // 背景を描画
            using (Brush backColorBrush = new SolidBrush(ButtonColor))
            {
                e.Graphics.FillPath(backColorBrush, path);
            }

            // マウスオーバー時のハイライト表示
            if (ClientRectangle.Contains(PointToClient(Cursor.Position)))
            {
                using (Brush highlightBrush = new SolidBrush(HighlightColor))
                {
                    e.Graphics.FillPath(highlightBrush, path);
                }
            }

            // 枠線を描画
            if (_borderWidth > 0)
            {
                using (Pen borderPen = new Pen(_borderColor, _borderWidth))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }

            // テキストを描画
            TextRenderer.DrawText(e.Graphics, Text, Font, rect, ForeColor, BackColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }


        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // 左上の弧
            path.AddArc(arc, 180, 90);

            // 右上の弧
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // 右下の弧
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // 左下の弧
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // サイズ変更時に再描画
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate(); // 再描画を要求
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate(); // 再描画を要求
        }
    }
}
