namespace BinaryRider
{
	partial class JumpPanel
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
			heRelative = new HexEdit();
			btnSubJump = new Button();
			btnAddJump = new Button();
			contextMenuStrip1 = new ContextMenuStrip(components);
			aToolStripMenuItem = new ToolStripMenuItem();
			btnHis = new Button();
			lbHistory = new ListBox();
			btnPush = new Button();
			btnDelete = new Button();
			label1 = new Label();
			label2 = new Label();
			heAbsAdress = new HexEdit();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// heRelative
			// 
			heRelative.Alignment = StringAlignment.Center;
			heRelative.BackColor = SystemColors.Window;
			heRelative.BackColorMid = SystemColors.Control;
			heRelative.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			heRelative.ForeColor = SystemColors.ControlText;
			heRelative.Location = new Point(68, 91);
			heRelative.Name = "heRelative";
			heRelative.Size = new Size(96, 32);
			heRelative.TabIndex = 4;
			heRelative.Text = "hexEdit1";
			heRelative.UsedByte = 4;
			heRelative.Value = 0L;
			// 
			// btnSubJump
			// 
			btnSubJump.FlatStyle = FlatStyle.Flat;
			btnSubJump.Location = new Point(196, 95);
			btnSubJump.Name = "btnSubJump";
			btnSubJump.Size = new Size(32, 25);
			btnSubJump.TabIndex = 6;
			btnSubJump.Text = "- ";
			btnSubJump.UseVisualStyleBackColor = true;
			// 
			// btnAddJump
			// 
			btnAddJump.FlatStyle = FlatStyle.Flat;
			btnAddJump.Location = new Point(234, 95);
			btnAddJump.Name = "btnAddJump";
			btnAddJump.Size = new Size(32, 25);
			btnAddJump.TabIndex = 7;
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
			btnHis.Location = new Point(166, 96);
			btnHis.Name = "btnHis";
			btnHis.Size = new Size(24, 22);
			btnHis.TabIndex = 5;
			btnHis.TabStop = false;
			btnHis.Text = ">";
			btnHis.UseVisualStyleBackColor = true;
			// 
			// lbHistory
			// 
			lbHistory.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbHistory.FormattingEnabled = true;
			lbHistory.ItemHeight = 21;
			lbHistory.Location = new Point(68, 134);
			lbHistory.Name = "lbHistory";
			lbHistory.ScrollAlwaysVisible = true;
			lbHistory.Size = new Size(198, 193);
			lbHistory.Sorted = true;
			lbHistory.TabIndex = 10;
			// 
			// btnPush
			// 
			btnPush.FlatStyle = FlatStyle.Flat;
			btnPush.Location = new Point(7, 134);
			btnPush.Name = "btnPush";
			btnPush.Size = new Size(52, 23);
			btnPush.TabIndex = 8;
			btnPush.Text = "Push";
			btnPush.UseVisualStyleBackColor = true;
			// 
			// btnDelete
			// 
			btnDelete.FlatStyle = FlatStyle.Flat;
			btnDelete.Location = new Point(7, 304);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(52, 23);
			btnDelete.TabIndex = 9;
			btnDelete.Text = "Delete";
			btnDelete.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(7, 39);
			label1.Name = "label1";
			label1.Size = new Size(54, 15);
			label1.TabIndex = 0;
			label1.Text = "Absolute";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(14, 100);
			label2.Name = "label2";
			label2.Size = new Size(48, 15);
			label2.TabIndex = 3;
			label2.Text = "Relative";
			// 
			// heAbsAdress
			// 
			heAbsAdress.Alignment = StringAlignment.Center;
			heAbsAdress.BackColor = SystemColors.Window;
			heAbsAdress.BackColorMid = SystemColors.Control;
			heAbsAdress.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			heAbsAdress.ForeColor = SystemColors.ControlText;
			heAbsAdress.Location = new Point(68, 30);
			heAbsAdress.Name = "heAbsAdress";
			heAbsAdress.Size = new Size(192, 32);
			heAbsAdress.TabIndex = 1;
			heAbsAdress.Text = "hexEdit2";
			heAbsAdress.UsedByte = 8;
			heAbsAdress.Value = 0L;
			// 
			// button1
			// 
			button1.FlatStyle = FlatStyle.Flat;
			button1.Location = new Point(196, 68);
			button1.Name = "button1";
			button1.Size = new Size(64, 25);
			button1.TabIndex = 2;
			button1.Text = "Jump";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.FlatStyle = FlatStyle.Flat;
			button2.Location = new Point(68, 68);
			button2.Name = "button2";
			button2.Size = new Size(52, 25);
			button2.TabIndex = 11;
			button2.Text = "Top";
			button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			button3.FlatStyle = FlatStyle.Flat;
			button3.Location = new Point(126, 68);
			button3.Name = "button3";
			button3.Size = new Size(52, 25);
			button3.TabIndex = 12;
			button3.Text = "End";
			button3.UseVisualStyleBackColor = true;
			// 
			// JumpPanel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CanResize = true;
			ClientSize = new Size(276, 339);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(heAbsAdress);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(btnDelete);
			Controls.Add(btnPush);
			Controls.Add(lbHistory);
			Controls.Add(btnHis);
			Controls.Add(btnAddJump);
			Controls.Add(btnSubJump);
			Controls.Add(heRelative);
			Name = "JumpPanel";
			Text = "Adress Jump";
			TopMost = true;
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private HexEdit heRelative;
		private Button btnSubJump;
		private Button btnAddJump;
		private ContextMenuStrip contextMenuStrip1;
		private Button btnHis;
		private ListBox lbHistory;
		private Button btnPush;
		private Button btnDelete;
		private ToolStripMenuItem aToolStripMenuItem;
		private Label label1;
		private Label label2;
		private HexEdit heAbsAdress;
		private Button button1;
		private Button button2;
		private Button button3;
	}
}