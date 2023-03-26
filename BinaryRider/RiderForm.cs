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
		// ***************************************************************
		public class WinCloseEventArgs : EventArgs
		{
			public int Id;
			public WinCloseEventArgs(int id)
			{
				Id = id;
			}
		}

		private int m_id = -1;
		public int Id
		{
			get { return m_id; }
			set
			{
				if (m_id < 0)
				{
					m_id = value;
				}
			}
		}
		public delegate void WinCloseEventHandler(object sender, WinCloseEventArgs e);

		//イベントデリゲートの宣言
		public event WinCloseEventHandler? WinClose = null;

		protected virtual void OnWinClose(WinCloseEventArgs e)
		{
			if (WinClose != null)
			{
				WinClose(this, e);
			}
		}
		// ***************************************************************
		public MainForm? MainForm = null;

		public BDataFile BDataFile = new BDataFile();
		// ***************************************************************
		public bool IsActive
		{
			get { return (Form.ActiveForm == this); }
		}
		// ***************************************************************
		// ***************************************************************
		public RiderForm()
		{
			AllowDrop = true;
			InitializeComponent();

			editBinaryTwo1.DataFile = BDataFile;

			newFormMenu.Click += NewToolStripMenuItem_Click;
			openFileMenu.Click += OpenToolStripMenuItem_Click;
			windowMenu.Click += (sender, e) => { MakeWindowMenu(); };
			separetDispMenu.Checked = editBinaryTwo1.IsTwoWin;
			separetDispMenu.Click += (sender, e) =>
			{
				editBinaryTwo1.IsTwoWin = !editBinaryTwo1.IsTwoWin;
				separetDispMenu.Checked = editBinaryTwo1.IsTwoWin;
			};
			orientMenu.Checked = editBinaryTwo1.IsVurWin;
			orientMenu.Click += (sender, e) =>
			{
				editBinaryTwo1.IsVurWin = !editBinaryTwo1.IsVurWin;
				orientMenu.Checked = editBinaryTwo1.IsVurWin;
			};
			shiftJISMenu.Click += (sender, e) => { CharCodeMode = CharCodeMode.ShiftJIS; };
			uTF8Menu.Click += (sender, e) => { CharCodeMode = CharCodeMode.UTF8; };

			consoleMenu.Click += (sender, e) => { if (MainForm != null) MainForm.ShowConsoleForm(); };
			scriptEditorMenu.Click += (sender, e) => { if (MainForm != null) MainForm.ShowScriptEditor(); };

			//jumpTopMenu.ShortcutKeys = Keys.Home;
			//jumpEndMenu.ShortcutKeys = Keys.End;
			jumpTopMenu.Click += (sender, e) => { JumpTop(); };
			jumpEndMenu.Click += (sender, e) => { JumpEnd(); };
			addressMenu.Click += (sender, e) => { Jump(); };


		}
		public byte[] Data
		{
			get
			{
				return BDataFile.Data;
			}
		}

		// ***************************************************************
		public CharCodeMode CharCodeMode
		{
			get
			{
				return editBinaryTwo1.CharCodeMode;
			}
			set
			{
				editBinaryTwo1.CharCodeMode = value;
				switch (editBinaryTwo1.CharCodeMode)
				{
					case CharCodeMode.UTF8:
						shiftJISMenu.Checked = false;
						uTF8Menu.Checked = true;
						break;
					case CharCodeMode.ShiftJIS:
						shiftJISMenu.Checked = true;
						uTF8Menu.Checked = false;
						break;
				}
				if (MainForm != null) MainForm.CharCodeMode = value;
			}
		}
		// ***************************************************************
		private void OpenToolStripMenuItem_Click(object? sender, EventArgs e)
		{
			OpenFile();
		}

		// ***************************************************************
		private void NewToolStripMenuItem_Click(object? sender, EventArgs e)
		{
			if (MainForm != null)
			{
				MainForm.AddForm();
			}
		}
		// ***************************************************************
		protected override void OnResize(EventArgs e)
		{
			int mh = 25;
			int w = this.ClientSize.Width;
			int h = this.ClientSize.Height - mh;
			editBinaryTwo1.Location = new Point(0, mh);
			editBinaryTwo1.Size = new Size(w, h);
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

					if (OpenFile(fileName) == true)
					{
						break;
					}

				}

			}
		}
		// ***************************************************************
		public bool OpenFile(string p)
		{
			bool ret = false;
			ret = BDataFile.LoadFile(p);
			if (ret == true)
			{
				this.Text = p;
			}
			else
			{
				this.Text = "Binary Rider";
			}
			return ret;
		}
		public bool OpenFile()
		{
			bool ret = false;
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				string p = BDataFile.FileName;
				if (p != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(p);
					dlg.FileName = Path.GetFileName(p);
				}
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = OpenFile(dlg.FileName);
				}
			}

			return ret;
		}
		// ***************************************************************
		protected override void OnClosed(EventArgs e)
		{
			OnWinClose(new WinCloseEventArgs(m_id));
			base.OnClosed(e);
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void editBinaryTwo1_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}
		public BSelection Selection
		{
			get
			{
				return editBinaryTwo1.Selection;
			}
		}
		// ***************************************************************
		public void MakeWindowMenu()
		{
			if (windowMenu.DropDownItems.Count > 0)
			{
				windowMenu.DropDownItems.Clear();
			}
			if (MainForm == null) return;
			if (MainForm.Forms.Count <= 0) return;
			List<ToolStripMenuItem> ms = new List<ToolStripMenuItem>();
			foreach (RiderForm rf in MainForm.Forms)
			{
				ToolStripMenuItem m = new ToolStripMenuItem();
				m.Text = rf.Text;
				m.Checked = rf.IsActive;
				m.Tag = (Object)rf;
				m.Click += (sender, e) =>
				{
					ToolStripMenuItem? m = (ToolStripMenuItem?)sender;
					if (m != null)
					{
						RiderForm? rr = (RiderForm?)m.Tag;
						if (rr != null) rr.Activate();
					}
					windowMenu.DropDownItems.Clear();
				};
				ms.Add(m);
			}
			windowMenu.DropDownItems.AddRange(ms.ToArray());
		}
		// ***************************************************************
		public bool Jump(int adr, int Len = 1)
		{
			return editBinaryTwo1.Jump(adr, Len);
		}
		public bool Jump()
		{
			bool ret = false;
			using (JumpDialog dlg = new JumpDialog())
			{
				dlg.RiderForm = this;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = Jump(dlg.Adress);
				}
			}
			return ret;
		}
		public bool JumpTop()
		{
			return editBinaryTwo1.JumpTop();
		}
		public bool JumpEnd()
		{
			return editBinaryTwo1.JumpEnd();
		}
		// ***************************************************************
	}


}
