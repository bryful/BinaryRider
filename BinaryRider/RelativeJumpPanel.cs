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
			btnAddJump.Click += (sender, e) =>
			{
				AddJump();
			};
			btnSubJump.Click += (sender, e) =>
			{
				SubJump();
			};
			btnHis.Click += (sender, e) =>
			{
				ShowHistory();
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
			if (hexEdit1.Value == 0) return;
			RiderForm.RJump(hexEdit1.Value);
			if (IndexOfFromJumps(hexEdit1.Value) == -1)
			{
				jumps.Add(hexEdit1.Value);
			}
		}
		public void SubJump()
		{
			if (RiderForm == null) return;
			if (hexEdit1.Value == 0) return;
			RiderForm.RJump(-1 * hexEdit1.Value);
			if (IndexOfFromJumps(hexEdit1.Value) == -1)
			{
				jumps.Add(hexEdit1.Value);
			}
		}
		public void ShowHistory()
		{
			if (jumps.Count <= 0) return;
			ContextMenuStrip cm = new ContextMenuStrip();
			foreach (long jump in jumps)
			{
				ToolStripMenuItem si = new ToolStripMenuItem();
				si.Text = $"0x{jump:X4}";
				si.Tag = jump;
				si.Click += (sender, e) =>
				{
					ToolStripMenuItem? p = (ToolStripMenuItem?)sender;
					if ((p != null) && (p.Tag != null))
					{
						if (p.Tag is long)
						{
							hexEdit1.Value = (long)p.Tag;
						}
					}
				};
				cm.Items.Add(si);
			}
			cm.Show(Cursor.Position);
		}
	}
}
