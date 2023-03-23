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
	public class BControl
	{
		// ************************************************************************
		protected EditBinary? m_eb = null;
		protected BDataFile? m_DataFile = null; 
		protected virtual void SetEditBinary(EditBinary eb)
		{
			m_eb = eb;
			m_DataFile = eb.DataFile;
			DrawOffScr();
		}
		// ************************************************************************
		protected Color BackColor { get; set; } = SystemColors.Control;
		protected Color ForeColor { get; set; } = SystemColors.ControlText;
		protected StringFormat SFormat { get; set; } = new StringFormat();
		// ************************************************************************
		protected Point m_Location = new Point(0,0);
		protected Size m_Size = new Size(100, 100);
		public Rectangle ClientRectangle { get { return new Rectangle(0, 0, m_Size.Width, m_Size.Height); } }
		protected Bitmap m_OffScr = new Bitmap(100,100,PixelFormat.Format32bppArgb); 
		// ************************************************************************
		public BControl(EditBinary eb)
		{
			SFormat.Alignment = StringAlignment.Center;
			SFormat.LineAlignment = StringAlignment.Center;
			SetEditBinary(eb);
		}
		// ************************************************************************
		public void SetSzie(Size sz)
		{
			if (m_Size != sz)
			{
				m_Size = sz;
				m_OffScr = new Bitmap(sz.Width, sz.Height, PixelFormat.Format32bppArgb);
			}
			DrawOffScr();
		}
		// ************************************************************************
		public void SetSize(int w, int h)
		{
			SetSzie(new Size(w,h));
		}
		// ************************************************************************
		public virtual void DrawOffScr()
		{
			if (m_OffScr == null) return;
			Graphics g = Graphics.FromImage(m_OffScr);
			using(SolidBrush sb = new SolidBrush(BackColor))
			{
				g.FillRectangle(sb,ClientRectangle);
			}
		}
		// ************************************************************************
		public void Draw(Graphics g)
		{
			g.DrawImage(m_OffScr,m_Location);
		}
		// *************************************************************
		public Point? ChkMousePoint(MouseEventArgs e)
		{
			int x = e.X - m_Location.X;
			int y = e.Y - m_Location.Y;
			if((x>=0) && (y>=0)&&(x<m_Size.Width) && (y < m_Size.Height))
			{
				return new Point(x,y);
			}
			else
			{
				return null;
			}
		}

	}
}
