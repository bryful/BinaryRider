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
	public partial class ComboHistory : ComboBox
	{
		public ComboHistory()
		{
			InitializeComponent();
		}
		// ******************************************************************
		private int FindHistroy(string s)
		{
			int ret = -1;
			if(s=="") return ret;
			if(this.Items.Count <= 0) return ret;
			for(int i=0; i<this.Items.Count; i++)
			{
				if (String.Compare(s, this.Items[i].ToString(),true)==0)
				{
					ret = i;
					break;
				}
			}
			return ret;
		}
		// ******************************************************************
		public void SetHistroy()
		{
			int idx = FindHistroy(this.Text);
			if(idx <0)
			{
				this.Items.Add(this.Text);
			}
		}

	}
}
