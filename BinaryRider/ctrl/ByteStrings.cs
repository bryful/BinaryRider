using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public enum FindMode
	{
		StringUTF8,
		StringShiftJIS,
		String
	}
	public class ByteStrings
	{
		private byte[]? m_bytes = null;
		public byte[]? Bytes { get { return m_bytes; } }
		private string m_Code="";

		public string Code
		{
			get { return m_Code; }
		}
		// *************************************************************
		public string ByteString
		{
			get
			{
				string ret = "";
				if((m_bytes!=null)&&(m_bytes.Length>0))
				{
					for(int i=0; i<m_bytes.Length; i++)
					{
						if (ret != "") ret += ",";
						ret += $"{m_bytes[i]:X2}";
					}
				}
				return ret;
			}
		}
		// *************************************************************
		public bool SetCode(FindMode m, string str)
		{
			m_Code = str;
			m_bytes = ToByte(m, str);
			return (m_bytes != null);

		}
		// *************************************************************
		public ByteStrings(FindMode m,string str)
		{
			SetCode(m, str);
		}
		// *************************************************************
		private byte[]? ToByte(FindMode mode, string code)
		{
			byte[]? ret = null;
			if (code.Length <= 0) return ret;
			switch (mode)
			{
				case FindMode.String:
					ret = ByteArray(code);
					break;
				case FindMode.StringShiftJIS:
					ret = Encoding.GetEncoding("shift_jis").GetBytes(code); ;
					break;
				case FindMode.StringUTF8:
					ret = Encoding.UTF8.GetBytes(code);
					break;

			}
			return ret;
		}
		// *************************************************************
		private byte[]? ByteArray(string s)
		{
			byte[]? ret = null;
			if (s == "") return ret;
			string[] sa = s.Split(new char[] { ',' });
			if (sa.Length <= 0) return ret;
			ret = new byte[(int)sa.Length];
			for (int i = 0; i < sa.Length; i++)
			{
				int v = 0;
				bool h = false;
				if (sa[i].Length >= 3)
				{
					h = ((sa[i][0] == '0') && ((sa[i][1] == 'x') || (sa[i][1] == 'X')));
				}
				try
				{
					if (h)
					{
						v = Convert.ToInt32(sa[i], 16);
					}
					else
					{
						v = Convert.ToInt32(sa[i], 10);
					}
				}
				catch
				{
					ret = null;
					return ret;
				}
				if ((v < 0) || (v > 255))
				{
					ret = null;
					return ret;
				}
				ret[i] = (byte)v;
			}
			return ret;
		}
	}
}
