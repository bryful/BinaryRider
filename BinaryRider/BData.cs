using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public class BData
	{
		private string m_FileName = "";
		public string FileName { get { return m_FileName; } }
		// *************************************************************
		private byte[] m_Data = new byte[0];
		public byte[] Data { get { return m_Data; } }
		public int ByteSize { get { return m_Data.Length; } }
		
		public byte? this[int idx]
		{
			get
			{
				byte? ret = null;
				if ((idx >= 0) && (idx < m_Data.Length))
				{
					return m_Data[idx];
				}
				return ret;
			}
		}
		// *************************************************************
		public BData() 
		{

		}
		// *************************************************************
		public void Clear()
		{
			m_Data = new byte[0];
			m_FileName = "";
		}
		// *************************************************************
		public bool LoadFile(string fn)
		{
			bool ret = false;
			if (File.Exists(fn) == false) return ret;
			try
			{
				m_Data = new byte[0];
				m_FileName = "";
				using (FileStream fs = new FileStream(fn, FileMode.Open, FileAccess.Read))
				{
					byte[] bs = new byte[fs.Length];
					int sz = fs.Read(bs, 0, bs.Length);
					if (sz == fs.Length)
					{
						m_Data = bs;
						m_FileName = fn;
						ret = true;
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// *************************************************************
	}
}
