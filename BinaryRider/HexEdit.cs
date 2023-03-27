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
		private int m_WidthTrue=0;
		private int m_HeightTrue = 0;
		private int m_Top1 = 0;
		private int m_HeightMid = 0;

		private HexOneByte[] HexOneBytes = new HexOneByte[16];

		private int m_UsedByte = 8;
		private long m_MaxValue = 0x6FFFFFFFFFFFFFFF;
		public int UsedByte
		{
			get { return m_UsedByte; }
			set 
			{
				m_UsedByte = value;
				if (m_UsedByte < 1) m_UsedByte = 1;
				else if (m_UsedByte > 8) m_UsedByte = 8;
				CalcMaxValue();
				GetSizeFromFont();
			}
		}
		public long MaxValue
		{
			get { return m_MaxValue; }
		}
		public void CalcMaxValue()
		{
			ulong v = 0;
			for (int i = 0; i < m_UsedByte * 2; i++)
			{
				v = (v << 4) + 0xF;
			}
			if (v > 0x6FFFFFFFFFFFFFFF)  v = 0x6FFFFFFFFFFFFFFF;
			m_MaxValue = (long)v;
			if(m_Value> m_MaxValue)
			{
				m_Value = m_MaxValue;
				OnValueChanged(new EventArgs());
				DispValue();
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
				DispValue();
			}

		}
		// ***********************************************************
		private void DispValue()
		{
			long v = Value;
			for(int i = 0; i < m_UsedByte*2; i++)
			{
				HexOneBytes[i].Value = (byte)(v & 0xF);
				v = v >> 4;
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
		public new Color BackColor
		{
			get { return HexOneBytes[0].BackColor; }
			set
			{
				base.BackColor = Color.Transparent;
				for(int i=0; i<HexOneBytes.Length; i++)
				{
					HexOneBytes[i].BackColor = value;
				}
			}
		}
		public Color BackColorMid
		{
			get { return HexOneBytes[0].BackColorMid; }
			set
			{
				for (int i = 0; i < HexOneBytes.Length; i++)
				{
					HexOneBytes[i].BackColorMid = value;
				}
			}
		}
		public new Color ForeColor
		{
			get { return base.ForeColor; }
			set
			{
				base.ForeColor = value;
				for (int i = 0; i < HexOneBytes.Length; i++)
				{
					HexOneBytes[i].ForeColor = value;
				}
			}
		}
		private TextBox? m_Edit = null;
		public HexEdit()
		{
			CalcMaxValue();
			long aa = 1;
			for (int i = 0; i < HexOneBytes.Length; i++)
			{
				HexOneBytes[i] = new HexOneByte();
				HexOneBytes[i].Name = $"HexOneBytes{i}";
				HexOneBytes[i].AddValue = aa;
				aa = aa << 4;

				HexOneBytes[i].Plused += (sender, e) =>
				{
					HexOneByte hob = (HexOneByte)sender;
					long v = m_Value + hob.AddValue;
					if ((v > m_MaxValue)||(v<0)) v = m_MaxValue;
					if (m_Value != v)
					{ 
						m_Value = v;
						DispValue();
						OnValueChanged(new EventArgs());
					}
				};
				HexOneBytes[i].Minused += (sender, e) =>
				{
					HexOneByte hob = (HexOneByte)sender;
					long v = m_Value - hob.AddValue;
					if (v < 0) v = 0;
					if (m_Value != v)
					{
						m_Value = v;
						DispValue();
						OnValueChanged(new EventArgs());
					}
				};
			}
			GetSizeFromFont();
			m_Format.Alignment = StringAlignment.Center;
			InitializeComponent();
			this.SetStyle(
ControlStyles.UserMouse |
ControlStyles.Selectable |
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);

			this.BackColor = SystemColors.Control;
			this.ForeColor = SystemColors.ControlText;
			this.UpdateStyles();
			for(int i = 0;i< HexOneBytes.Length;i++)
			{
				this.Controls.Add(HexOneBytes[i]);
			}

			this.Invalidate();
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
				for(int  i = 0; i < HexOneBytes.Length;i++)
				{
					HexOneBytes[i].SetCharSize(w, h);
					HexOneBytes[i].Visible = false;
					HexOneBytes[i].Font = base.Font;
				}
				m_WidthTrue = w * m_UsedByte*2+3;
				m_HeightTrue = h + HexOneByte.TopBottomHeight*2 +3;
				m_Top1 = HexOneByte.TopBottomHeight+1;
				m_HeightMid = h;
				base.Size = new Size(m_WidthTrue, m_HeightTrue);
				for (int i = 0; i < m_UsedByte*2; i++)
				{
					HexOneBytes[i].Location = new Point(m_WidthTrue - (i + 1) * w-2, 1);
					HexOneBytes[i].Visible=true;
				}

			}
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			using (SolidBrush sb = new SolidBrush(Color.Transparent))
			using (Pen p = new Pen(this.ForeColor))
			{
				//透明
				sb.Color = Color.Transparent;
				g.FillRectangle(sb,this.ClientRectangle);
				if (this.Focused)
				{
					p.Color = ForeColor;
					g.DrawRectangle(p, new Rectangle(0,0,this.Width-1,this.Height-1));
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
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			AtFoucus();
		}


		public void SetEdit()
		{
			if (m_Edit != null) return;
			m_Edit = new TextBox();
			m_Edit.Name = "Edit";
			m_Edit.Size = new Size(this.Width - 2, m_HeightMid);
			m_Edit.Location = new Point(2, 2);
			m_Edit.BorderStyle = BorderStyle.None;
			m_Edit.Font = base.Font;
			m_Edit.TextAlign = HorizontalAlignment.Right;
			m_Edit.Text = $"{m_Value:X}";
			m_Edit.PreviewKeyDown += M_Edit_PreviewKeyDown;
			this.Controls.Add(m_Edit);
			m_Edit.Focus();

		}

		private void M_Edit_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
		{
			if(e.KeyData == Keys.Escape)
			{
				EndEdit();
			}
		}

		public void EndEdit()
		{
			if (m_Edit == null) return;
			this.Controls.Remove(m_Edit);
			m_Edit.Dispose();
			m_Edit = null;
		}
	}
}
