using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MimumuToolkit.Controls
{
    public class CustomDataGridView : DataGridView
    {
        // デザインプロパティ
        private Color m_headerBackColor = Color.FromArgb(245, 245, 245);
        private Color m_headerForeColor = Color.FromArgb(50, 50, 50);
        private Color m_gridLineColor = Color.FromArgb(230, 230, 230);
        private Color m_rowBackColor = Color.White;
        private Color m_rowForeColor = Color.FromArgb(50, 50, 50);
        private Color m_selectionBackColor = Color.FromArgb(200, 225, 255);
        private Color m_selectionForeColor = Color.FromArgb(50, 50, 50);
        private int m_rowHeight = 32;

        [Category("Appearance")]
        [Description("ヘッダーの背景色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HeaderBackColor
        {
            get { return m_headerBackColor; }
            set
            {
                m_headerBackColor = value;
                ApplyHeaderStyle();
            }
        }

        [Category("Appearance")]
        [Description("ヘッダーの文字色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HeaderForeColor
        {
            get { return m_headerForeColor; }
            set
            {
                m_headerForeColor = value;
                ApplyHeaderStyle();
            }
        }

        [Category("Appearance")]
        [Description("グリッド線の色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GridLineColor
        {
            get { return m_gridLineColor; }
            set
            {
                m_gridLineColor = value;
                GridColor = value;
            }
        }

        [Category("Appearance")]
        [Description("行の背景色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color RowBackColor
        {
            get { return m_rowBackColor; }
            set
            {
                m_rowBackColor = value;
                ApplyRowStyle();
            }
        }

        [Category("Appearance")]
        [Description("行の文字色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color RowForeColor
        {
            get { return m_rowForeColor; }
            set
            {
                m_rowForeColor = value;
                ApplyRowStyle();
            }
        }

        [Category("Appearance")]
        [Description("選択時（ホバー時）の背景色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectionBackColor
        {
            get { return m_selectionBackColor; }
            set
            {
                m_selectionBackColor = value;
                ApplyRowStyle();
            }
        }

        [Category("Appearance")]
        [Description("選択時（ホバー時）の文字色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectionForeColor
        {
            get { return m_selectionForeColor; }
            set
            {
                m_selectionForeColor = value;
                ApplyRowStyle();
            }
        }

        [Category("Appearance")]
        [Description("行の高さ（ピクセル）")]
        [Browsable(true)]
        [DefaultValue(32)]
        public int RowHeight
        {
            get { return m_rowHeight; }
            set
            {
                m_rowHeight = value;
                RowTemplate.Height = value;
                ColumnHeadersHeight = value + 8;
            }
        }

        ///// <summary>
        ///// 行の自動サイズ調整モード
        ///// </summary>
        //[Category("Appearance")]
        //[Description("行の自動サイズ調整モード")]
        //[Browsable(true)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public new DataGridViewAutoSizeRowsMode AutoSizeRowsMode
        //{
        //    get { return base.AutoSizeRowsMode; }
        //    set { base.AutoSizeRowsMode = value; }
        //}

        public CustomDataGridView()
        {
            InitializeStyle();
            ApplyModernStyle();
        }

        private void InitializeStyle()
        {
            EnableHeadersVisualStyles = false;
            AutoGenerateColumns = false;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            RowHeadersVisible = false;
            BorderStyle = BorderStyle.None;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MultiSelect = false;
            ReadOnly = true;
            DoubleBuffered = true;

            // グリッド線設定：全ての縦線を完全に消す
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            // セルのボーダースタイル設定：横線のみ
            DataGridViewCellBorderStyle cellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.CellBorderStyle = cellBorderStyle;
        }

        private void ApplyModernStyle()
        {
            ApplyHeaderStyle();
            ApplyRowStyle();
            this.BackgroundColor = m_rowBackColor;
            // ヘッダー下部の線を濃くする
            this.GridColor = m_gridLineColor;
        }

        private void ApplyHeaderStyle()
        {
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = m_headerBackColor,
                ForeColor = m_headerForeColor,
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                WrapMode = DataGridViewTriState.False,
                Padding = new Padding(8, 6, 8, 6)
            };
            ColumnHeadersHeight = m_rowHeight + 8;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            
            // ヘッダーのボーダースタイルを明示的に None に設定
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }

        private void ApplyRowStyle()
        {
            DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = m_rowBackColor,
                ForeColor = m_rowForeColor,
                SelectionBackColor = m_selectionBackColor,
                SelectionForeColor = m_selectionForeColor,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                WrapMode = DataGridViewTriState.False,
                Padding = new Padding(0, 0, 0, 0)
            };
            RowTemplate.Height = m_rowHeight;
        }

        /// <summary>
        /// ダークモード対応の色を設定します
        /// </summary>
        public void ApplyDarkMode()
        {
            m_headerBackColor = Color.FromArgb(45, 45, 45);
            m_headerForeColor = Color.FromArgb(220, 220, 220);
            m_gridLineColor = Color.FromArgb(80, 80, 80);
            m_rowBackColor = Color.FromArgb(37, 37, 37);
            m_rowForeColor = Color.FromArgb(220, 220, 220);
            m_selectionBackColor = Color.FromArgb(51, 102, 204);
            m_selectionForeColor = Color.FromArgb(220, 220, 220);

            ApplyModernStyle();
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (e.Graphics == null)
            {
                base.OnCellPainting(e);
                return;
            }

            // ヘッダー行の場合
            if (e.RowIndex == -1)
            {
                using (Brush headerBrush = new SolidBrush(m_headerBackColor))
                {
                    e.Graphics.FillRectangle(headerBrush, e.CellBounds);
                }

                // 列の配置設定を反映させる
                StringAlignment alignment = this.Columns[e.ColumnIndex].HeaderCell.Style.Alignment switch
                {
                    DataGridViewContentAlignment.MiddleCenter => StringAlignment.Center,
                    DataGridViewContentAlignment.MiddleRight => StringAlignment.Far,
                    _ => StringAlignment.Near
                };

                using (StringFormat sf = new StringFormat
                {
                    Alignment = alignment,
                    LineAlignment = StringAlignment.Center
                })
                {
                    e.Graphics.DrawString(
                        e.Value?.ToString() ?? string.Empty,
                        ColumnHeadersDefaultCellStyle.Font ?? this.Font,
                        new SolidBrush(m_headerForeColor),
                        e.CellBounds,
                        sf);
                }

                e.Handled = true;
            }
            else
            {
                base.OnCellPainting(e);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var hitTestInfo = this.HitTest(e.X, e.Y);

                // セル外をクリックした場合は選択をクリア
                if (hitTestInfo.ColumnIndex < 0 && hitTestInfo.RowIndex < 0)
                {
                    this.ClearSelection();
                    this.CurrentCell = null;
                }
            }

            base.OnMouseClick(e);
        }
    }
}
