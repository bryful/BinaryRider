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
	public partial class FindDialog : RiderPanelForm
	{
		public MainForm? MainForm = null;
		public RiderForm? RiderForm = null;
		public void SetMainForm(MainForm mf)
		{
			MainForm = mf;
			if (MainForm != null)
			{
				RiderForm = MainForm.ActiveRider;
				MainForm.TargetRider += (sender, e) =>
				{
					RiderForm = e.Rider;
					if (RiderForm != null)
					{
					}
				};
			}
		}
		public FindDialog()
		{
			InitializeComponent();
			ChkRB();
			rbByte.Click += (sender, e) =>
			{
				ChkRB();
			};
			rbString.Click += (sender, e) =>
			{
				ChkRB();
			};
		}
		private void ChkRB()
		{
			bool b = rbByte.Checked;
			cmbByte.Enabled = b;
			cmbString.Enabled = !b;
			cmbCharMode.Enabled = !b;
		}
		private ByteStrings? ChkByteStrings()
		{
			ByteStrings? ret = null;
			if (RiderForm == null) return ret;

			bool IsByte = rbByte.Checked;

			string s = "";
			if (IsByte)
			{
				ret = new ByteStrings(FindMode.String, cmbByte.Text);
			}
			else
			{
				switch (cmbCharMode.CharCodeMode)
				{
					case CharCodeMode.ShiftJIS:
						ret = new ByteStrings(FindMode.StringShiftJIS, cmbString.Text);
						break;
					case CharCodeMode.UTF8:
						ret = new ByteStrings(FindMode.StringUTF8, cmbString.Text);
						break;
				}
			}
			return ret;

		}

		private void btnFromTop_Click(object sender, EventArgs e)
		{
			ByteStrings? bs = ChkByteStrings();
			if ((bs == null) || (RiderForm == null))
			{
				tbResult.Text = "ERROR1";
				return;
			}
			if ((bs.Bytes == null) || (bs.Bytes.Length <= 0))
			{
				tbResult.Text = "ERROR2\r\n" + bs.Code;
				return;
			}
			long a = RiderForm.FindForward(bs.Bytes, 0);
			if (a < 0)
			{
				tbResult.Text = "nothing!\r\n" + bs.ByteString;
			}
			else
			{
				tbResult.Text = $"Find:{a:X4}";
				RiderForm.Jump(a, bs.Bytes.Length);
				RiderForm.Activate();
			}
		}

		private void btnFromEnd_Click(object sender, EventArgs e)
		{
			ByteStrings? bs = ChkByteStrings();
			if ((bs == null) || (RiderForm == null))
			{
				tbResult.Text = "ERROR1";
				return;
			}
			if ((bs.Bytes == null) || (bs.Bytes.Length <= 0))
			{
				tbResult.Text = "ERROR2\r\n" + bs.Code;
				return;
			}
			long a = RiderForm.FindBackward(bs.Bytes, RiderForm.BDataFile.ByteSize - 1);
			if (a < 0)
			{
				tbResult.Text = "nothing!";
			}
			else
			{
				tbResult.Text = $"Find:{a:X4}";
				RiderForm.Jump(a, bs.Bytes.Length);
				RiderForm.Activate();
			}
		}

		private void btnForward_Click(object sender, EventArgs e)
		{
			ByteStrings? bs = ChkByteStrings();
			if ((bs == null) || (RiderForm == null))
			{
				tbResult.Text = "ERROR1";
				return;
			}
			if ((bs.Bytes == null) || (bs.Bytes.Length <= 0))
			{
				tbResult.Text = "ERROR2\r\n" + bs.Code;
				return;
			}
			long adr = RiderForm.Selection.Start - 1;
			long a = RiderForm.FindBackward(bs.Bytes, adr);
			if (a < 0)
			{
				tbResult.Text = "nothing!";
			}
			else
			{
				tbResult.Text = $"Find:{a:X4}";
				RiderForm.Jump(a, bs.Bytes.Length);
				RiderForm.Activate();
			}
		}

		private void btnBackward_Click(object sender, EventArgs e)
		{
			ByteStrings? bs = ChkByteStrings();
			if ((bs == null) || (RiderForm == null))
			{
				tbResult.Text = "ERROR1";
				return;
			}
			if ((bs.Bytes == null) || (bs.Bytes.Length <= 0))
			{
				tbResult.Text = "ERROR2\r\n" + bs.Code;
				return;
			}
			long adr = RiderForm.Selection.Start + 1;
			long a = RiderForm.FindForward(bs.Bytes, adr);
			if (a < 0)
			{
				tbResult.Text = "nothing!";
			}
			else
			{
				tbResult.Text = $"Find:{a:X4}";
				RiderForm.Jump(a, bs.Bytes.Length);
				RiderForm.Activate();
			}
		}
	}
}

