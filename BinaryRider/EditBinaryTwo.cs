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
	public partial class EditBinaryTwo : SplitContainer
	{
		public BDataFile? DataFile
		{
			get { return EditBinary1.DataFile; }
			set
			{
				EditBinary1.DataFile = value;
				EditBinary2.DataFile = value;
			}
		}
		public new Font Font
		{
			get { return EditBinary1.Font; }
			set
			{
				EditBinary1.Font = value;
				EditBinary2.Font = value;
			}
		}
		public CharCodeMode CharCodeMode
		{
			get { return EditBinary1.BinSheet.CharCodeMode; }
			set
			{
				EditBinary1.BinSheet.CharCodeMode = value;
				EditBinary2.BinSheet.CharCodeMode = value;
				EditBinary1.Invalidate();
				EditBinary2.Invalidate();
			}
		}
		public EditBinary EditBinary1 { get; set; } = new EditBinary();
		public EditBinary EditBinary2 { get; set; } = new EditBinary();

		public bool IsTwoWin
		{
			get { return (Panel2Collapsed == false); }
			set
			{
				Panel2Collapsed = (value==false);
			}
		}
		public bool IsVurWin
		{
			get { return (Orientation == Orientation.Vertical); }
			set
			{
				if(value)
				{
					Orientation = Orientation.Vertical;
				}
				else
				{
					Orientation = Orientation.Horizontal;
				}
			}
		}
		public EditBinaryTwo()
		{
			InitializeComponent();
			this.Orientation = Orientation.Horizontal;
			EditBinary1.Dock = DockStyle.Fill;
			EditBinary2.Dock = DockStyle.Fill;
			this.Panel1.Controls.Add(EditBinary1);
			this.Panel2.Controls.Add(EditBinary2);
			this.Panel2Collapsed = true;
		}
	}
}
