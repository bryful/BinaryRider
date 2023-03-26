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

		public EditBinary? ActiveEditBinary = null;

		public bool IsTwoWin
		{
			get { return (Panel2Collapsed == false); }
			set
			{
				Panel2Collapsed = (value==false);
				if(Panel2Collapsed==true)
				{
					ActiveEditBinary = EditBinary1;
				}
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
			ActiveEditBinary = this.EditBinary1;
			EditBinary1.GotFocus += (sender, e) =>
			{
				ActiveEditBinary = EditBinary1;
			};
			EditBinary2.GotFocus += (sender, e) =>
			{
				ActiveEditBinary = EditBinary2;
			};
			EditBinary1.Focus();

		}
		public BSelection Selection
		{
			get
			{
				if(ActiveEditBinary != null)
				{
					return ActiveEditBinary.Selection;
				}
				else
				{
					return new BSelection();
				}
			}
			set
			{
				if (ActiveEditBinary != null)
				{
					ActiveEditBinary.Selection = value;
				}
			}
		}
		public bool Jump(int adr, int len=1)
		{
			bool ret =false;
			if (ActiveEditBinary != null)
			{
				ret = ActiveEditBinary.Jump(adr,len);
			}
			return ret;
		}
		public bool JumpTop()
		{
			bool ret = false;
			if (ActiveEditBinary != null)
			{
				ret = ActiveEditBinary.JumpTop();
			}
			return ret;
		}
		public bool JumpEnd()
		{
			bool ret = false;
			if (ActiveEditBinary != null)
			{
				ret = ActiveEditBinary.JumpEnd();
			}
			return ret;
		}
	}
}
