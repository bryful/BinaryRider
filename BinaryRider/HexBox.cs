using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRider
{
	public partial class HexBox : TextBox
	{
		private bool m_IsHex = true;
		public bool IsHex
		{
			get { return m_IsHex; }
			set 
			{
				if (m_IsHex != value)
				{
					long v = Value;
					m_IsHex = value;
					Value = v;
				}
			}
		}
		public long Value
		{
			get 
			{
				if(this.Text=="") return 0;
				if (m_IsHex)
				{
					return Convert.ToInt64(this.Text, 16);
				}
				else
				{
					return Convert.ToInt64(this.Text);
				}
			}
			set
			{
				m_IsTextChanged = true;
				try
				{
					if (m_IsHex)
					{
						this.Text = Convert.ToString(value, 16).ToUpper();
					}
					else
					{
						this.Text = Convert.ToString(value);
					}
				}
				catch
				{
					this.Text = "";
				}
				m_IsTextChanged = false;

			}
		}
		public HexBox()
		{
			InitializeComponent();
		}
		private bool m_IsTextChanged=false;
		protected override void OnTextChanged(EventArgs e)
		{
			if (m_IsTextChanged) return;
			if (this.Text == "") return;
			m_IsTextChanged = true;

			int st = this.SelectionStart;
			int slen = this.SelectionLength;
			int sz = this.Text.Length;
			string s = "";
			if (m_IsHex)
			{
				for(int i=0;i<sz;i++)
				{
					char c = this.Text[i];
					if (((c>='0')&&(c<='9'))|| ((c >= 'A') && (c <= 'F')) || ((c >= 'a') && (c <= 'f')))
					{
						s += this.Text.Substring(i, 1);
					}
				}
			}
			else
			{
				for (int i = 0; i < sz; i++)
				{
					char c = this.Text[i];
					if ((c >= '0') && (c <= '9'))
					{
						s += this.Text.Substring(i, 1);
					}
				}
			}
			if(this.Text !=s)
			{
				this.Text = s;
				this.SelectionLength = 0;
				this.SelectionStart = s.Length;
			}
			m_IsTextChanged = false;
		}
	}
}
