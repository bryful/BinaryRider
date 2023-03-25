using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public class BDisp
	{
		static public readonly int HexC = 0x10;
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

		// *******************************************************
		private int m_Y = 0;
		private int m_MaxY = 0;
		private int m_LineMax = 0;
		private int m_LineDisp = 0;

		private int m_DispStartAdress = 0;
		public int DispStartAdress 
		{
			get { return m_DispStartAdress; }
			set
			{
				if (m_BE != null) {
					m_DispStartAdress = value;
					if (m_BE.ByteSize > 0)
					{
						if (m_DispStartAdress < 0)
						{
							m_DispStartAdress = 0;
						}
						else if (m_DispStartAdress >= m_BE.ByteSize)
						{
							m_DispStartAdress = m_BE.ByteSize - 1;
						}
						m_BE.ChkSize();
					}
				}
				else
				{
					m_DispStartAdress = 0;
				}
			}
		}
		public int DispByteSize
		{
			get 
			{
				int ret = 0;
				if((m_BE != null)&&(m_BE.ByteSize>0))
				{
					ret = m_BE.ByteSize - m_DispStartAdress;
					if (ret < 0) ret = 0;
				}
				return ret; 
			}
		}
		// *******************************************************
		public int Y
		{
			get { return m_Y; }
			set 
			{ 
				m_Y = value;
				if (m_Y < 0) m_Y = 0;
				if (m_Y > m_MaxY) m_Y = m_MaxY;
			}
		}
		public int MaxY
		{
			get { return m_MaxY; }
		}
		public int LineMax
		{
			get { return m_LineMax; }
		}
		public int LineDisp
		{
			get { return m_LineDisp; }
		}
		// *******************************************************
		public void ChkSize()
		{
			bool InitFlag=true;
			if (m_BE != null)
			{

				int sz = m_BE.DispByteSize;
				int h = m_BE.BSz.LineHeight;
				int dh = m_BE.Height - h;// アドレスヘッダー分減らして計算
				if (sz > 0) 
				{
					//最大行数を計算
					m_LineMax = sz / BDisp.HexC;
					if (sz % BDisp.HexC > 0) m_LineMax++;
					//表示されている行数
					m_LineDisp = dh / h;
					if (dh % h > 0) m_LineDisp++; // 16以下の時は＋１
					if (m_LineDisp > m_LineMax) m_LineDisp = m_LineMax;

					m_MaxY = m_LineMax * h - dh + h/2;
					if (m_MaxY < 0) m_MaxY = 0;
					if (m_Y > m_MaxY) m_Y = m_MaxY;
					else if (m_Y < 0) m_Y = 0;


					InitFlag = false;
				}

			}
			if(InitFlag==true)
			{
				m_Y = 0;
				m_MaxY = 0;
				m_LineMax = 0;
				m_LineDisp = 0;
			}
		}
	}
}
