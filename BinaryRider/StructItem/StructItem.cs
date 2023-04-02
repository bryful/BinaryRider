using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BinaryRider
{

	public class StructItem
	{
		public long Index { get; set; } = 0;
		public long Adress { get; set; } = 0;
		private SKind m_Kind  = SKind.None;
		public SKind Kind
		{
			get { return m_Kind; }
			set 
			{
				m_Kind = value;

				int bb = (int)m_Kind / 10;
				if(bb<=0) bb = 1;
				if (m_Bytes.Length != bb)
				{
					Array.Resize(ref m_Bytes, bb);
				}
			}

		}
		public long ByteLength 
		{
			get { return m_Bytes.Length; }
			set 
			{
				if ((m_Kind == SKind.SStrUtf8)|| (m_Kind == SKind.SStrShiftJIS))
				{
					if (value <= 0) value = 1;
					Array.Resize(ref m_Bytes, (int)value);
				}
				else
				{
					int bb = (int)m_Kind / 10;
					if (bb <= 0) bb = 1;
					if (m_Bytes.Length != bb)
					{
						Array.Resize(ref m_Bytes, bb);
					}

				}
			}
		}
		//public long Adress { get; set; } = 0;
		public long RAdress { get; set; } = 0;
		public bool IsBigEndian { get; set; } = true;
		public object? Value { get; set; } = null;
		public string Comment { get; set; } = "";
		private byte[] m_Bytes = new byte[1];
		public byte[] Bytes {  get { return m_Bytes; } }
		public string ValueStr()
		{
			string ret = "";
			long v = 0;
			if (m_Bytes.Length <= 8)
			{
				if (IsBigEndian)
				{
					v = (long)m_Bytes[0];
					if(m_Bytes.Length>=2)
					{
						for (int i = 1; i < m_Bytes.Length; i++)
						{
							v <<= 8;
							v += (long)m_Bytes[i];
						}
					}
				}
				else
				{
					v = (long)m_Bytes[m_Bytes.Length - 1];
					if (m_Bytes.Length >= 2)
					{
						for (int i = m_Bytes.Length - 2; i >= 0; i--)
						{
							v <<= 8;
							v += (long)m_Bytes[i];
						}
					}
				}
				ret = $"0x{v:X}({v})";
			}
			else
			{
				for(int i=0; i<m_Bytes.Length;i++)
				{
					if (ret != "") ret += ",";
					ret += $"0x{m_Bytes[i]:X2}";
				}
			}
			ret += $" - \"{ToStrUtf8()}\" : {Comment}";
			return ret;
		}
		public StructItem()
		{

		}
		public new string ToString()
		{
			return $"i:{Adress:X},a:{RAdress:X},l:{ByteLength:X}";
		}
		// *************************************************************
		public string ToStrUtf8()
		{
			try
			{
				return Encoding.UTF8.GetString(m_Bytes);
			}
			catch
			{
				return String.Empty;
			}
		}
		public string ToStrShiftJIS()
		{

			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // memo: Shift-JISを扱うためのおまじない
			try
			{
				return System.Text.Encoding.GetEncoding(932).GetString(m_Bytes);
			}
			catch
			{
				return String.Empty;
			}
		}
		public JsonObject ToJson()
		{
			JsonObject ret = new JsonObject();
			ret.Add("SKind", (int)m_Kind);
			ret.Add("ByteLength", (int)ByteLength);
			ret.Add("IsBigEndian", (bool)IsBigEndian);
			ret.Add("Comment", (string)Comment);
			return ret;
		}
		public bool FromJson(JsonObject? jo)
		{
			bool ret = false;
			if (jo == null) return ret;
			try
			{
				int cnt = 0;
				string key = "SKind";
				if (jo.ContainsKey(key))
				{
					int? v = jo[key].GetValue<int?>();
					if(v != null)
					{
						m_Kind = (SKind)v;
						cnt++;
					}
				}
				key = "ByteLength";
				if (jo.ContainsKey(key))
				{
					long? v1 = jo[key].GetValue<long?>();
					if (v1 != null)
					{
						ByteLength = (long)v1;
						cnt++;
					}
				}
				key = "IsBigEndian";
				if (jo.ContainsKey(key))
				{
					bool? b = jo[key].GetValue<bool?>();
					if (b != null)
					{
						IsBigEndian = (bool)b;
						cnt++;
					}
				}
				key = "Comment";
				if (jo.ContainsKey(key))
				{
					string? s = jo[key].GetValue<string?>();
					if (s != null)
					{
						Comment = (string)s;
						cnt++;
					}
				}
				ret = (cnt == 4);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
	}


}
