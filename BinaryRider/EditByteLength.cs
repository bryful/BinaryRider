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
	public class BLengthChangedEventArgs : EventArgs
	{
		public long BLength = 0;
		public BLengthChangedEventArgs(long s)
		{
			BLength = s;
		}
	}
	public partial class EditByteLength : NumericUpDown
	{
		public delegate void BLengthChangedEventHandler(object sender, BLengthChangedEventArgs e);

		//イベントデリゲートの宣言
		public event BLengthChangedEventHandler? BLengthChanged;

		protected virtual void OnBLengthChanged(BLengthChangedEventArgs e)
		{
			if (BLengthChanged != null)
			{
				BLengthChanged(this, e);
			}
		}
		public long BLength
		{
			get { return (long)Value; }
			set 
			{
				long v = value;
				if (v < 0) v = 0;
				bool b = (Value != v);
				Value = v;
				
				if(b)
				{
					OnBLengthChanged(new BLengthChangedEventArgs(v));
				}
			}
		}
		public EditByteLength()
		{
			InitializeComponent();
			this.Maximum = 0xFFFFFFFF;
		}
		protected override void OnValueChanged(EventArgs e)
		{
			OnBLengthChanged(new BLengthChangedEventArgs((long)base.Value));
		}
	}
}
