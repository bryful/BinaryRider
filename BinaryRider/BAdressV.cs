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
	public class BAdressV :BControl
	{
		public Color BackColor0 { get; set; } = Color.FromArgb(220, 220, 220);
		public Color BackColor1 { get; set; } = Color.FromArgb(200, 200, 200);
		public BAdressV()
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
		public void ChkSize()
		{
			if (m_eb != null)
			{

				SetSzie(new Size(
						m_eb.BSz.AdrWidthAll,
						m_eb.Height - m_eb.BSz.LineHeight
						));
				m_Location = new Point(0, m_eb.BSz.LineHeight);
			}
		}
		private string AdrHex(int adr)
		{
			return $"{adr:X4}";
		}
		public override void DrawOffScr()
		{
			if (m_OffScr == null) return;
			Graphics g = Graphics.FromImage(m_OffScr);
			using (SolidBrush sb = new SolidBrush(BackColor0))
			{
				g.FillRectangle(sb, ClientRectangle);
				sb.Color = ForeColor;
				if ((m_eb != null))
				{
					SFormat.Alignment = StringAlignment.Far;

					int h = m_eb.BSz.LineHeight;

					sb.Color = ForeColor;

					int sline = m_eb.BDp.Y / h;
					int adr = m_eb.BDp.DispStartAdress + sline* BDisp.HexC;
					int y = -m_eb.BDp.Y + sline * h;
					int lineIdx = sline;

					while (y < m_Size.Height)
					{
						if (y + h >=0)
						{
							if(lineIdx%2 ==1)
							{
								sb.Color = BackColor1;
								g.FillRectangle(sb, new Rectangle(0, y, m_eb.BSz.AdrWidthAll, h));
							}
							sb.Color = ForeColor;
							Rectangle r = new Rectangle(0, y, m_eb.BSz.AdrWidth1, h);
							Debug.WriteLine(r.ToString());
							g.DrawString(AdrHex(adr), m_eb.Font, sb, r, SFormat);
						}
						y += h;
						lineIdx++;
						adr += BDisp.HexC;
					}
				}
			}
		}
	}
}
