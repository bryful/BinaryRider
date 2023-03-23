using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public class BSheet : BControl
	{
		public Color BackColor0 { get;set; }= Color.FromArgb(240,240,240);
		public Color BackColor1 { get; set; } = Color.FromArgb(230, 230, 230);
		public Color ForeColor0 { get; set; } = Color.FromArgb(100, 100, 100);
		public Color ForeColor1 { get; set; } = Color.FromArgb(150, 150, 150);

		public BSheet(EditBinary eb) : base(eb)
		{
			SetEditBinary(eb);
		}
		protected override void SetEditBinary(EditBinary eb)
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
						m_eb.BSize.HeaderWidth +ow,
						m_eb.Height - m_eb.BSize.LineHeight + oh
						));
				m_Location = new Point(m_eb.BSize.ByteLeft, m_eb.BSize.LineHeight);

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
						int h = m_eb.BSize.LineHeight;
						int charLeft = m_eb.BSize.CharLeft;
						int sline = m_eb.BDisp.Y / h;

						int TwoByteFlag = 0;
						for (int idx = sline* BDisp.HexC; idx< m_eb.DispByteSize; idx++)
						{
							int line = idx / BDisp.HexC;
							int y = line * h - m_eb.BDisp.Y;

							//終了
							if (y >= m_Size.Height) break;

							if (y + h>0)
							{
								int xcc = idx % BDisp.HexC;

								if ((line % 2 == 1)&&(xcc ==0))
								{
									sb.Color = BackColor1;
									Rectangle rr = new Rectangle(
										0,
										y,
										this.m_Size.Width,
										m_eb.BSize.LineHeight
										);
									g.FillRectangle(sb, rr);
								}
								sb.Color = ForeColor;
								Rectangle r = new Rectangle(
									xcc * m_eb.BSize.ByteWidth,
									y,
									m_eb.BSize.ByteWidth,
									h
									);
								int adr = idx + m_eb.DispStartAdress;
								SFormat.Alignment = StringAlignment.Center;
								g.DrawString(ByteHex(m_DataFile[adr]), m_eb.Font, sb, r, SFormat);


								if (TwoByteFlag == 2)
								{
									TwoByteFlag = 0;
								}
								else
								{
									string ss = m_DataFile.ToStrShiftJIS(adr, ref TwoByteFlag);
									SFormat.Alignment = StringAlignment.Near;
									r = new Rectangle(
										xcc * m_eb.BSize.CharWidth + charLeft,
										y,
										m_eb.BSize.CharWidth * 2,
										h
										);
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
					int x = m_eb.BSize.ByteWidth * 8;
					g.DrawLine(p, x, y0, x, y1);
					x = m_eb.BSize.ByteWidth * 16;
					g.DrawLine(p, x, y0, x, y1);
					p.Color = ForeColor1;
					x = m_eb.BSize.ByteWidth * 4;
					g.DrawLine(p, x, y0, x, y1);
					x = m_eb.BSize.ByteWidth * 12;
					g.DrawLine(p, x, y0, x, y1);
				}
			}
		}
		// *********************************************************************************
	}
}
