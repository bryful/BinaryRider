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
	public partial class JumpPanel : RiderPanelForm
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
					if (RiderForm != null)
					{
						RiderForm.SelChanged += (sender, e) =>
						{
							heAbsAdress.Value = e.Start;
						};
					}
				};
			}
		}
		public JumpPanel()
		{
			InitializeComponent();
			heRelative.ValueChanged += (sender, e) =>
			{
				btnSub.Enabled =
				btnAdd.Enabled = ((heRelative.Value > 0) && (RiderForm != null));

			};
			btnAdd.Click += (sender, e) =>
			{
				AddJump();
			};
			btnSub.Click += (sender, e) =>
			{
				SubJump();
			};
			btnHis.Click += (sender, e) =>
			{
				ShowHistory();
			};
			btnPush.Click += (sender, e) =>
			{
				SetAbsAdress();
			};
			btnTop.Click += (sender, e) =>
			{
				if (RiderForm != null) RiderForm.JumpTop();
			};
			btnEnd.Click += (sender, e) =>
			{
				if (RiderForm != null) RiderForm.JumpEnd();
			};
			btnJump.Click += (sender, e) =>
			{
				if (RiderForm != null)
				{
					RiderForm.Jump(heAbsAdress.Value);
				}
			};
			lbHistory.DoubleClick += (sender, e) =>
			{
				if (RiderForm != null)
				{
					string? s = lbHistory.SelectedItem.ToString();
					if (s != null)
					{
						try
						{
							long a = Convert.ToInt64(s, 16);
							RiderForm.Jump(a);
						}
						catch
						{

						}
					}
				}

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
			if (heRelative.Value == 0) return;
			RiderForm.RJump(heRelative.Value);
			if (IndexOfFromJumps(heRelative.Value) == -1)
			{
				jumps.Add(heRelative.Value);
			}
		}
		public void SubJump()
		{
			if (RiderForm == null) return;
			if (heRelative.Value == 0) return;
			RiderForm.RJump(-1 * heRelative.Value);
			if (IndexOfFromJumps(heRelative.Value) == -1)
			{
				jumps.Add(heRelative.Value);
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
							heRelative.Value = (long)p.Tag;
						}
					}
				};
				cm.Items.Add(si);
			}
			cm.Show(Cursor.Position);
		}
		private string HexStr(long v)
		{
			return $"0x{v:X6}";
		}
		private int IndexOfLbHistory(long l)
		{
			int ret = -1;
			string s = HexStr(l);
			if (lbHistory.Items.Count > 0)
			{
				for (int i = 0; i < lbHistory.Items.Count; i++)
				{
					if (lbHistory.Items[i].ToString() == s)
					{
						ret = i;
						break;
					}
				}
			}
			return ret;
		}
		public void SetAbsAdress()
		{
			if (RiderForm != null)
			{
				long adr = RiderForm.Selection.Start;
				if (adr > 0)
				{
					if (IndexOfLbHistory(adr) < 0)
					{
						lbHistory.Items.Add(HexStr(adr));
					}
				}
			}
		}
	}
}
