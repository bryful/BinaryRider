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
	public partial class RelativeJumpPanel : RiderPanelForm
	{
		public MainForm? MainForm = null;
		public RiderForm? RiderForm = null;
		private List<long> jumps = new List<long>();
		public void SetMainForm(MainForm mf)
		{
			MainForm = mf;
			if (MainForm != null)
			{
				MainForm.TargetRider += (sender, e) =>
				{
					RiderForm = e.Rider;
				};
			}
		}
		public RelativeJumpPanel()
		{
			InitializeComponent();
			hexEdit1.ValueChanged += (sender, e) =>
			{
				btnSubJump.Enabled =
				btnAddJump.Enabled = ((hexEdit1.Value > 0) && (RiderForm != null));

			};
		}
		private int IndexOfFromJumps(long adr)
		{
			int ret = -1;
			if (jumps.Count <= 0) return ret;
			return jumps.IndexOf(adr);
		}
		public void AddJump()
		{
			if (RiderForm == null) return;
			RiderForm.RJump(hexEdit1.Value);
			if (IndexOfFromJumps(hexEdit1.Value) == -1)
			{
				jumps.Add(hexEdit1.Value);
			}
		}
		public void SubJump()
		{
			if (RiderForm == null) return;
			RiderForm.RJump(-1 * hexEdit1.Value);
			if (IndexOfFromJumps(hexEdit1.Value) == -1)
			{
				jumps.Add(hexEdit1.Value);
			}
		}
	}
}
