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
using System.Runtime.InteropServices;
namespace BinaryRider
{
	public partial class HexEdit : Control
	{
		[DllImport("user32.dll")]
		private static extern IntPtr SetFocus(IntPtr hWnd);
		public void  AtFoucus()
		{ SetFocus(this.Handle); }

		public delegate void ValueChangedEventHandler(object sender, EventArgs e);
		public event ValueChangedEventHandler? ValueChanged = null;
		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		static public readonly int TopBottomHeight = 6;
		private int m_WidthTrue=0;
		private int m_WidthOne = 0;
		private int m_HeightTrue = 0;
		private int m_Top1 = 0;
		private int m_HeightMid = 0;

		private int m_TopBorder = 0;
		private int m_BottomBorder = 0;

		private int m_UsedByte = 8;
		private long m_MaxValue = 0x6FFFFFFFFFFFFFFF;
		private long[] AddTbl = new long[]
			{
			0x0000000000000001,
			0x0000000000000010,
			0x0000000000000100,
			0x0000000000001000,
			0x0000000000010000,
			0x0000000000100000,
			0x0000000001000000,
			0x0000000010000000,
			0x0000000100000000,
			0x0000001000000000,
			0x0000010000000000,
			0x0000100000000000,
			0x0001000000000000,
			0x0010000000000000,
			0x0100000000000000,
			0x1000000000000000 
			};
		private long[] MaxTbl = new long[]
			{
			0x00000000000000FF,
			0x000000000000FFFF,
			0x0000000000FFFFFF,
			0x00000000FFFFFFFF,
			0x000000FFFFFFFFFF,
			0x0000FFFFFFFFFFFF,
			0x00FFFFFFFFFFFFFF,
			0x7FFFFFFFFFFFFFFF,
			};
		public int UsedByte
		{
			get { return m_UsedByte; }
			set 
			{
				m_UsedByte = value;
				if (m_UsedByte < 1) m_UsedByte = 1;
				else if (m_UsedByte > 8) m_UsedByte = 8;
				m_MaxValue = MaxTbl[m_UsedByte - 1];
				long v = m_Value & m_MaxValue;
				bool b = (m_Value != v);
				m_Value = v;
				GetSizeFromFont();
				this.Invalidate();
				if(b) OnValueChanged(new EventArgs());
			}
		}
		public long MaxValue
		{
			get { return m_MaxValue; }
		}
		public void CalcMaxValue()
		{
			m_MaxValue = MaxTbl[m_UsedByte - 1];
			long v = m_Value & m_MaxValue;
			if(m_Value != v)
			{
				m_Value = v;
				OnValueChanged(new EventArgs());
				this.Invalidate();
			}
		}
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
			get
			{
				return m_Value; 
			}
			set 
			{ 
				long v = value;
				if (v < 0) v = 0;
				if(v>m_MaxValue) v = m_MaxValue;
				if(m_Value!=v)
				{
					m_Value = v;
					OnValueChanged(new EventArgs());
				}
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
				base.Size = new Size(m_WidthTrue, m_HeightTrue);
			}
		}
		private Color m_BackColorMid = SystemColors.Control;
		public Color BackColorMid
		{
			get { return m_BackColorMid; }
			set
			{
				m_BackColorMid= value;
				this.Invalidate();
			}
		}
		public new Color ForeColor
		{
			get { return base.ForeColor; }
			set
			{
				base.ForeColor = value;
				this.Invalidate();
			}
		}
		public bool CanEdit { get; set; } = true;
		private TextBox? m_Edit = null;
		public HexEdit()
		{
			CalcMaxValue();
			GetSizeFromFont();
			m_Format.Alignment = StringAlignment.Center;
			m_Format.LineAlignment = StringAlignment.Center;
			InitializeComponent();
			this.SetStyle(
ControlStyles.UserMouse |
ControlStyles.Selectable |
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);

			this.BackColor = SystemColors.Window;
			this.ForeColor = SystemColors.ControlText;
			this.UpdateStyles();
		}
		public void GetSizeFromFont()
		{
			int w = 0;
			int h = 0;
			using (StringFormat format = new StringFormat(StringFormat.GenericTypographic))
			using (Bitmap bmp = new Bitmap(50, 20, PixelFormat.Format32bppArgb))
			{
				Graphics g = Graphics.FromImage(bmp);
				SizeF szF = g.MeasureString("A", base.Font, 100, format);
				w = (int)(szF.Width);
				h = (int)(szF.Height*0.8);
				m_WidthOne = w;
				m_HeightMid = h;
				m_WidthTrue = w * m_UsedByte*2;
				m_HeightTrue = h + TopBottomHeight*2;
				m_Top1 = TopBottomHeight;
				m_TopBorder = TopBottomHeight * 2;
				m_BottomBorder = m_HeightTrue - TopBottomHeight * 2;
				base.Size = new Size(m_WidthTrue, m_HeightTrue);
			}
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			using (SolidBrush sb = new SolidBrush(m_BackColorMid))
			using (Pen p = new Pen(this.ForeColor))
			{
				//透明
				sb.Color = m_BackColorMid;
				g.FillRectangle(sb,this.ClientRectangle);

				Rectangle r = new Rectangle(0, m_Top1, m_WidthTrue, m_HeightMid);
				sb.Color = BackColor;
				g.FillRectangle(sb, r);

				long v = m_Value;
				m_Format.Alignment = StringAlignment.Center;
				sb.Color = ForeColor;
				for(int i=0; i<m_UsedByte*2;i++)
				{
					r = new Rectangle(m_WidthTrue - m_WidthOne * (i + 1), m_Top1, m_WidthOne, m_HeightMid);
					long v2 = v & 0xF;
					g.DrawString($"{v2:X}", this.Font, sb, r, m_Format);
					v = v >> 4;


				}
				if ((m_Keta >= 0) && (m_UpDown != 0))
				{
					int xx = m_WidthTrue - m_WidthOne * (m_Keta + 1);
					Point[] pnts = new Point[3];
					if (m_UpDown > 0)
					{
						pnts[0] = new Point(xx, TopBottomHeight);
						pnts[1] = new Point(xx + m_WidthOne / 2, 0);
						pnts[2] = new Point(xx + m_WidthOne, TopBottomHeight);
					}
					else
					{
						pnts[0] = new Point(xx, m_HeightTrue - TopBottomHeight);
						pnts[1] = new Point(xx + m_WidthOne / 2, m_HeightTrue);
						pnts[2] = new Point(xx + m_WidthOne, m_HeightTrue - TopBottomHeight);
					}
					g.FillPolygon(sb, pnts);
				}

				int l = m_UsedByte / 2;
				if(l > 0)
				{
					p.Color = ForeColor;
					int y0 = m_Top1;
					int y1 = m_Top1 + m_HeightMid;
					for (int i = 0; i < l; i++)
					{
						int x = m_WidthTrue - ( i + 1) * m_WidthOne*4;
						g.DrawLine(p, x, y0, x, y1);
					}
				}

				if (this.Focused)
				{
					p.Color = ForeColor;
					g.DrawRectangle(p, new Rectangle(0, m_Top1, this.Width-1, m_HeightMid));
				}
			}
		}
		protected override void OnResize(EventArgs e)
		{
			if(this.Width != m_WidthTrue)
			{
				this.Width = m_WidthTrue;
			}
			if (this.Height != m_HeightTrue)
			{
				this.Height = m_HeightTrue;
			}
			//base.OnResize(e);
		}
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.Invalidate();
		}
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.Invalidate();
		}
		private bool m_InMouse = false;
		private int m_UpDown = 0;
		private int m_Keta = -1;
		private void GetPos(MouseEventArgs e)
		{
			if ((e.X >= 0) && (e.X < m_WidthTrue))
			{
				m_Keta = (m_UsedByte*2-1) -   e.X / m_WidthOne;
			}
			else
			{
				m_Keta = -1;
			}
			m_UpDown = 0;
			if ((e.Y >= 0) && (e.Y <m_HeightTrue))
			{
				if (e.Y < m_TopBorder)
				{
					m_UpDown = 1;
				}
				else if (e.Y > m_BottomBorder)
				{
					m_UpDown = -1;
				}
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			if (CanEdit)
			{
				m_InMouse = true;
			}
			//base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			m_InMouse = false;
			m_Keta = -1;
			m_UpDown = 0;
			this.Invalidate();
			//base.OnMouseLeave(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (m_InMouse)
			{
				GetPos(e);
				this.Invalidate();
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (m_InMouse)
			{
				GetPos(e);
				if((m_Keta>=0)&&(m_UpDown!=0))
				{
					long v = AddTbl[m_Keta];
					if(m_UpDown>0)
					{
						v = m_Value + v;
						if((v>m_MaxValue)||(v<0)) { v = m_MaxValue; }
					}
					else
					{
						v = m_Value - v;
						if (v<0) { v = 0; }
					}
					if(m_Value!=v)
					{
						m_Value = v;
						OnValueChanged(new EventArgs());
						this.Invalidate();
					}
				}
				else
				{
					SetEdit();
				}
			}
		}
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (m_InMouse)
			{
				if (m_Keta >= 0)
				{
					int d = e.Delta / 120;
					long v = AddTbl[m_Keta];
					if (d > 0)
					{
						v = m_Value + v;
						if ((v > m_MaxValue) || (v < 0)) { v = m_MaxValue; }
					}
					else
					{
						v = m_Value - v;
						if (v < 0) { v = 0; }
					}
					if (m_Value != v)
					{
						m_Value = v;
						OnVisibleChanged(new EventArgs());
						this.Invalidate();
					}
				}
			}
		}
		

		public void SetEdit()
		{
			if(CanEdit==false) return;
			if (m_Edit != null) return;
			m_Edit = new TextBox();
			m_Edit.Name = "Edit";
			m_Edit.Size = new Size(this.Width - 2, m_HeightMid);
			m_Edit.Location = new Point(2, 2);
			m_Edit.BorderStyle = BorderStyle.None;
			m_Edit.Font = base.Font;
			m_Edit.TextAlign = HorizontalAlignment.Right;
			m_Edit.PreviewKeyDown += M_Edit_PreviewKeyDown;
			m_Edit.LostFocus += (sender, e) => 
			{
				ChkEdit();
				EndEdit(); 
			};
			m_Edit.Text = $"{m_Value:X}";
			m_Edit.SelectionStart = 0;
			m_Edit.SelectionLength = m_Edit.Text.Length;
			this.Controls.Add(m_Edit);
			m_Edit.Focus();

		}

		private void M_Edit_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
			{
				ChkEdit();
				EndEdit();
			} else if (e.KeyData == Keys.Enter)
			{
				if (ChkEdit())
				{
					EndEdit();
				}
			}
		}
		public bool ChkEdit()
		{
			bool ret = false;
			if (m_Edit == null) return ret;
			try
			{
				long v = Convert.ToInt64(m_Edit.Text, 16);
				if (v < 0) return ret;
				if (v > m_MaxValue) v = m_MaxValue;
				if (m_Value != v)
				{
					m_Value = v;
					this.Invalidate();
					OnValueChanged(new EventArgs());
				}
				ret = true;
			}
			catch
			{

			}
			return ret;
		}
		public void EndEdit()
		{
			if (m_Edit == null) return;
			this.Controls.Remove(m_Edit);
			if(m_Edit != null) m_Edit.Dispose();
			m_Edit = null;
			this.Focus();
		}
	}
}
