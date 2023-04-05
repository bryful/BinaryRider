namespace BinaryRider
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menuStrip1 = new MenuStrip();
			fileMenu = new ToolStripMenuItem();
			newMenu = new ToolStripMenuItem();
			openMenu = new ToolStripMenuItem();
			quitMenu = new ToolStripMenuItem();
			toolMenu = new ToolStripMenuItem();
			scriptEditorMenu = new ToolStripMenuItem();
			consoleMenu = new ToolStripMenuItem();
			findMenu = new ToolStripMenuItem();
			jumpMenu = new ToolStripMenuItem();
			structViewMenu = new ToolStripMenuItem();
			compareMenu = new ToolStripMenuItem();
			windowPosMenu = new ToolStripMenuItem();
			mainFormMaxSizeMenu = new ToolStripMenuItem();
			windowMenu = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			menuStrip1.AutoSize = false;
			menuStrip1.Dock = DockStyle.None;
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu, toolMenu, compareMenu, windowPosMenu, windowMenu });
			menuStrip1.Location = new Point(0, 20);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1082, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileMenu
			// 
			fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newMenu, openMenu, quitMenu });
			fileMenu.Name = "fileMenu";
			fileMenu.Size = new Size(37, 20);
			fileMenu.Text = "File";
			// 
			// newMenu
			// 
			newMenu.Name = "newMenu";
			newMenu.Size = new Size(180, 22);
			newMenu.Text = "New";
			// 
			// openMenu
			// 
			openMenu.Name = "openMenu";
			openMenu.Size = new Size(180, 22);
			openMenu.Text = "Open";
			// 
			// quitMenu
			// 
			quitMenu.Name = "quitMenu";
			quitMenu.Size = new Size(180, 22);
			quitMenu.Text = "Quit";
			// 
			// toolMenu
			// 
			toolMenu.DropDownItems.AddRange(new ToolStripItem[] { structViewMenu, findMenu, jumpMenu, scriptEditorMenu, consoleMenu });
			toolMenu.Name = "toolMenu";
			toolMenu.Size = new Size(41, 20);
			toolMenu.Text = "Tool";
			// 
			// scriptEditorpMenu
			// 
			scriptEditorMenu.Name = "scriptEditorpMenu";
			scriptEditorMenu.Size = new Size(180, 22);
			scriptEditorMenu.Text = "ScriptEditor";
			// 
			// consoleMenu
			// 
			consoleMenu.Name = "consoleMenu";
			consoleMenu.Size = new Size(180, 22);
			consoleMenu.Text = "Console";
			// 
			// findMenu
			// 
			findMenu.Name = "findMenu";
			findMenu.Size = new Size(180, 22);
			findMenu.Text = "Find";
			// 
			// jumpMenu
			// 
			jumpMenu.Name = "jumpMenu";
			jumpMenu.Size = new Size(180, 22);
			jumpMenu.Text = "Jump";
			// 
			// structViewMenu
			// 
			structViewMenu.Name = "structViewMenu";
			structViewMenu.Size = new Size(180, 22);
			structViewMenu.Text = "StructView";
			// 
			// compareMenu
			// 
			compareMenu.Enabled = false;
			compareMenu.Name = "compareMenu";
			compareMenu.Size = new Size(66, 20);
			compareMenu.Text = "Compare";
			// 
			// windowPosMenu
			// 
			windowPosMenu.DropDownItems.AddRange(new ToolStripItem[] { mainFormMaxSizeMenu });
			windowPosMenu.Name = "windowPosMenu";
			windowPosMenu.Size = new Size(82, 20);
			windowPosMenu.Text = "WindowPos";
			// 
			// mainFormMaxSizeMenu
			// 
			mainFormMaxSizeMenu.Name = "mainFormMaxSizeMenu";
			mainFormMaxSizeMenu.Size = new Size(171, 22);
			mainFormMaxSizeMenu.Text = "MainFormMaxSize";
			// 
			// windowMenu
			// 
			windowMenu.Name = "windowMenu";
			windowMenu.Size = new Size(63, 20);
			windowMenu.Text = "Window";
			// 
			// MainForm
			// 
			AutoScaleMode = AutoScaleMode.None;
			BackColor = SystemColors.ControlDark;
			CanResize = true;
			ClientSize = new Size(1102, 50);
			ControlBox = false;
			Controls.Add(menuStrip1);
			DoubleBuffered = true;
			KeyPreview = true;
			MainMenuStrip = menuStrip1;
			MaximizeBox = false;
			MaximumSize = new Size(6000, 50);
			MdiChildrenMinimizedAnchorBottom = false;
			MinimizeBox = false;
			MinimumSize = new Size(200, 50);
			Name = "MainForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.Manual;
			Text = "BinaryRider Main";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileMenu;
		private ToolStripMenuItem toolMenu;
		private ToolStripMenuItem scriptEditorMenu;
		private ToolStripMenuItem consoleMenu;
		private ToolStripMenuItem findMenu;
		private ToolStripMenuItem jumpMenu;
		private ToolStripMenuItem compareMenu;
		private ToolStripMenuItem windowPosMenu;
		private ToolStripMenuItem windowMenu;
		private ToolStripMenuItem mainFormMaxSizeMenu;
		private ToolStripMenuItem newMenu;
		private ToolStripMenuItem openMenu;
		private ToolStripMenuItem quitMenu;
		private ToolStripMenuItem structViewMenu;
	}
}