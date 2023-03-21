using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public enum DispMode
	{
		Hex16=16,
		Hex1=1,
	}
	public class BDisp
	{
		// *******************************************************
		private EditBinary? m_BE = null;
		public void SetEditBinary(EditBinary be)
		{
			m_BE = be;
			if(m_BE != null)
			{
				ChkSize();
			}
		}
		// *******************************************************
		private DispMode m_DispMode= DispMode.Hex16;
		public DispMode DispMode
		{
			get { return m_DispMode; }
			set
			{
				m_DispMode = value;
				ChkSize();
			}
		}
		// *******************************************************
		private int m_X = 0;
		private int m_Y = 0;
		private int m_MaxX = 0;
		private int m_MaxY = 0;
		private int m_LineMax = 0;
		private int m_LineStart = 0;
		private int m_LineEnd = 0;
		public int X
		{
			get { return m_X; }
			set 
			{
				m_X = value;
				if (m_X > m_MaxX) m_X = m_MaxX;
			}
		}
		public int Y
		{
			get { return m_Y; }
			set 
			{ 
				m_Y = value;
				if (m_Y > m_MaxY) m_Y = m_MaxY;
			}
		}
		public int MaxX
		{
			get { return m_MaxX; }
		}
		public int MaxY
		{
			get { return m_MaxY; }
		}
		public int LineMax
		{
			get { return m_LineMax; }
		}
		// *******************************************************
		public void ChkSize()
		{
			if (m_BE != null)
			{
				int sz = m_BE.ByteSize;
				if(sz == 0) 
				{
					m_X = 0;
					m_Y = 0;
					m_MaxX = 0;
					m_MaxY = 0;
				}
				else
				{
					int line = 0;
					int xc = 0;
					int yc = 0;
					int lc = m_BE.Height / m_BE.BSize.LineHeight;
					if (m_BE.Height % m_BE.BSize.LineHeight > 0) lc++;
					lc -= 1;
					switch (m_DispMode)
					{
						case DispMode.Hex16:
							line = sz / 0x10;
							if (sz % 0x10 != 0) line++;
							m_LineMax = line;
							yc = m_BE.BSize.LineHeight * (line + 1);
							xc = m_BE.BSize.ByteLeft 
								+ 16 * m_BE.BSize.ByteWidth 
								+ 16 * m_BE.BSize.CharWidth;

							break;
						case DispMode.Hex1:
							line = sz;
							yc = m_BE.BSize.LineHeight * (line+1);
							xc = m_BE.BSize.ByteLeft
								+ 1 * m_BE.BSize.ByteWidth
								+ 2 * m_BE.BSize.CharWidth;
							m_LineMax = sz;
							break;
					}
					m_MaxX = xc - m_BE.Width;
					if (m_MaxX < 0) m_MaxX = 0;
					if (m_X > m_MaxX) m_X = m_MaxX;
					else if (m_X < 0) m_X = 0;
					m_MaxY = yc - m_BE.Height;
					if (m_MaxY < 0) m_MaxY = 0;
					if (m_Y > m_MaxY) m_Y = m_MaxY;
					else if (m_Y < 0) m_Y = 0;

				}

			}
		}
	}
}
