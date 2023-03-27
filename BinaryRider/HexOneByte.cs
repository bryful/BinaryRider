using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRider
{
	public partial class HexOneByte : Control
	{
		public delegate void PlusedEventHandler(object sender, EventArgs e);
		public event PlusedEventHandler? Plused = null;
		protected virtual void OnPlused(EventArgs e)
		{
			if (Plused != null)
			{
				Plused(this, e);
			}
		}
		public delegate void MinusedEventHandler(object sender, EventArgs e);
		public event MinusedEventHandler? Minused = null;
		protected virtual void OnMinused(EventArgs e)
		{
			if (Minused != null)
			{
				Minused(this, e);
			}
		}

		// *****************************************************
		static public readonly int TopBottomHeight = 6;
		private int m_Height = 32;
		private int m_HeightMid = 20;
		private int m_Width = 20;
		public void SetCharSize(int w, int h)
		{
			m_Width = w;
			m_HeightMid = h;
			m_Height = h + TopBottomHeight * 2;
			this.Size = new Size(m_Width, m_Height);
		}
		private StringFormat m_Format = new StringFormat();
		public StringAlignment Alignment
		{
			get { return m_Format.Alignment; }
			set { m_Format.Alignment = value; }
		}
		private byte m_Value = 0;
		public byte Value
		{
			get { return m_Value; }
			set
			{
				m_Value = value;
				if (m_Value > 0xF)
				{
					m_Value = 0xF;
				}
				this.Invalidate();
			}

		}
		public long AddValue { get; set; } = 0;
		private Color m_BackColorMid = SystemColors.Control;
		public Color BackColorMid
		{
			get { return m_BackColorMid; }
			set
			{
				m_BackColorMid = value;
				Invalidate();
			}
		}
		public HexOneByte()
		{
			this.TabStop = false;
			SetCharSize(12, 20);
			m_Format.Alignment = StringAlignment.Center;
			m_Format.LineAlignment = StringAlignment.Center;
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
			this.BackColor = Color.Transparent;
			this.ForeColor = SystemColors.ControlText;
			this.UpdateStyles();
			this.Invalidate();

		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			using (SolidBrush sb = new SolidBrush(m_BackColorMid))
			using (Pen p = new Pen(this.ForeColor))
			{
				//透明
				sb.Color = m_BackColorMid;
				g.FillRectangle(sb, new Rectangle(0,0,this.Width,this.Height));

				Rectangle r = new Rectangle(0, TopBottomHeight, this.Width, m_HeightMid);
				sb.Color = BackColor;
				g.FillRectangle(sb, r);

				sb.Color = ForeColor;
				g.DrawString($"{m_Value:X}", this.Font, sb, r,m_Format);
				if (HexUpDown != 0)
				{
					Point[] pnts = new Point[3];
					if (HexUpDown > 0)
					{
						pnts[0] = new Point(0, TopBottomHeight);
						pnts[1] = new Point(m_Width/2, 0);
						pnts[2] = new Point(m_Width, TopBottomHeight);
					}
					else
					{
						int hh = TopBottomHeight + m_HeightMid;
						pnts[0] = new Point(0, hh);
						pnts[1] = new Point(m_Width / 2, m_Height);
						pnts[2] = new Point(m_Width, hh);
					}
					g.FillPolygon(sb, pnts);
				}

			}
		}
		private bool MDent = false;
		private int HexUpDown = 0;
		protected override void OnMouseEnter(EventArgs e)
		{
			MDent = true;
			this.Invalidate();
			base.OnMouseEnter(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (MDent)
			{
				int y = 0;
				if (e.Y < TopBottomHeight * 2)
				{
					y = +1;
				}
				else if (e.Y > -TopBottomHeight*2 + m_Height)
				{
					y = -1;
				}
				HexUpDown = y;
				this.Invalidate();
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			if (MDent)
			{
				MDent = false;
				HexUpDown = 0;
				this.Invalidate();
			}
			base.OnMouseLeave(e);
		}
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (MDent)
			{
				int a = e.Delta / 120;

				if (a < 0)
				{
					OnMinused(new EventArgs());
				}
				else if (a > 0)
				{
					OnPlused(new EventArgs());
				}
				this.Invalidate();
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (this.Parent is HexEdit)
			{
				((HexEdit)this.Parent).AtFoucus();

			}
		}
		protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
		{
			if((this.Focused)&&(e.KeyData == Keys.Enter))
			{
				if (this.Parent is HexEdit)
				{
					((HexEdit)this.Parent).SetEdit();
				}
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if ((MDent)&&((HexUpDown != 0)))
			{
				if (HexUpDown < 0)
				{
					OnMinused(new EventArgs());
				}
				else if (HexUpDown > 0)
				{
					OnPlused(new EventArgs());
				}
				this.Invalidate();
			}
		}
		protected override void OnResize(EventArgs e)
		{
			if (this.Height != m_Height)
			{
				this.Height = m_Height;
			}
			if (this.Width != m_Width)
			{
				this.Width = m_Width;
			}
			//base.OnResize(e);
		}
		protected override void OnGotFocus(EventArgs e)
		{
			if(this.Parent is HexEdit)
			{
				((HexEdit)this.Parent).AtFoucus();

			}
		}
	}
}

