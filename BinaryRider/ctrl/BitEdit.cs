using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRider
{
	public enum BitType
	{
		Bsbyte = 10,
		Bbyte = 11,
		Bshort = 20,
		Bushort = 21,
		Bint = 40,
		Buint = 41,
		Blong = 80,
		Bulong = 81
	};

	public partial class BitEdit : Control
	{
		//TimeEventArgs型のオブジェクトを返すようにする
		public delegate void ValueChangedEventHandler(object sender, EventArgs e);

		//イベントデリゲートの宣言
		public event ValueChangedEventHandler? ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		private ulong[] _MaxBit = new ulong[]
		{
			0x0000000000000000,
			0x00000000000000FF,
			0x000000000000FFFF,
			0x0000000000FFFFFF,
			0x00000000FFFFFFFF,
			0x000000FFFFFFFFFF,
			0x0000FFFFFFFFFFFF,
			0x00FFFFFFFFFFFFFF,
			0xFFFFFFFFFFFFFFFF,

		};

		private int m_BitWidth = 8;
		public int BitWidth
		{
			get { return m_BitWidth; }
			set
			{
				m_BitWidth = value;
				int xc = (int)m_BitType / 10;
				this.Size = new Size(BitWidthAll, BitHeightAll);
			}

		}
		private int m_BitInter = 2;
		public int BitInter
		{
			get { return m_BitInter; }
			set
			{
				m_BitInter = value;
				this.Size = new Size(BitWidthAll, BitHeightAll);
			}

		}
		private int BitWidth8
		{
			get { return (m_BitWidth + m_BitInter) * 8 + m_BitInter; }
		}
		private int BitWidthAll
		{
			get { return BitWidth8 * ((int)m_BitType/10); }
		}
		private int BitHeightAll
		{
			get { return m_BitWidth + m_BitInter * 2; }
		}
		private BitType m_BitType = BitType.Blong;
		public BitType BitType
		{
			get { return m_BitType; }
			set
			{
				m_BitType= value;
				ulong v =  m_Value & _MaxBit[(int)m_BitType / 10];
				bool b = (m_Value != v);
				m_Value = v;
				this.Size = new Size(BitWidthAll, BitHeightAll);
				if(b) OnValueChanged(new EventArgs());
			}
		}
		private ulong m_Value = 0;
		public ulong Value
		{
			get { return m_Value; }
			set
			{
				bool b = (m_Value != value);
				m_Value = value;
				this.Invalidate();
				if(b) OnValueChanged(new EventArgs());
			}
		}
		public BitEdit()
		{
			InitializeComponent();
			this.SetStyle(
ControlStyles.UserMouse |
ControlStyles.Selectable |
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
		}

		private void DrawBit(Graphics g,SolidBrush sb, Pen p, byte b,int x)
		{
			int wa = BitWidth8;
			p.Color = ForeColor;
			sb.Color = ForeColor;
			byte bb = b;
			for (int i = 0;i<8;i++)
			{
				int xx = x + wa - (i + 1) * (m_BitWidth + m_BitInter);
				Rectangle r = new Rectangle(xx, m_BitInter, m_BitWidth, m_BitWidth);
				if((bb & 0x01) == 0x01)
				{
					g.FillRectangle(sb, r);
				}
				g.DrawRectangle(p,r);
				bb >>= 1;
			}
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			using(Pen p = new Pen(ForeColor, 1))
			using (SolidBrush sb= new SolidBrush(BackColor))
			{
				Graphics g = pe.Graphics;
				sb.Color = BackColor;
				g.FillRectangle(sb, this.ClientRectangle);
				int c = (int)m_BitType / 10;
				int ww = BitWidthAll;
				ulong bb = m_Value;
				for(int i = 0;i<c;i++)
				{
					int xx = ww - (i + 1) * BitWidth8;
					byte b = (byte)(bb &0xFF);
					DrawBit(g, sb, p, b, xx);
					bb >>= 8;
				}

			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			int bs = (int)m_BitType / 10 -1;
			int x = e.X / BitWidth8;
			if(bs>0)x = bs - x;

			int xx =  7 - (e.X % BitWidth8)/(m_BitWidth+m_BitInter);
			int xxx = (int)x * 8 + (int)xx;

			ulong v = m_Value ^ ((ulong)0x01 << xxx); ;
			bool b = (m_Value != v);
			this.Invalidate();
			if(b) OnValueChanged(new EventArgs());
		}
	}
}
