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
	public partial class RiderForm : Form
	{
		public RiderForm()
		{
			AllowDrop = true;
			InitializeComponent();
		}
		protected override void OnResize(EventArgs e)
		{
			int mh = 30;
			int w = this.ClientSize.Width - vScrollBar1.Width;
			int h = this.ClientSize.Height - mh;
			editBinary1.Location = new Point(0, mh);
			vScrollBar1.Location = new Point(w, mh);
			editBinary1.Size = new Size(w, h);
			vScrollBar1.Size = new Size(vScrollBar1.Width, h);
		}
		// ***************************************************************
		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			//base.OnDragEnter(drgevent);
			if (drgevent.Data != null)
			{
				if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
					drgevent.Effect = DragDropEffects.Copy;
				else
					drgevent.Effect = DragDropEffects.None;
			}
		}
		// ***************************************************************
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if (drgevent.Data != null)
			{
				string[] fileNames = (string[])drgevent.Data.GetData(DataFormats.FileDrop, false);

				foreach (string fileName in fileNames)
				{
					if (editBinary1.LoadFile(fileName) == true)
					{
						break;
					}
				}

			}
		}
		// ***************************************************************
	}

}
