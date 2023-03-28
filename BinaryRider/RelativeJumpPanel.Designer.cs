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
			button1 = new Button();
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
			btnSubJump.Location = new Point(140, 23);
			btnSubJump.Name = "btnSubJump";
			btnSubJump.Size = new Size(32, 32);
			btnSubJump.TabIndex = 1;
			btnSubJump.Text = "- ";
			btnSubJump.UseVisualStyleBackColor = true;
			// 
			// btnAddJump
			// 
			btnAddJump.Location = new Point(178, 23);
			btnAddJump.Name = "btnAddJump";
			btnAddJump.Size = new Size(32, 32);
			btnAddJump.TabIndex = 2;
			btnAddJump.Text = "+";
			btnAddJump.UseVisualStyleBackColor = true;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// button1
			// 
			button1.Location = new Point(110, 28);
			button1.Name = "button1";
			button1.Size = new Size(24, 22);
			button1.TabIndex = 4;
			button1.Text = ">";
			button1.UseVisualStyleBackColor = true;
			// 
			// RelativeJumpPanel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(223, 58);
			Controls.Add(button1);
			Controls.Add(btnAddJump);
			Controls.Add(btnSubJump);
			Controls.Add(hexEdit1);
			Name = "RelativeJumpPanel";
			Text = "RelativeJumpPanel";
			TopMost = true;
			ResumeLayout(false);
		}

		#endregion

		private HexEdit hexEdit1;
		private Button btnSubJump;
		private Button btnAddJump;
		private ContextMenuStrip contextMenuStrip1;
		private Button button1;
	}
}