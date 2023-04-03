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
			fileToolStripMenuItem = new ToolStripMenuItem();
			toolToolStripMenuItem = new ToolStripMenuItem();
			scriptEditorToolStripMenuItem = new ToolStripMenuItem();
			consoleToolStripMenuItem = new ToolStripMenuItem();
			findToolStripMenuItem = new ToolStripMenuItem();
			jumpToolStripMenuItem = new ToolStripMenuItem();
			compareToolStripMenuItem = new ToolStripMenuItem();
			windowSetToolStripMenuItem = new ToolStripMenuItem();
			windowToolStripMenuItem = new ToolStripMenuItem();
			mainFormMaxSizeMenu = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			menuStrip1.AutoSize = false;
			menuStrip1.Dock = DockStyle.None;
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolToolStripMenuItem, compareToolStripMenuItem, windowSetToolStripMenuItem, windowToolStripMenuItem });
			menuStrip1.Location = new Point(0, 20);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1082, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// toolToolStripMenuItem
			// 
			toolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { scriptEditorToolStripMenuItem, consoleToolStripMenuItem, findToolStripMenuItem, jumpToolStripMenuItem });
			toolToolStripMenuItem.Name = "toolToolStripMenuItem";
			toolToolStripMenuItem.Size = new Size(41, 20);
			toolToolStripMenuItem.Text = "Tool";
			// 
			// scriptEditorToolStripMenuItem
			// 
			scriptEditorToolStripMenuItem.Name = "scriptEditorToolStripMenuItem";
			scriptEditorToolStripMenuItem.Size = new Size(135, 22);
			scriptEditorToolStripMenuItem.Text = "ScriptEditor";
			// 
			// consoleToolStripMenuItem
			// 
			consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
			consoleToolStripMenuItem.Size = new Size(135, 22);
			consoleToolStripMenuItem.Text = "Console";
			// 
			// findToolStripMenuItem
			// 
			findToolStripMenuItem.Name = "findToolStripMenuItem";
			findToolStripMenuItem.Size = new Size(135, 22);
			findToolStripMenuItem.Text = "Find";
			// 
			// jumpToolStripMenuItem
			// 
			jumpToolStripMenuItem.Name = "jumpToolStripMenuItem";
			jumpToolStripMenuItem.Size = new Size(135, 22);
			jumpToolStripMenuItem.Text = "Jump";
			// 
			// compareToolStripMenuItem
			// 
			compareToolStripMenuItem.Name = "compareToolStripMenuItem";
			compareToolStripMenuItem.Size = new Size(66, 20);
			compareToolStripMenuItem.Text = "Compare";
			// 
			// windowSetToolStripMenuItem
			// 
			windowSetToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mainFormMaxSizeMenu });
			windowSetToolStripMenuItem.Name = "windowSetToolStripMenuItem";
			windowSetToolStripMenuItem.Size = new Size(82, 20);
			windowSetToolStripMenuItem.Text = "WindowPos";
			// 
			// windowToolStripMenuItem
			// 
			windowToolStripMenuItem.Name = "windowToolStripMenuItem";
			windowToolStripMenuItem.Size = new Size(63, 20);
			windowToolStripMenuItem.Text = "Window";
			// 
			// mainFormMaxSizeMenu
			// 
			mainFormMaxSizeMenu.Name = "mainFormMaxSizeMenu";
			mainFormMaxSizeMenu.Size = new Size(180, 22);
			mainFormMaxSizeMenu.Text = "MainFormMaxSize";
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
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem toolToolStripMenuItem;
		private ToolStripMenuItem scriptEditorToolStripMenuItem;
		private ToolStripMenuItem consoleToolStripMenuItem;
		private ToolStripMenuItem findToolStripMenuItem;
		private ToolStripMenuItem jumpToolStripMenuItem;
		private ToolStripMenuItem compareToolStripMenuItem;
		private ToolStripMenuItem windowSetToolStripMenuItem;
		private ToolStripMenuItem windowToolStripMenuItem;
		private ToolStripMenuItem mainFormMaxSizeMenu;
	}
}