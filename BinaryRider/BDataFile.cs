using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public enum EnCodeMode
	{
		ShiftJIS,
		UTF8
	}
	public partial class BDataFile : Component
	{
		// *************************************************************
		private string m_FileName = "";
		public string FileName { get { return m_FileName; } }
		// *************************************************************
		// *************************************************************
		private byte[] m_Data = new byte[0];
		public byte[] Data { get { return m_Data; } }
		public int ByteSize { get { return m_Data.Length; } }
		// *************************************************************
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
		public string ToStrUtf8(int idx)
		{
			return "";
		}
		public string ToStrShiftJIS(int idx,ref int len)
		{
			byte[] data = new byte[0];
			byte nd = m_Data[idx];
			if (((nd >= 0x80) && (nd <= 0xA0)) || (nd >= 0xE0))
			{
				if(idx<m_Data.Length-1)
				{
					data = new byte[2];
					data[0] = nd;
					data[1] = m_Data[idx+1];
					len = 2;
				}
			}
			if (data.Length == 0)
			{
				if (nd >= 0x20)
				{
					data = new byte[1];
					data[0] = nd;
					len = 1;
				}
				else
				{
					len = 0;
					return "?";
				}
			}
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // memo: Shift-JISを扱うためのおまじない
			return System.Text.Encoding.GetEncoding(932).GetString(data); ;
		}
		// *************************************************************
		public BDataFile()
		{
			InitializeComponent();
		}

		// *************************************************************
		public BDataFile(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
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
