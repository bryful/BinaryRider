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
			BSelection bSelection1 = new BSelection();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RiderForm));
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			loadFileMenu = new ToolStripMenuItem();
			saveFileMenu = new ToolStripMenuItem();
			closeFormMenu = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			copyMenu = new ToolStripMenuItem();
			pasteToolStripMenuItem = new ToolStripMenuItem();
			optionMenu = new ToolStripMenuItem();
			topMostMenu = new ToolStripMenuItem();
			maxSizeMenu = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripSeparator();
			separetDispMenu = new ToolStripMenuItem();
			orientMenu = new ToolStripMenuItem();
			toolStripMenuItem2 = new ToolStripSeparator();
			CharCodeMenu = new ToolStripMenuItem();
			shiftJISMenu = new ToolStripMenuItem();
			uTF8Menu = new ToolStripMenuItem();
			jumpMenu = new ToolStripMenuItem();
			findMenu = new ToolStripMenuItem();
			relativeJumpMenu = new ToolStripMenuItem();
			jumpTopMenu = new ToolStripMenuItem();
			jumpEndMenu = new ToolStripMenuItem();
			toolMenu = new ToolStripMenuItem();
			mainMenu = new ToolStripMenuItem();
			toolStripMenuItem3 = new ToolStripSeparator();
			structViewMenu = new ToolStripMenuItem();
			toolStripMenuItem4 = new ToolStripSeparator();
			scriptEditorMenu = new ToolStripMenuItem();
			consoleMenu = new ToolStripMenuItem();
			helpToolStripMenuItem = new ToolStripMenuItem();
			editBinaryTwo1 = new EditBinaryTwo();
			menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)editBinaryTwo1).BeginInit();
			editBinaryTwo1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, optionMenu, jumpMenu, toolMenu, helpToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(645, 24);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadFileMenu, saveFileMenu, closeFormMenu });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// loadFileMenu
			// 
			loadFileMenu.Name = "loadFileMenu";
			loadFileMenu.Size = new Size(180, 22);
			loadFileMenu.Text = "LoadFile";
			// 
			// saveFileMenu
			// 
			saveFileMenu.Enabled = false;
			saveFileMenu.Name = "saveFileMenu";
			saveFileMenu.Size = new Size(180, 22);
			saveFileMenu.Text = "SaveFile";
			// 
			// closeFormMenu
			// 
			closeFormMenu.Name = "closeFormMenu";
			closeFormMenu.Size = new Size(180, 22);
			closeFormMenu.Text = "CloseForm";
			closeFormMenu.Click += quitToolStripMenuItem_Click;
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyMenu, pasteToolStripMenuItem });
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// copyMenu
			// 
			copyMenu.Name = "copyMenu";
			copyMenu.Size = new Size(102, 22);
			copyMenu.Text = "Copy";
			// 
			// pasteToolStripMenuItem
			// 
			pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			pasteToolStripMenuItem.Size = new Size(102, 22);
			pasteToolStripMenuItem.Text = "Paste";
			// 
			// optionMenu
			// 
			optionMenu.DropDownItems.AddRange(new ToolStripItem[] { topMostMenu, maxSizeMenu, toolStripMenuItem1, separetDispMenu, orientMenu, toolStripMenuItem2, CharCodeMenu });
			optionMenu.Name = "optionMenu";
			optionMenu.Size = new Size(44, 20);
			optionMenu.Text = "View";
			// 
			// topMostMenu
			// 
			topMostMenu.Name = "topMostMenu";
			topMostMenu.Size = new Size(154, 22);
			topMostMenu.Text = "TopMost";
			// 
			// maxSizeMenu
			// 
			maxSizeMenu.Name = "maxSizeMenu";
			maxSizeMenu.Size = new Size(154, 22);
			maxSizeMenu.Text = "MaxSize";
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(151, 6);
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
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new Size(151, 6);
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
			jumpMenu.DropDownItems.AddRange(new ToolStripItem[] { findMenu, relativeJumpMenu, jumpTopMenu, jumpEndMenu });
			jumpMenu.Name = "jumpMenu";
			jumpMenu.Size = new Size(47, 20);
			jumpMenu.Text = "Jump";
			// 
			// findMenu
			// 
			findMenu.Name = "findMenu";
			findMenu.Size = new Size(139, 22);
			findMenu.Text = "Find";
			// 
			// relativeJumpMenu
			// 
			relativeJumpMenu.Name = "relativeJumpMenu";
			relativeJumpMenu.ShortcutKeys = Keys.Control | Keys.J;
			relativeJumpMenu.Size = new Size(139, 22);
			relativeJumpMenu.Text = "Jump";
			// 
			// jumpTopMenu
			// 
			jumpTopMenu.Name = "jumpTopMenu";
			jumpTopMenu.Size = new Size(139, 22);
			jumpTopMenu.Text = "Top";
			// 
			// jumpEndMenu
			// 
			jumpEndMenu.Name = "jumpEndMenu";
			jumpEndMenu.Size = new Size(139, 22);
			jumpEndMenu.Text = "End";
			// 
			// toolMenu
			// 
			toolMenu.DropDownItems.AddRange(new ToolStripItem[] { mainMenu, toolStripMenuItem3, structViewMenu, toolStripMenuItem4, scriptEditorMenu, consoleMenu });
			toolMenu.Name = "toolMenu";
			toolMenu.Size = new Size(41, 20);
			toolMenu.Text = "Tool";
			// 
			// mainMenu
			// 
			mainMenu.Name = "mainMenu";
			mainMenu.Size = new Size(135, 22);
			mainMenu.Text = "Main";
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new Size(132, 6);
			// 
			// structViewMenu
			// 
			structViewMenu.Name = "structViewMenu";
			structViewMenu.Size = new Size(135, 22);
			structViewMenu.Text = "StructView";
			// 
			// toolStripMenuItem4
			// 
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new Size(132, 6);
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
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new Size(44, 20);
			helpToolStripMenuItem.Text = "Help";
			// 
			// editBinaryTwo1
			// 
			editBinaryTwo1.CharCodeMode = CharCodeMode.UTF8;
			editBinaryTwo1.DataFile = null;
			editBinaryTwo1.IsTwoWin = false;
			editBinaryTwo1.IsVurWin = false;
			editBinaryTwo1.Location = new Point(0, 27);
			editBinaryTwo1.Name = "editBinaryTwo1";
			editBinaryTwo1.Orientation = Orientation.Horizontal;
			editBinaryTwo1.Panel2Collapsed = true;
			bSelection1.Length = 0L;
			bSelection1.Start = 0L;
			editBinaryTwo1.Selection = bSelection1;
			editBinaryTwo1.Size = new Size(640, 360);
			editBinaryTwo1.SplitterDistance = 289;
			editBinaryTwo1.SplitterIncrement = 2;
			editBinaryTwo1.SplitterWidth = 8;
			editBinaryTwo1.TabIndex = 2;
			// 
			// RiderForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(645, 399);
			Controls.Add(menuStrip1);
			Controls.Add(editBinaryTwo1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			MaximizeBox = false;
			MinimizeBox = false;
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
		private ToolStripMenuItem loadFileMenu;
		private ToolStripMenuItem closeFormMenu;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem saveFileMenu;
		private ToolStripMenuItem optionMenu;
		private ToolStripMenuItem separetDispMenu;
		private ToolStripMenuItem orientMenu;
		private ToolStripMenuItem copyMenu;
		private ToolStripMenuItem pasteToolStripMenuItem;
		private ToolStripMenuItem CharCodeMenu;
		private ToolStripMenuItem shiftJISMenu;
		private ToolStripMenuItem uTF8Menu;
		private ToolStripMenuItem toolMenu;
		private ToolStripMenuItem scriptEditorMenu;
		private ToolStripMenuItem consoleMenu;
		private ToolStripMenuItem jumpMenu;
		private ToolStripMenuItem jumpTopMenu;
		private ToolStripMenuItem jumpEndMenu;
		private ToolStripMenuItem relativeJumpMenu;
		private ToolStripMenuItem topMostMenu;
		private EditBinaryTwo editBinaryTwo1;
		private ToolStripMenuItem findMenu;
		private ToolStripSeparator toolStripMenuItem1;
		private ToolStripSeparator toolStripMenuItem2;
		private ToolStripMenuItem mainMenu;
		private ToolStripSeparator toolStripMenuItem3;
		private ToolStripMenuItem structViewMenu;
		private ToolStripSeparator toolStripMenuItem4;
		private ToolStripMenuItem maxSizeMenu;
	}
}