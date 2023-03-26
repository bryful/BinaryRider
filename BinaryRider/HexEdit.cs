using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRider
{
	public partial class HexEdit : Control
	{
		public readonly int TopBottomHeight = 6;
		private int m_HightAll = 0;
		private int m_HightB = 0;
		private int m_WidthOne = 0;
		private int m_WidthAll = 0;

		private StringFormat m_Format = new StringFormat();
		public StringAlignment Alignment
		{
			get {return m_Format.Alignment;} 
			set { m_Format.Alignment = value;}
		}
		// ***********************************************************
		private long m_Value = 0;
		public long Value
		{
			get { return m_Value; }
			set 
			{ 
				m_Value = value;
				if (m_Value > 0x4FFFFFFF) m_Value = 0x4FFFFFFF;
				this.Invalidate();
			}

		}

		// ***********************************************************
		public new Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				GetSizeFromFont();
			}
		}
		public new Size Size
		{ 
			get { return base.Size; }
			set
			{
				int w = base.Size.Width;
				int h = base.Size.Height;
				base.Size = new Size(value.Width, h);
			}
		}
		public HexEdit()
		{
			this.Size = new Size(100, 75);
			m_Format.Alignment = StringAlignment.Center;
			GetSizeFromFont();
			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
			this.BackColor = SystemColors.Control;
			this.ForeColor = SystemColors.ControlText;
			this.UpdateStyles();
			this.Invalidate();
		}
		public Size GetSizeFromFont()
		{
			Size ret = new Size(0,0);

			using (StringFormat format = new StringFormat(StringFormat.GenericTypographic))
			using (Bitmap bmp = new Bitmap(100, 50, PixelFormat.Format32bppArgb))
			{
				Graphics g = Graphics.FromImage(bmp);
				SizeF szF = g.MeasureString("A", this.Font, 100, format);
				int w = (int)(1.3*szF.Width + 0.5);
				int h = (int)(szF.Height + 0.5);
				ret.Width = w;
				ret.Height = h;
				m_WidthOne = w;
				m_WidthAll = w*10;
				m_HightAll = h + TopBottomHeight * 2;
				m_HightB = h;
				base.Size = new Size(m_WidthAll, m_HightAll);
			}
			return ret;
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			using (SolidBrush sb = new SolidBrush(this.BackColor))
			using (Pen p = new Pen(this.ForeColor))
			{
				//透明
				sb.Color = Color.Transparent;
				g.FillRectangle(sb,this.ClientRectangle);

				Rectangle r = new Rectangle(0, TopBottomHeight, this.Width, m_HightB);
				sb.Color = BackColor;
				g.FillRectangle(sb, r);

				string s = $"{m_Value:X8}";
				sb.Color = ForeColor;
				int x = 0;
				r = new Rectangle(x,TopBottomHeight,m_WidthOne, m_HightB);
				g.DrawString("0",this.Font,sb,r);
				x += m_WidthOne;
				r = new Rectangle(x, TopBottomHeight, m_WidthOne, m_HightB);
				g.DrawString("x", this.Font, sb, r);
				x += m_WidthOne;
				if(s.Length>0)
				{
					for(int i=0;i<s.Length;i++)
					{
						r = new Rectangle(x, TopBottomHeight, m_WidthOne, m_HightB);
						g.DrawString(s.Substring(i,1), this.Font, sb, r);
						x += m_WidthOne;
					}
				}
				if(HexUpDown!=0)
				{
					if(HexUpDown>0)
					{
						r = new Rectangle(m_WidthOne * (2 + HexPos), 0, m_WidthOne, TopBottomHeight);
					}else
					{
						r = new Rectangle(m_WidthOne * (2 + HexPos), TopBottomHeight+m_HightB, m_WidthOne, TopBottomHeight);
					}
					sb.Color = ForeColor;
					g.FillRectangle(sb, r);

				}

				r = new Rectangle(0, TopBottomHeight, this.Width-1, m_HightB-1);
				p.Color = ForeColor;
				g.DrawRectangle(p, r);

			}
		}
		protected override void OnResize(EventArgs e)
		{
			if(this.Height != m_HightAll)
			{
				this.Height = m_HightAll;
			}
			if (this.Width != m_WidthAll)
			{
				this.Width = m_WidthAll;
			}
			//base.OnResize(e);
		}
		private bool MDent = false;
		private int HexPos = -1;
		private int HexUpDown = 0;
		protected override void OnMouseEnter(EventArgs e)
		{
			MDent = true;
			base.OnMouseEnter(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (MDent)
			{
				int x = -1;
				int y = 0;
				x = (e.X - m_WidthOne * 2) / m_WidthOne;
				if (x >= 8) x = -1;
				HexPos = x;
				if (e.Y < TopBottomHeight*2)
				{
					y = +1;
				}
				else if (e.Y > -TopBottomHeight + m_HightB)
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
			if(MDent)
			{
				MDent=false;
				HexPos = -1;
				HexUpDown = 0;
			}
			base.OnMouseLeave(e);
		}
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (MDent)
			{
				long a = e.Delta / 120;
				long ad = 0;
				switch (HexPos)
				{
					case 7:
						ad = 1 * a;
						break;
					case 6:
						ad = 0x10 * a;
						break;
					case 5:
						ad = 0x100 * a;
						break;
					case 4:
						ad = 0x1000 * a;
						break;
					case 3:
						ad = 0x10000 * a;
						break;
					case 2:
						ad = 0x100000 * a;
						break;
					case 1:
						ad = 0x1000000 * a;
						break;
					case 0:
						ad = 0x10000000;
						if (a > 0)
						{
							if (m_Value >= 0xEFFFFFFF)
							{
								ad = 0;
							}
						}
						else
						{
							ad *= -1;
						}
						break;
				}
				m_Value += ad;
				if (m_Value < 0) m_Value = 0;
				this.Invalidate();
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (MDent)
			{

				if ((HexPos >= 0) && (HexPos < 8) && (HexUpDown != 0))
				{
					long ad = 0;
					switch (HexPos)
					{
						case 7:
							ad = 1 * (long)HexUpDown;
							break;
						case 6:
							ad = 0x10 * (long)HexUpDown;
							break;
						case 5:
							ad = 0x100 * (long)HexUpDown;
							break;
						case 4:
							ad = 0x1000 * (long)HexUpDown;
							break;
						case 3:
							ad = 0x10000 * (long)HexUpDown;
							break;
						case 2:
							ad = 0x100000 * (long)HexUpDown;
							break;
						case 1:
							ad = 0x1000000 * (long)HexUpDown;
							break;
						case 0:
							ad = 0x10000000;
							if (HexUpDown > 0)
							{
								if (m_Value >= 0xEFFFFFFF)
								{
									ad = 0;
								}
							}
							else
							{
								ad *= -1;
							}
							break;
					}
					m_Value += ad;
					if (m_Value < 0) m_Value = 0;
					this.Invalidate();
				}
			}
			//base.OnMouseDown(e);
		}
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (HexUpDown == 0)
			{
				m_Value = 0;
				this.Invalidate();
			}
			base.OnMouseDoubleClick(e);
		}
	}
}
