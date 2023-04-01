using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public class SelChangedEventArgs : EventArgs
	{
		public long Start = 0;
		public long Length = 0;
		public SelChangedEventArgs(long s, long l)
		{
			Start = s;
			Length = l;
		}
		public SelChangedEventArgs(BSelection sel)
		{
			Start = sel.Start;
			Length = sel.Length;
		}
	}
	public class BSelection
	{
		//TimeEventArgs型のオブジェクトを返すようにする
		public delegate void SelChangedEventHandler(object sender, SelChangedEventArgs e);

		//イベントデリゲートの宣言
		public event SelChangedEventHandler? SelChanged;

		protected virtual void OnSelChanged(SelChangedEventArgs e)
		{
			if (SelChanged != null)
			{
				SelChanged(this, e);
			}
		}
		// *******************************************************
		private EditBinary? m_BE = null;
		public EditBinary? BE { get { return m_BE; } }
		public void SetEditBinary(EditBinary be)
		{
			m_BE = be;
			if (m_BE != null)
			{
			}
		}

		// *******************************************************
		private long m_Start = 0;
		private long m_Last = 0;
		private long m_Length = 0;
		public long Start
		{
			get { return m_Start; }
			set 
			{
				if (value + m_Length >= 0)
				{
					bool b = (m_Start != value);
					m_Start = value;
					m_Last = m_Start + m_Length;
					if(b) { OnSelChanged(new SelChangedEventArgs(m_Start, m_Length)); }
				}
			}
		}
		public long Length
		{
			get { return m_Length; }
			set 
			{
				if (value < 0) value = 0;
				bool b = (m_Length != value);
				m_Length = value;
				m_Last = m_Start + m_Length;
				if (b) { OnSelChanged(new SelChangedEventArgs(m_Start, m_Length)); }
			}
		}
		public long Last
		{
			get { return m_Last; }
		}
		public void SetStartLength(long st,long len)
		{
			if (st + len < 0) return;
			bool b1 = (m_Start != st);
			bool b2 = (m_Length != len);
			m_Start = st;
			m_Length = len;
			m_Last = m_Start + m_Length;
			if(b1 || b2) { OnSelChanged(new SelChangedEventArgs(m_Start, m_Length)); }
		}
		// *******************************************************
		public BSelection()
		{

		}
		// *******************************************************
		public bool IsInSection(long idx)
		{
			bool ret = false;
			if(m_BE != null)
			{
				if(idx>=m_BE.ByteSize) return ret;
			}
			ret = ((idx >= m_Start) && (idx < m_Last));
			return ret;
		}
		public void SetStartLast(long st, long last) 
		{
			Debug.Write("1");
			if (m_BE != null)
			{
				Debug.Write("2");
				long len = Math.Abs(last - st)+1;
				long ss = 0;
				if(st<=last)
				{
					Debug.Write("3A");
					ss = st;
				}
				else
				{
					Debug.Write("3B");
					ss = last;
				}
				Debug.Write("4");
				bool b1 = (m_Start != ss);
				bool b2 = (m_Length != len);
				long d = m_Start;
				m_Start = ss;
				m_Length = len;
				Debug.WriteLine($"st:{st},last:{last},m_s;{m_Start},n_l{m_Length}");
				m_Last = m_Start + m_Length;
				if (b1 || b2) { OnSelChanged(new SelChangedEventArgs(m_Start, m_Length)); }
			}
		}
	}
}
