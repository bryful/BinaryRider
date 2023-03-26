namespace BinaryRider
{
	partial class RiderForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			BSelection bSelection1 = new BSelection();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			newFormMenu = new ToolStripMenuItem();
			openFileMenu = new ToolStripMenuItem();
			saveFileMenu = new ToolStripMenuItem();
			closeFormMenu = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			copyToolStripMenuItem = new ToolStripMenuItem();
			pasteToolStripMenuItem = new ToolStripMenuItem();
			optionToolStripMenuItem = new ToolStripMenuItem();
			separetDispMenu = new ToolStripMenuItem();
			orientMenu = new ToolStripMenuItem();
			CharCodeMenu = new ToolStripMenuItem();
			shiftJISMenu = new ToolStripMenuItem();
			uTF8Menu = new ToolStripMenuItem();
			jumpMenu = new ToolStripMenuItem();
			addressMenu = new ToolStripMenuItem();
			jumpTopMenu = new ToolStripMenuItem();
			jumpEndMenu = new ToolStripMenuItem();
			scriptMenu = new ToolStripMenuItem();
			scriptEditorMenu = new ToolStripMenuItem();
			consoleMenu = new ToolStripMenuItem();
			windowMenu = new ToolStripMenuItem();
			helpToolStripMenuItem = new ToolStripMenuItem();
			editBinaryTwo1 = new EditBinaryTwo();
			menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)editBinaryTwo1).BeginInit();
			editBinaryTwo1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, optionToolStripMenuItem, jumpMenu, scriptMenu, windowMenu, helpToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(576, 24);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newFormMenu, openFileMenu, saveFileMenu, closeFormMenu });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// newFormMenu
			// 
			newFormMenu.Name = "newFormMenu";
			newFormMenu.Size = new Size(129, 22);
			newFormMenu.Text = "NewForm";
			// 
			// openFileMenu
			// 
			openFileMenu.Name = "openFileMenu";
			openFileMenu.Size = new Size(129, 22);
			openFileMenu.Text = "OpenFile";
			// 
			// saveFileMenu
			// 
			saveFileMenu.Enabled = false;
			saveFileMenu.Name = "saveFileMenu";
			saveFileMenu.Size = new Size(129, 22);
			saveFileMenu.Text = "SaveFile";
			// 
			// closeFormMenu
			// 
			closeFormMenu.Name = "closeFormMenu";
			closeFormMenu.Size = new Size(129, 22);
			closeFormMenu.Text = "CloseForm";
			closeFormMenu.Click += quitToolStripMenuItem_Click;
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem, pasteToolStripMenuItem });
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// copyToolStripMenuItem
			// 
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new Size(102, 22);
			copyToolStripMenuItem.Text = "Copy";
			// 
			// pasteToolStripMenuItem
			// 
			pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			pasteToolStripMenuItem.Size = new Size(102, 22);
			pasteToolStripMenuItem.Text = "Paste";
			// 
			// optionToolStripMenuItem
			// 
			optionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { separetDispMenu, orientMenu, CharCodeMenu });
			optionToolStripMenuItem.Name = "optionToolStripMenuItem";
			optionToolStripMenuItem.Size = new Size(56, 20);
			optionToolStripMenuItem.Text = "Option";
			// 
			// separetDispMenu
			// 
			separetDispMenu.Name = "separetDispMenu";
			separetDispMenu.Size = new Size(154, 22);
			separetDispMenu.Text = "SeparetDisp";
			// 
			// orientMenu
			// 
			orientMenu.Name = "orientMenu";
			orientMenu.Size = new Size(154, 22);
			orientMenu.Text = "Orient";
			// 
			// CharCodeMenu
			// 
			CharCodeMenu.DropDownItems.AddRange(new ToolStripItem[] { shiftJISMenu, uTF8Menu });
			CharCodeMenu.Name = "CharCodeMenu";
			CharCodeMenu.Size = new Size(154, 22);
			CharCodeMenu.Text = "Character Code";
			// 
			// shiftJISMenu
			// 
			shiftJISMenu.Name = "shiftJISMenu";
			shiftJISMenu.Size = new Size(111, 22);
			shiftJISMenu.Text = "ShiftJIS";
			// 
			// uTF8Menu
			// 
			uTF8Menu.Name = "uTF8Menu";
			uTF8Menu.Size = new Size(111, 22);
			uTF8Menu.Text = "UTF8";
			// 
			// jumpMenu
			// 
			jumpMenu.DropDownItems.AddRange(new ToolStripItem[] { addressMenu, jumpTopMenu, jumpEndMenu });
			jumpMenu.Name = "jumpMenu";
			jumpMenu.Size = new Size(47, 20);
			jumpMenu.Text = "Jump";
			// 
			// addressMenu
			// 
			addressMenu.Name = "addressMenu";
			addressMenu.ShortcutKeys = Keys.Control | Keys.J;
			addressMenu.Size = new Size(180, 22);
			addressMenu.Text = "Address";
			// 
			// jumpTopMenu
			// 
			jumpTopMenu.Name = "jumpTopMenu";
			jumpTopMenu.Size = new Size(180, 22);
			jumpTopMenu.Text = "Top";
			// 
			// jumpEndMenu
			// 
			jumpEndMenu.Name = "jumpEndMenu";
			jumpEndMenu.Size = new Size(180, 22);
			jumpEndMenu.Text = "End";
			// 
			// scriptMenu
			// 
			scriptMenu.DropDownItems.AddRange(new ToolStripItem[] { scriptEditorMenu, consoleMenu });
			scriptMenu.Name = "scriptMenu";
			scriptMenu.Size = new Size(49, 20);
			scriptMenu.Text = "Script";
			// 
			// scriptEditorMenu
			// 
			scriptEditorMenu.Name = "scriptEditorMenu";
			scriptEditorMenu.Size = new Size(135, 22);
			scriptEditorMenu.Text = "ScriptEditor";
			// 
			// consoleMenu
			// 
			consoleMenu.Name = "consoleMenu";
			consoleMenu.Size = new Size(135, 22);
			consoleMenu.Text = "Console";
			// 
			// windowMenu
			// 
			windowMenu.Name = "windowMenu";
			windowMenu.Size = new Size(63, 20);
			windowMenu.Text = "Window";
			// 
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new Size(44, 20);
			helpToolStripMenuItem.Text = "Help";
			// 
			// editBinaryTwo1
			// 
			editBinaryTwo1.CharCodeMode = CharCodeMode.UTF8;
			editBinaryTwo1.IsTwoWin = false;
			editBinaryTwo1.IsVurWin = false;
			editBinaryTwo1.Location = new Point(12, 30);
			editBinaryTwo1.Name = "editBinaryTwo1";
			editBinaryTwo1.Orientation = Orientation.Horizontal;
			// 
			// editBinaryTwo1.Panel2
			// 
			editBinaryTwo1.Panel2.Paint += editBinaryTwo1_Panel2_Paint;
			editBinaryTwo1.Panel2Collapsed = true;
			bSelection1.Length = 0;
			bSelection1.Start = 0;
			editBinaryTwo1.Selection = bSelection1;
			editBinaryTwo1.Size = new Size(543, 360);
			editBinaryTwo1.SplitterDistance = 289;
			editBinaryTwo1.SplitterIncrement = 2;
			editBinaryTwo1.SplitterWidth = 8;
			editBinaryTwo1.TabIndex = 2;
			// 
			// RiderForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(576, 405);
			Controls.Add(editBinaryTwo1);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "RiderForm";
			Text = "RiderForm";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)editBinaryTwo1).EndInit();
			editBinaryTwo1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem newFormMenu;
		private ToolStripMenuItem openFileMenu;
		private ToolStripMenuItem closeFormMenu;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem windowMenu;
		private ToolStripMenuItem helpToolStripMenuItem;
		private EditBinaryTwo editBinaryTwo1;
		private ToolStripMenuItem saveFileMenu;
		private ToolStripMenuItem optionToolStripMenuItem;
		private ToolStripMenuItem separetDispMenu;
		private ToolStripMenuItem orientMenu;
		private ToolStripMenuItem copyToolStripMenuItem;
		private ToolStripMenuItem pasteToolStripMenuItem;
		private ToolStripMenuItem CharCodeMenu;
		private ToolStripMenuItem shiftJISMenu;
		private ToolStripMenuItem uTF8Menu;
		private ToolStripMenuItem scriptMenu;
		private ToolStripMenuItem scriptEditorMenu;
		private ToolStripMenuItem consoleMenu;
		private ToolStripMenuItem jumpMenu;
		private ToolStripMenuItem jumpTopMenu;
		private ToolStripMenuItem jumpEndMenu;
		private ToolStripMenuItem addressMenu;
	}
}