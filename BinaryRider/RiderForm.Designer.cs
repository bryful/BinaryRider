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
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			editBinary1 = new EditBinary();
			bDataFile1 = new BDataFile(components);
			toolStrip1 = new ToolStrip();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1131, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// editBinary1
			// 
			editBinary1.DataFile = bDataFile1;
			editBinary1.Font = new Font("源ノ角ゴシック Code JP R", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
			editBinary1.Location = new Point(0, 50);
			editBinary1.Name = "editBinary1";
			editBinary1.Size = new Size(922, 452);
			editBinary1.TabIndex = 1;
			editBinary1.Text = "editBinary1";
			// 
			// toolStrip1
			// 
			toolStrip1.Location = new Point(0, 24);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(1131, 25);
			toolStrip1.TabIndex = 3;
			toolStrip1.Text = "toolStrip1";
			// 
			// RiderForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1131, 507);
			Controls.Add(toolStrip1);
			Controls.Add(editBinary1);
			Controls.Add(menuStrip1);
			DoubleBuffered = true;
			MainMenuStrip = menuStrip1;
			Name = "RiderForm";
			Text = "RiderForm";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem editToolStripMenuItem;
		private EditBinary editBinary1;
		private ToolStrip toolStrip1;
		private BDataFile bDataFile1;
	}
}