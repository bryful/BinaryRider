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
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			editBinary1 = new EditBinary();
			vScrollBar1 = new VScrollBar();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(726, 24);
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
			editBinary1.Font = new Font("源ノ角ゴシック Code JP R", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
			editBinary1.Location = new Point(0, 27);
			editBinary1.Name = "editBinary1";
			editBinary1.Size = new Size(671, 477);
			editBinary1.TabIndex = 1;
			editBinary1.Text = "editBinary1";
			// 
			// vScrollBar1
			// 
			vScrollBar1.Location = new Point(693, 27);
			vScrollBar1.Name = "vScrollBar1";
			vScrollBar1.Size = new Size(17, 477);
			vScrollBar1.TabIndex = 2;
			// 
			// RiderForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(726, 502);
			Controls.Add(vScrollBar1);
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
		private VScrollBar vScrollBar1;
	}
}