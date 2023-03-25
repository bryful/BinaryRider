using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public class BSelection
	{
		// *******************************************************
		private EditBinary? m_BE = null;
		public void SetEditBinary(EditBinary be)
		{
			m_BE = be;
			if (m_BE != null)
			{
			}
		}

		// *******************************************************
		private int m_Start = 0;
		private int m_Last = 0;
		private int m_Length = 0;
		public int Start
		{
			get { return m_Start; }
			set 
			{
				if (value + m_Length >= 0)
				{
					m_Start = value;
					m_Last = m_Start + m_Length;
				}
			}
		}
		public int Length
		{
			get { return m_Length; }
			set 
			{
				if (value < 0) value = 0;
				m_Length = value;
				m_Last = m_Start + m_Length;
			}
		}
		public int Last
		{
			get { return m_Last; }
		}
		// *******************************************************
		public BSelection()
		{

		}
		// *******************************************************
		public bool IsInSection(int idx)
		{
			bool ret = false;
			if(m_BE != null)
			{
				if(idx>=m_BE.ByteSize) return ret;
			}
			ret = ((idx >= m_Start) && (idx < m_Last));
			return ret;
		}
		public void SetStartLast(int st,int  last) 
		{
			if (m_BE != null)
			{
				Length = Math.Abs(last - st)+1;
				if(st<=last)
				{
					m_Start = st;
				}
				else
				{
					m_Start = last;
				}
				m_Last = m_Start + m_Length;
			}
		}
	}
}
