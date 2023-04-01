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
	public partial class StructView : RiderPanelForm
	{
		public MainForm? MainForm = null;
		public RiderForm? RiderForm = null;
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
						structListBox1.SetData(RiderForm.BDataFile.Data);
						RiderForm.SelChanged += (sender, e) =>
						{
							hexEdit1.Value = e.Start;
							structListBox1.StartAdr = e.Start;
						};
					}
				};
			}
		}
		public StructView()
		{
			InitializeComponent();
			structListBox1.Clear();
		}
	}
}
