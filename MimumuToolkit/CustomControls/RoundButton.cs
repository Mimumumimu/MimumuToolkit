using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
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
            // 標準の描画ロジックを呼び出す前に、グラフィックスパスをクリッピング領域に設定
            using (GraphicsPath path = GetRoundedPath(this.ClientRectangle, m_cornerRadius))
            {
                // 通常の描画処理を呼び出す
                base.OnPaint(e);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

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
                                                // GraphicsPathの内側かどうかで判定
                        Point mousePos = PointToClient(Cursor.Position);
                        if (path.IsVisible(mousePos))
                        {
                            buttonColor = HighlightColor;
                        }
                        else
                        {
                            buttonColor = ButtonColor;
                        }
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
                // テキスト描画用のRectangleを作成(微調整含む)
                Rectangle rectText = new(1, -1, Width, Height);
                // テキストを描画
                TextRenderer.DrawText(e.Graphics, Text, Font, rectText, ForeColor, buttonColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);

                // 枠線を描画
                if (m_borderWidth > 0)
                {
                    using (Pen borderPen = new Pen(m_borderColor, m_borderWidth + 1))
                    {
                        borderPen.Alignment = PenAlignment.Center;
                        e.Graphics.DrawPath(borderPen, path);
                    }
                }

                this.Region = new Region(path);
            }
        }

        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2F;
            SizeF size = new SizeF(diameter - 1, diameter - 1);

            // パスを枠線の太さ分だけ内側にオフセット
            float offset = m_borderWidth / 2f;
            RectangleF adjustedRect = new RectangleF(
                rect.X + offset,
                rect.Y + offset,
                rect.Width - offset * 2,
                rect.Height - offset * 2);

            RectangleF arc = new(adjustedRect.Location, size);

            // 左上隅
            path.AddArc(arc, 180, 90);

            // 右上隅
            arc.X = adjustedRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // 右下隅
            arc.Y = adjustedRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // 左下隅
            arc.X = adjustedRect.Left;
            path.AddArc(arc, 90, 90);

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
