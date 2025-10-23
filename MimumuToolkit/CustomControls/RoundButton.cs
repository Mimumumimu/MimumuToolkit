using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimumuToolkit.CustomControls
{
    public class RoundButton : Button
    {
        // 角の丸みを小さく
        private int m_cornerRadius = 5;
        private int m_borderWidth = 1;
        // 薄いグレーの枠線
        private Color m_borderColor = Color.LightGray;
        // ボタンの背景色
        private Color m_buttonColor = Color.FromArgb(144, 202, 249);
        // ハイライト色
        private Color m_highlightColor = Color.FromArgb(66, 165, 245);
        // クリック時の色
        private Color m_clickColor = Color.FromArgb(66, 135, 245);
        private bool m_isClicked = false;

        [Category("Appearance")]
        [Description("ボタンの角の半径")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get { return m_cornerRadius; }
            set
            {
                m_cornerRadius = value;
                // 再描画を要求
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("ボタンの枠線の色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get { return m_borderColor; }
            set
            {
                m_borderColor = value;
                // 再描画を要求
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("ボタンの背景色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ButtonColor
        {
            get { return m_buttonColor; }
            set
            {
                m_buttonColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("ボタンのハイライト色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HighlightColor
        {
            get { return m_highlightColor; }
            set
            {
                m_highlightColor = value;
                // 再描画を要求
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("ボタンのクリック時の色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ClickColor
        {
            get { return m_clickColor; }
            set
            {
                m_clickColor = value;
                // 再描画を要求
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("ボタンの枠線の太さ")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderWidth
        {
            get { return m_borderWidth; }
            set
            {
                m_borderWidth = value;
                // 再描画を要求
                Invalidate();
            }
        }

        private Control? m_parentControl;

        [Category("Appearance")]
        [Description("背景色を同期するControl")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Control? ParentControl
        {
            get { return m_parentControl; }
            set
            {
                m_parentControl = value;
                // 再描画を要求
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
            Rectangle rect = new(-1, -1, Width + 1, Height + 1);
            // テキスト描画用のRectangleを作成(微調整含む)
            Rectangle rectText = new(1, -1, Width, Height);

            // TargetControl が設定されている場合は、その背景色を取得
            Color controlBackColor = ParentControl?.BackColor ?? this.BackColor;

            // 背景を塗りつぶす
            using (Brush backColorBrush = new SolidBrush(controlBackColor))
            {
                e.Graphics.FillRectangle(backColorBrush, rect);
            }

            // 角丸のパスを作成
            GraphicsPath path = RoundedRect(rect, m_cornerRadius);

            // ボタンの色を描画
            Color buttonColor;
            {
                // マウスオーバー時のハイライト表示
                if (m_isClicked)
                {
                    buttonColor = ClickColor;
                }
                else if (ClientRectangle.Contains(PointToClient(Cursor.Position)))
                {
                    buttonColor = HighlightColor;
                }
                else
                {
                    buttonColor = ButtonColor;
                }
                using (Brush buttonColorBrush = new SolidBrush(buttonColor))
                {
                    e.Graphics.FillPath(buttonColorBrush, path);
                }
            }

            // テキストを描画
            TextRenderer.DrawText(e.Graphics, Text, Font, rectText, ForeColor, buttonColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);

            // 枠線を描画
            if (m_borderWidth > 0)
            {
                using (Pen borderPen = new Pen(m_borderColor, m_borderWidth))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
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

            // わずかなオフセット
            int offset = 1;

            // 左上の弧
            path.AddArc(arc.X + offset, arc.Y + offset, diameter, diameter, 180, 90);

            // 右上の弧
            arc.X = bounds.Right - diameter - offset;
            path.AddArc(arc.X, arc.Y + offset, diameter, diameter, 270, 90);

            // 右下の弧
            arc.Y = bounds.Bottom - diameter - offset;
            path.AddArc(arc.X, arc.Y, diameter, diameter, 0, 90);

            // 左下の弧
            arc.X = bounds.Left + offset;
            path.AddArc(arc.X, arc.Y, diameter, diameter, 90, 90);

            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // 再描画を要求
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            // 再描画を要求
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            // 再描画を要求
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            m_isClicked = true;
            // 再描画を要求
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            m_isClicked = false;
            // 再描画を要求
            Invalidate();
        }
    }
}
