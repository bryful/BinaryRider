﻿namespace BinaryRider
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
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			newFormMenu = new ToolStripMenuItem();
			loadFileMenu = new ToolStripMenuItem();
			saveFileMenu = new ToolStripMenuItem();
			closeFormMenu = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			copyToolStripMenuItem = new ToolStripMenuItem();
			pasteToolStripMenuItem = new ToolStripMenuItem();
			optionMenu = new ToolStripMenuItem();
			separetDispMenu = new ToolStripMenuItem();
			orientMenu = new ToolStripMenuItem();
			CharCodeMenu = new ToolStripMenuItem();
			shiftJISMenu = new ToolStripMenuItem();
			uTF8Menu = new ToolStripMenuItem();
			topMostMenu = new ToolStripMenuItem();
			jumpMenu = new ToolStripMenuItem();
			findMenu = new ToolStripMenuItem();
			relativeJumpMenu = new ToolStripMenuItem();
			jumpTopMenu = new ToolStripMenuItem();
			jumpEndMenu = new ToolStripMenuItem();
			scriptMenu = new ToolStripMenuItem();
			scriptEditorMenu = new ToolStripMenuItem();
			consoleMenu = new ToolStripMenuItem();
			windowMenu = new ToolStripMenuItem();
			helpToolStripMenuItem = new ToolStripMenuItem();
			editBinaryTwo1 = new EditBinaryTwo();
			structViewMenu = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)editBinaryTwo1).BeginInit();
			editBinaryTwo1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, optionMenu, jumpMenu, scriptMenu, windowMenu, helpToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(645, 24);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newFormMenu, loadFileMenu, saveFileMenu, closeFormMenu });
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
			// loadFileMenu
			// 
			loadFileMenu.Name = "loadFileMenu";
			loadFileMenu.Size = new Size(129, 22);
			loadFileMenu.Text = "LoadFile";
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
			// optionMenu
			// 
			optionMenu.DropDownItems.AddRange(new ToolStripItem[] { separetDispMenu, orientMenu, CharCodeMenu, topMostMenu });
			optionMenu.Name = "optionMenu";
			optionMenu.Size = new Size(56, 20);
			optionMenu.Text = "Option";
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
			// topMostMenu
			// 
			topMostMenu.Name = "topMostMenu";
			topMostMenu.Size = new Size(154, 22);
			topMostMenu.Text = "TopMost";
			// 
			// jumpMenu
			// 
			jumpMenu.DropDownItems.AddRange(new ToolStripItem[] { findMenu, relativeJumpMenu, jumpTopMenu, jumpEndMenu, structViewMenu });
			jumpMenu.Name = "jumpMenu";
			jumpMenu.Size = new Size(47, 20);
			jumpMenu.Text = "Jump";
			// 
			// findMenu
			// 
			findMenu.Name = "findMenu";
			findMenu.Size = new Size(180, 22);
			findMenu.Text = "Find";
			// 
			// relativeJumpMenu
			// 
			relativeJumpMenu.Name = "relativeJumpMenu";
			relativeJumpMenu.ShortcutKeys = Keys.Control | Keys.J;
			relativeJumpMenu.Size = new Size(180, 22);
			relativeJumpMenu.Text = "Jump";
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
			// structViewMenu
			// 
			structViewMenu.Name = "structViewMenu";
			structViewMenu.Size = new Size(180, 22);
			structViewMenu.Text = "StructView";
			// 
			// RiderForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(645, 399);
			Controls.Add(menuStrip1);
			Controls.Add(editBinaryTwo1);
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
		private ToolStripMenuItem loadFileMenu;
		private ToolStripMenuItem closeFormMenu;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem windowMenu;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem saveFileMenu;
		private ToolStripMenuItem optionMenu;
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
		private ToolStripMenuItem relativeJumpMenu;
		private ToolStripMenuItem topMostMenu;
		private EditBinaryTwo editBinaryTwo1;
		private ToolStripMenuItem findMenu;
		private ToolStripMenuItem structViewMenu;
	}
}