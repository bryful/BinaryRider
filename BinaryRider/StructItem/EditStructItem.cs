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
	public class StructItemChangedEventArgs : EventArgs
	{
		public StructItem? StructItem = null;
		public StructItemChangedEventArgs(StructItem? b)
		{
			StructItem = b;
		}
	}
	public partial class EditStructItem : Control
	{
		// ***********************************************
		public event EventHandler? BAdd;
		protected virtual void OnBAdd(EventArgs e){if (BAdd != null){ BAdd(this, e);}}
		public event EventHandler? BApply;
		protected virtual void OnBApply(EventArgs e) { if (BApply != null) { BApply(this, e); } }
		public event EventHandler? BUp;
		protected virtual void OnBUp(EventArgs e) { if (BUp != null) { BUp(this, e); } }
		public event EventHandler? BDown;
		protected virtual void OnBDown(EventArgs e) { if (BDown != null) { BDown(this, e); } }
		public event EventHandler? BDelete;
		protected virtual void OnBDelete(EventArgs e) { if (BDelete != null) { BDelete(this, e); } }
		
		// ***********************************************
		private Button btnAdd = new Button();
		private Button btnUp = new Button();
		private Button btnDown = new Button();
		private Button btnDelete = new Button();
		private Button btnApply = new Button();
		private ComboSKind cmbSkind = new ComboSKind();
		private EditByteLength EditBLength = new EditByteLength();
		private CheckBox cbBigEndian = new CheckBox();
		private TextBox tbCommant = new TextBox();

		private int m_Width2 = 0;
		// *********************************************************
		public int SKindWidth
		{
			get { return cmbSkind.Width; }
			set
			{
				cmbSkind.Width = value;
				ChkSize();
			}
		}
		public int ByteLengthWidth
		{
			get { return EditBLength.Width; }
			set
			{
				EditBLength.Width = value;
				ChkSize();
			}
		}
		public int BigEndianWidth
		{
			get { return cbBigEndian.Width; }
			set
			{
				cbBigEndian.Width = value;
				ChkSize();
			}
		}
		public int CommantWidth
		{
			get { return tbCommant.Width; }
			set
			{
				tbCommant.Width = value;
				ChkSize();
			}
		}
		public void SetStructItem(StructItem si)
		{
			cmbSkind.SKind = si.Kind;
			EditBLength.BLength = si.ByteLength;
			cbBigEndian.Checked = si.IsBigEndian;
			tbCommant.Text = si.Comment;
		}
		public StructItem GetStructItem()
		{
			StructItem si = new StructItem();
			si.Kind = cmbSkind.SKind;
			si.ByteLength = EditBLength.BLength;
			si.IsBigEndian = cbBigEndian.Checked;
			si.Comment = tbCommant.Text;
			return si;
		}
		public StructItem StructItem
		{
			get { return GetStructItem(); }
			set { SetStructItem(value); }
		}
		// *********************************************************
		public EditStructItem()
		{
			InitializeComponent();
			int h = cmbSkind.Height;
			btnAdd.Size = new Size(40, h);
			btnAdd.Text = "Add";
			btnUp.Size = new Size(40, h);
			btnUp.Text = "Up";
			btnDown.Size = new Size(40, h);
			btnDown.Text = "Down";
			btnDelete.Size = new Size(40, h);
			btnDelete.Text = "Del";
			btnApply.Size = new Size(50, h);
			btnApply.Text = "Apply";
			cmbSkind.Size = new Size(70, h);
			EditBLength.Size = new Size(50, h);
			cbBigEndian.Size = new Size(80, h);

			tbCommant.Size = new Size(120, h);
			cbBigEndian.Text = "BigEndian";
			cbBigEndian.Checked = true;
			ChkSize();
			this.Controls.Add(btnUp);
			this.Controls.Add(btnDown);
			this.Controls.Add(btnDelete);
			this.Controls.Add(btnAdd);
			this.Controls.Add(btnApply);
			this.Controls.Add(cmbSkind);
			this.Controls.Add(EditBLength);
			this.Controls.Add(cbBigEndian);
			this.Controls.Add(tbCommant);


			btnAdd.Click += (sender, e) => { OnBAdd(new EventArgs()); };
			btnApply.Click += (sender, e) => { OnBApply(new EventArgs()); };
			btnUp.Click += (sender, e) => { OnBUp(new EventArgs()); };
			btnDown.Click += (sender, e) => { OnBDown(new EventArgs()); };
			btnDelete.Click += (sender, e) => { OnBDelete(new EventArgs()); };
			cmbSkind.SKindChanged += (sender, e) => 
			{
				long v = (long)e.SKind / 10;
				if (v <= 0) v = 1;
				if((v>=1)&&(v<=8))
				{
					EditBLength.BLength = v;
					EditBLength.Enabled = false;
				}
				else
				{
					EditBLength.Enabled = true;
				}
			};
		}

		public void ChkSize()
		{
			int h = cmbSkind.Height;
			int x = 0;
			btnUp.Location = new Point(x, 0);
			x += btnUp.Width;
			btnDown.Location = new Point(x, 0);
			x += btnDown.Width;
			btnDelete.Location = new Point(x, 0);
			x += btnDelete.Width + 4;
			btnAdd.Location = new Point(x, 0);
			x += btnAdd.Width;
			btnApply.Location = new Point(x, 0);
			x += btnApply.Width + 2;

			cmbSkind.Location = new Point(x, 0);
			x += cmbSkind.Width + 2;
			EditBLength.Location = new Point(x, 0);
			x += EditBLength.Width + 2;
			cbBigEndian.Location = new Point(x, 0);
			x += cbBigEndian.Width + 2;
			m_Width2 = x;
			tbCommant.Location = new Point(x, 0);

			int w = this.Width - m_Width2;
			if (w < 0) w = 0;
			tbCommant.Size = new Size(w, h);
		}
		protected override void OnResize(EventArgs e)
		{
			int w = this.Width - m_Width2;
			if (w < 0) w = 0;
			tbCommant.Size = new Size(w, this.Height);
		}
	}
}
