﻿using System;
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
					hexBox1.Value = rf.Selection.Start;
					InfoDisp();
					ChkEnabled();
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
				if (hexBox1.IsHex)
				{
					lbInfo.Text = $"Position:0x{st:X}/ Max:0x{mx:X}";
				}
				else
				{
					lbInfo.Text = $"Position:  {st}/ Max:  {mx}";
				}
			}
		}
		public long Adress
		{
			get { return hexBox1.Value; }
			set
			{
				hexBox1.Value = value;
			}
		}
		public JumpDialog()
		{
			InitializeComponent();
			cbHex.Checked = hexBox1.IsHex;
			cbHex.CheckedChanged += (sender, e) =>
			{
				hexBox1.IsHex = cbHex.Checked;
				InfoDisp();
			};
			ChkEnabled();
			hexBox1.TextAlignChanged += (sender, e) =>
			{
				ChkEnabled();
			};
		}
		private void ChkEnabled()
		{
			if (rf != null)
			{
				long sz = rf.BDataFile.ByteSize;
				long v = hexBox1.Value;
				btnJump.Enabled = ((v >= 0) && (v < sz));
			}

		}
	}
}
