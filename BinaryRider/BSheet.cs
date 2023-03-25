using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BinaryRider
{
	public class BSheet : BControl
	{
		public Color BackColor0 { get;set; }= Color.FromArgb(240,240,240);
		public Color BackColor1 { get; set; } = Color.FromArgb(230, 230, 230);
		public Color ForeColor0 { get; set; } = Color.FromArgb(100, 100, 100);
		public Color ForeColor1 { get; set; } = Color.FromArgb(150, 150, 150);
		public Color SelectionColor { get; set; } = Color.FromArgb(230, 230, 150);

		public BSheet()
		{
		}
		public override void SetEditBinary(EditBinary eb)
		{
			m_eb = eb;
			if (m_eb != null)
			{
				m_DataFile = m_eb.DataFile;
				m_eb.Resize += (sender, e) => { ChkSize(); };
				ChkSize();
			}
		}
		public void SetDataFile(BDataFile df)
		{
			m_DataFile = df;
		}
		public void ChkSize(int ow  =0, int oh = 0)
		{
			if (m_eb != null)
			{

				SetSzie(new Size(
						m_eb.BSz.HeaderWidth +ow,
						m_eb.Height - m_eb.BSz.LineHeight + oh
						));
				m_Location = new Point(m_eb.BSz.ByteLeft, m_eb.BSz.LineHeight);

			}
		}
		// *********************************************************************************
		private string ByteHex(byte? b)
		{
			string ret = "??";
			if (b != null)
			{
				ret = $"{b:X}";
				if (b < 0x10) ret = "0" + ret;
			}
			return ret ;
		}
		// *********************************************************************************
		private CharCodeMode m_CharCodeMode = CharCodeMode.UTF8;
		public CharCodeMode CharCodeMode
		{
			get { return m_CharCodeMode;}
			set
			{
				if (m_CharCodeMode != value)
				{
					m_CharCodeMode = value;
					DrawOffScr();
				}
			}
		}
		// *********************************************************************************
		public class MouseDownStatus
		{
			public bool Down = false;
			public bool IsByte = true;
			public bool IsChar { get { return !IsByte; } }
			public int x = 0;
			public int y = 0;
			public int Adress = 0;
		}
		public MouseDownStatus MousePosStatus(MouseEventArgs e)
		{
			MouseDownStatus ret = new MouseDownStatus();
			Point? p = ChkMousePoint(e);
			if((p!=null)&&(m_eb!=null))
			{
				int X = ((Point)p).X;
				int Y = ((Point)p).Y;
				ret.Down = true;
				ret.y = (Y + m_eb.BDp.Y) / m_eb.BSz.LineHeight;
				if (X <m_eb.BSz.CharLeft)
				{
					ret.IsByte = true;
					ret.x =X / m_eb.BSz.ByteWidth;
				}
				else
				{
					ret.IsByte = false;
					ret.x = (X - m_eb.BSz.CharLeft) / m_eb.BSz.CharWidth;
				}
				ret.Adress = ret.x + ret.y * BDisp.HexC + m_eb.BDp.DispStartAdress;
			}
			return ret;
		}
		// *********************************************************************************
		private void DrawByte(int adr, Rectangle r)
		{

		}
		// *********************************************************************************
		public override void DrawOffScr()
		{
			if (m_OffScr == null) return;
			Graphics g = Graphics.FromImage(m_OffScr);
			using (Pen p = new Pen(ForeColor0))
			using (SolidBrush sb = new SolidBrush(BackColor0))
			{
				g.FillRectangle(sb, ClientRectangle);
				if ((m_eb != null)&&(m_DataFile!=null))
				{
					SFormat.Alignment = StringAlignment.Center;

					if(m_eb.DispByteSize > 0)
					{
						int h = m_eb.BSz.LineHeight;
						int charLeft = m_eb.BSz.CharLeft;
						int sline = m_eb.BDp.Y / h;

						int TwoByteFlag = 0;
						for (int idx = sline* BDisp.HexC; idx< m_eb.DispByteSize; idx++)
						{
							int line = idx / BDisp.HexC;
							int y = line * h - m_eb.BDp.Y;
							

							//画面外になったので終了
							if (y >= m_Size.Height) break;

							if (y + h>0)
							{
								int adr = idx + m_eb.DispStartAdress;// アドレス
								int xcc = idx % BDisp.HexC;

								//行の最初の時だけ背景色を描画
								if ((line % 2 == 1)&&(xcc ==0))
								{
									sb.Color = BackColor1;
									Rectangle rr = new Rectangle(
										0,
										y,
										this.m_Size.Width,
										m_eb.BSz.LineHeight
										);
									g.FillRectangle(sb, rr);
								}
								Rectangle r = new Rectangle(
									xcc * m_eb.BSz.ByteWidth,
									y,
									m_eb.BSz.ByteWidth,
									h
									);
								//選択範囲の描画
								bool IsSel = m_eb.Selection.IsInSection(adr);
								if (IsSel==true)
								{
									sb.Color = SelectionColor;
									g.FillRectangle(sb, r);
								}
								SFormat.Alignment = StringAlignment.Center;
								sb.Color = ForeColor;
								g.DrawString(ByteHex(m_DataFile[adr]), m_eb.Font, sb, r, SFormat);

								if (TwoByteFlag > 0)
								{
									TwoByteFlag--;
									if (TwoByteFlag < 0) TwoByteFlag = 0;
								}
								else
								{
									string ss = m_DataFile.ToChar(m_CharCodeMode, adr, ref TwoByteFlag);
									SFormat.Alignment = StringAlignment.Near;
									r = new Rectangle(
										xcc * m_eb.BSz.CharWidth + charLeft,
										y,
										m_eb.BSz.CharWidth * (TwoByteFlag+1),
										h
										);
									if(IsSel==true)
									{
										sb.Color = SelectionColor;
										g.FillRectangle(sb, r);
									}
									sb.Color = ForeColor;
									g.DrawString(ss, m_eb.Font, sb, r, SFormat);

								}

							}
						}

					}
					//
					p.Width = 1;

					p.Color = ForeColor0;
					int y0 = 0;
					int y1 = m_Size.Height;
					int x = m_eb.BSz.ByteWidth * 8;
					g.DrawLine(p, x, y0, x, y1);
					x = m_eb.BSz.ByteWidth * 16;
					g.DrawLine(p, x, y0, x, y1);
					p.Color = ForeColor1;
					x = m_eb.BSz.ByteWidth * 4;
					g.DrawLine(p, x, y0, x, y1);
					x = m_eb.BSz.ByteWidth * 12;
					g.DrawLine(p, x, y0, x, y1);
				}
			}
		}
		// *********************************************************************************
	}
}
