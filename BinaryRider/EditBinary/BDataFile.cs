﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BinaryRider
{
	public enum CharCodeMode
	{
		UTF8,
		ShiftJIS
	}


	public partial class BDataFile : Component
	{
		// *************************************************************
		public delegate void OpenEventHandler(object sender, EventArgs e);

		//イベントデリゲートの宣言
		public event OpenEventHandler? OpenedFile = null;

		protected virtual void OnOpenedFile(EventArgs e)
		{
			if (OpenedFile != null)
			{
				OpenedFile(this, e);
			}
		}
		public delegate void SaveEventHandler(object sender, EventArgs e);

		//イベントデリゲートの宣言
		public event SaveEventHandler? SavedFile = null;

		protected virtual void OnSavedFile(EventArgs e)
		{
			if (SavedFile != null)
			{
				SavedFile(this, e);
			}
		}
		// *************************************************************
		static Encoding enc8 = Encoding.UTF8;       
		// *************************************************************
		private string m_FileName = "";
		public string FileName { get { return m_FileName; } }
		private string m_Caption = "";
		public string Caption { get { return m_FileName; } }
		// *************************************************************
		// *************************************************************
		private byte[] m_Data = new byte[0];
		public byte[] Data { get { return m_Data; } }
		public long ByteSize { get { return m_Data.Length; } }
		// *************************************************************
		public byte? this[long idx]
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
		public string ToStrUtf8(long idx, ref int len)
		{
			byte[] data = new byte[0];
			byte nd = m_Data[idx];
			len = -1;
			if((nd>=0xF0)&&(nd<=0xF4)&&(idx<m_Data.Length-4))
			{
				data = new byte[4];
				data[0] = nd;
				data[1] = m_Data[idx + 1];
				data[2] = m_Data[idx + 2];
				data[3] = m_Data[idx + 3];
				len = 3;
			}else if ((nd >= 0xE0) && (nd <= 0xEF) && (idx < m_Data.Length - 3))
			{
				data = new byte[3];
				data[0] = nd;
				data[1] = m_Data[idx + 1];
				data[2] = m_Data[idx + 2];
				len = 2;
			}
			else if ((nd >= 0xC2) && (nd <= 0xDF) && (idx < m_Data.Length - 2))
			{
				data = new byte[2];
				data[0] = nd;
				data[1] = m_Data[idx + 1];
				len = 1;
			} else if ((nd >= 0x20) && (nd <= 0x7E))
			{
				data = new byte[1];
				data[0] = nd;
				len = 0;
			}
			if(len<0)
			{
				len = 0;
				return "?";
			}
			else
			{

				return  enc8.GetString(data);

			}
		}
		public string ToStrShiftJIS(long idx,ref int len)
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
					len = 1;
				}
			}
			if (data.Length == 0)
			{
				if (nd >= 0x20)
				{
					data = new byte[1];
					data[0] = nd;
					len = 0;
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
		public string ToChar(CharCodeMode md, long idx, ref int len)
		{
			switch (md) 
			{
				case CharCodeMode.ShiftJIS:
					return ToStrShiftJIS(idx, ref len);
				case CharCodeMode.UTF8:
				default:
					return ToStrUtf8(idx, ref len);
			}
		}
		// *************************************************************
		public BDataFile()
		{
			InitializeComponent();
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // memo: Shift-JISを扱うためのおまじない
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

						string cap = Path.GetFileName(fn);
						string? capD = Path.GetDirectoryName(fn);
						if(capD != null)
						{
							capD= Path.GetFileName(capD);
							cap = capD + "/" + cap;
						}
						m_Caption = cap;
						OnOpenedFile(new EventArgs());
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
		public long FindForward(byte[] bs ,long st)
		{
			long ret = -1;
			if ((bs == null) || (bs.Length <= 0)) return ret;
			if (st < 0) st = 0;
			if((m_Data.Length <= 0)||(st>= m_Data.Length-bs.Length)) return ret;

			long cnt = m_Data.Length - bs.Length;
			for (long i=st; i< cnt; i++)
			{
				if (m_Data[i] == bs[0])
				{
					bool b = true;
					for(long j=1; j<bs.Length;j++)
					{
						if(m_Data[i + j] != bs[j])
						{
							b = false;
							break;
						}
					}
					if(b)
					{
						ret = i;
						break;
					}
				}
			}
			return ret;
		}
		// *************************************************************
		public long FindBackward(byte[] bs, long st)
		{
			long ret = -1;
			if ((bs == null) || (bs.Length <= 0)) return ret;
			if (st >= m_Data.Length - bs.Length) st = m_Data.Length - bs.Length - 1;
			if ((m_Data.Length < bs.Length)) return ret;

			for (long i = st; i >=0; i--)
			{
				if (m_Data[i] == bs[0])
				{
					bool b = true;
					for (long j = 1; j < bs.Length; j++)
					{
						if (m_Data[i + j] != bs[j])
						{
							b = false;
							break;
						}
					}
					if (b)
					{
						ret = i;
						break;
					}
				}
			}
			return ret;
		}
	}
}
