using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRider
{
	public class BAdrV :BControl
	{
		public Color BackColor0 { get; set; } = Color.FromArgb(220, 220, 220);
		public Color BackColor1 { get; set; } = Color.FromArgb(200, 200, 200);
		public BAdrV(EditBinary eb) : base(eb)
		{
			SetEditBinary(eb);
		}
		protected override void SetEditBinary(EditBinary eb)
		{
			m_eb = eb;
			if (m_eb != null)
			{
				m_eb.Resize += (sender, e) => { ChkSize(); };
				m_Location = new Point(0, m_eb.BSize.LineHeight);
				ChkSize();
			}
		}
		public void ChkSize()
		{
			if (m_eb != null)
			{

				SetSzie(new Size(
						m_eb.BSize.AdrWidthAll,
						m_eb.Height - m_eb.BSize.LineHeight
						));
			}
		}

		public override void DrawOffScr()
		{
			if (m_OffScr == null) return;
			Graphics g = Graphics.FromImage(m_OffScr);
			using (SolidBrush sb = new SolidBrush(BackColor0))
			{
				g.FillRectangle(sb, ClientRectangle);
				sb.Color = ForeColor;
				if (m_eb != null)
				{
					SFormat.Alignment = StringAlignment.Far;


					int y = -m_eb.BDisp.Y;
					sb.Color = ForeColor;
					int idx = 0;
					while (y < this.m_Size.Height)
					{
						if(y + m_eb.BSize.LineHeight >=0)
						{
							if(idx%2 ==1)
							{
								sb.Color = BackColor1;
								Rectangle rr = new Rectangle(0, y, m_eb.BSize.AdrWidthAll, m_eb.BSize.LineHeight);
								g.FillRectangle(sb, rr);
							}
							sb.Color = ForeColor;
							Rectangle r = new Rectangle(0, y, m_eb.BSize.AdrWidth1, m_eb.BSize.LineHeight);
							int adr = idx * (int)m_eb.BDisp.DispMode;
							g.DrawString($"{adr:X}", m_eb.Font, sb, r, SFormat);
						}
						y += m_eb.BSize.LineHeight;
						idx++;
					}
				}
			}
		}
	}
}
