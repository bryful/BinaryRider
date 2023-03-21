using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public class BBin : BControl
	{
		public Color BackColor0 { get;set; }= Color.FromArgb(240,240,240);
		public Color BackColor1 { get; set; } = Color.FromArgb(230, 230, 230);
		public Color ForeColor0 { get; set; } = Color.FromArgb(100, 100, 100);
		public Color ForeColor1 { get; set; } = Color.FromArgb(150, 150, 150);

		public BBin(EditBinary eb) : base(eb)
		{
			BackColor = Color.White;
			ForeColor = Color.Black;
			SetEditBinary(eb);
		}
		protected override void SetEditBinary(EditBinary eb)
		{
			m_eb = eb;
			if (m_eb != null)
			{
				m_eb.Resize += (sender, e) => { ChkSize(); };
				m_Location = new Point(m_eb.BSize.ByteLeft, m_eb.BSize.LineHeight);
				ChkSize();
			}
		}
		public void ChkSize()
		{
			if (m_eb != null)
			{

				SetSzie(new Size(
						m_eb.BSize.HeaderWidth,
						m_eb.Height - m_eb.BSize.LineHeight
						));
			}
		}
		// *********************************************************************************
		private string ByteHex(byte b)
		{
			string ret = $"{b:X}";
			if (b < 0x10) ret = "0" + ret;
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
				if (m_eb != null)
				{
					SFormat.Alignment = StringAlignment.Center;

					if(m_eb.ByteSize>0)
					{
						int charLeft = m_eb.BSize.CharLeft;
						for (int idx = 0; idx< m_eb.ByteSize;idx++)
						{
							int line = idx / (int)m_eb.BDisp.DispMode;
							int y = line * m_eb.BSize.LineHeight - m_eb.BDisp.Y;

							if(y + m_eb.BSize.LineHeight>0)
							{
								int x = idx % (int)m_eb.BDisp.DispMode;

								if ((line % 2 == 1)&&(x ==0))
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
									x * m_eb.BSize.ByteWidth,
									y,
									m_eb.BSize.ByteWidth,
									m_eb.BSize.LineHeight
									);
								g.DrawString(ByteHex(m_eb.Data[idx]), m_eb.Font, sb, r, SFormat);
								r = new Rectangle(
									x * m_eb.BSize.CharWidth + charLeft,
									y,
									m_eb.BSize.CharWidth,
									m_eb.BSize.LineHeight
									);
								g.DrawString(".", m_eb.Font, sb, r, SFormat);
							}
							else if (y >= m_Size.Height)
							{
								break;
							}
						}

					}
					//
					p.Width = 1;

					if (m_eb.BDisp.DispMode == DispMode.Hex16)
					{
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
		}
		// *********************************************************************************
	}
}
