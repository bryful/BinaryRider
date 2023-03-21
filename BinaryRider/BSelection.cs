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
				//ChkSize();
			}
		}

		// *******************************************************
		private int m_Start = -1;
		private int m_Length = 0;
		public int Start
		{
			get { return m_Start; }
			set 
			{
				if (value + Length >= 0)
				{
					m_Start = value;
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
			}
		}
		// *******************************************************
		public BSelection()
		{

		}
		// *******************************************************
	}
}
