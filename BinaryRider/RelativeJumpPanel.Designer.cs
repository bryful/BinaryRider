namespace BinaryRider
{
	partial class RelativeJumpPanel
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
			hexEdit1 = new HexEdit();
			btnSubJump = new Button();
			btnAddJump = new Button();
			contextMenuStrip1 = new ContextMenuStrip(components);
			aToolStripMenuItem = new ToolStripMenuItem();
			btnHis = new Button();
			listBox1 = new ListBox();
			button2 = new Button();
			button3 = new Button();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// hexEdit1
			// 
			hexEdit1.Alignment = StringAlignment.Center;
			hexEdit1.BackColor = SystemColors.Window;
			hexEdit1.BackColorMid = SystemColors.Control;
			hexEdit1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			hexEdit1.ForeColor = SystemColors.ControlText;
			hexEdit1.Location = new Point(12, 23);
			hexEdit1.Name = "hexEdit1";
			hexEdit1.Size = new Size(96, 32);
			hexEdit1.TabIndex = 0;
			hexEdit1.Text = "hexEdit1";
			hexEdit1.UsedByte = 4;
			hexEdit1.Value = 0L;
			// 
			// btnSubJump
			// 
			btnSubJump.FlatStyle = FlatStyle.Flat;
			btnSubJump.Location = new Point(140, 23);
			btnSubJump.Name = "btnSubJump";
			btnSubJump.Size = new Size(32, 32);
			btnSubJump.TabIndex = 2;
			btnSubJump.Text = "- ";
			btnSubJump.UseVisualStyleBackColor = true;
			// 
			// btnAddJump
			// 
			btnAddJump.FlatStyle = FlatStyle.Flat;
			btnAddJump.Location = new Point(178, 23);
			btnAddJump.Name = "btnAddJump";
			btnAddJump.Size = new Size(32, 32);
			btnAddJump.TabIndex = 3;
			btnAddJump.Text = "+";
			btnAddJump.UseVisualStyleBackColor = true;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { aToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(81, 26);
			// 
			// aToolStripMenuItem
			// 
			aToolStripMenuItem.Name = "aToolStripMenuItem";
			aToolStripMenuItem.Size = new Size(80, 22);
			aToolStripMenuItem.Text = "a";
			// 
			// btnHis
			// 
			btnHis.FlatStyle = FlatStyle.Flat;
			btnHis.Location = new Point(110, 28);
			btnHis.Name = "btnHis";
			btnHis.Size = new Size(24, 22);
			btnHis.TabIndex = 1;
			btnHis.TabStop = false;
			btnHis.Text = ">";
			btnHis.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			listBox1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 21;
			listBox1.Location = new Point(70, 70);
			listBox1.Name = "listBox1";
			listBox1.ScrollAlwaysVisible = true;
			listBox1.Size = new Size(140, 130);
			listBox1.Sorted = true;
			listBox1.TabIndex = 6;
			// 
			// button2
			// 
			button2.FlatStyle = FlatStyle.Flat;
			button2.Location = new Point(12, 70);
			button2.Name = "button2";
			button2.Size = new Size(52, 23);
			button2.TabIndex = 4;
			button2.Text = "Push";
			button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			button3.FlatStyle = FlatStyle.Flat;
			button3.Location = new Point(12, 175);
			button3.Name = "button3";
			button3.Size = new Size(52, 23);
			button3.TabIndex = 5;
			button3.Text = "Delete";
			button3.UseVisualStyleBackColor = true;
			// 
			// RelativeJumpPanel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(223, 210);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(listBox1);
			Controls.Add(btnHis);
			Controls.Add(btnAddJump);
			Controls.Add(btnSubJump);
			Controls.Add(hexEdit1);
			Name = "RelativeJumpPanel";
			Text = "RelativeJumpPanel";
			TopMost = true;
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private HexEdit hexEdit1;
		private Button btnSubJump;
		private Button btnAddJump;
		private ContextMenuStrip contextMenuStrip1;
		private Button btnHis;
		private ListBox listBox1;
		private Button button2;
		private Button button3;
		private ToolStripMenuItem aToolStripMenuItem;
	}
}