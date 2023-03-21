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
	public class BAdrH : BControl
	{
		public Color ForeColor0 { get; set; } = Color.FromArgb(100, 100, 100);
		public Color ForeColor1 { get; set; } = Color.FromArgb(150, 150, 150);
		public BAdrH(EditBinary eb):base(eb)
		{
			BackColor = Color.LightGray;
			ForeColor = Color.Black;
			SetEditBinary(eb);
		}
		protected override void SetEditBinary(EditBinary eb)
		{
			m_eb = eb;
			if (m_eb != null)
			{
				m_Location = new Point(m_eb.BSize.ByteLeft, 0);
				SetSzie(new Size(
					(int)eb.BSize.HeaderWidth,
					eb.BSize.LineHeight
					));
			}
		}
		public override void DrawOffScr()
		{
			if (m_OffScr == null) return;
			Graphics g = Graphics.FromImage(m_OffScr);
			using (Pen p = new Pen(ForeColor0))
			using (SolidBrush sb = new SolidBrush(BackColor))
			{
				sb.Color = BackColor;
				g.FillRectangle(sb, ClientRectangle);
				sb.Color = ForeColor;
				if (m_eb != null) {
					SFormat.Alignment = StringAlignment.Center;
					for (int i = 0; i < 0x10; i++)
					{
						Rectangle r = new Rectangle(
							i * m_eb.BSize.ByteWidth, 0,
							m_eb.BSize.ByteWidth, m_eb.BSize.LineHeight
							);

						g.DrawString($"+{i:X}", m_eb.Font, sb, r, SFormat);
					}
					int cl = m_eb.BSize.CharLeft;

					for (int i = 0; i < 0x10; i++)
					{
						Rectangle r = new Rectangle(
							i * m_eb.BSize.CharWidth + cl,
							0,
							m_eb.BSize.CharWidth, 
							m_eb.BSize.LineHeight
							);
						g.DrawString($"{i:X}", m_eb.Font, sb, r, SFormat);
					}
					
					p.Color = ForeColor0;
					p.Width = 1;
					if(m_eb.BDisp.DispMode == DispMode.Hex16)
					{
						int y0 = 0;
						int y1 = m_eb.BSize.LineHeight;
						int x = m_eb.BSize.ByteWidth * 8;
						p.Color = ForeColor0;
						g.DrawLine(p,x, y0, x, y1);
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
	}
}
