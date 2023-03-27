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
	public partial class JumpDialog : Form
	{
		private RiderForm? rf = null;
		public RiderForm? RiderForm
		{
			get { return rf; }
			set
			{
				rf = value;
				if (rf != null)
				{
					hexEdit1.Value = rf.Selection.Start;
					InfoDisp();
					ChkEnabled();
					hexEdit1.ValueChanged += (sender, e) =>
					{
						ChkEnabled();
					};
				}
			}

		}
		private void InfoDisp()
		{
			if (rf != null)
			{
				long st = rf.Selection.Start;
				long mx = rf.BDataFile.ByteSize - 1;
				if (mx < 0) mx = 0;
				lbInfo.Text = $"Position:0x{st:X}/ Max:0x{mx:X}";
			}
		}
		public long Adress
		{
			get { return hexEdit1.Value; }
			set
			{
				hexEdit1.Value = value;
			}
		}
		public JumpDialog()
		{
			InitializeComponent();
			ChkEnabled();
		}
		private void ChkEnabled()
		{
			if (rf != null)
			{
				long sz = rf.BDataFile.ByteSize;
				long v = hexEdit1.Value;
				btnJump.Enabled = ((v >= 0) && (v < sz));
			}

		}
	}
}
