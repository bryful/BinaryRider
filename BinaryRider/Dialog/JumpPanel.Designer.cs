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
			heRelative = new HexEdit();
			btnSub = new Button();
			btnAdd = new Button();
			btnHis = new Button();
			lbHistory = new ListBox();
			btnPush = new Button();
			btnDelete = new Button();
			label1 = new Label();
			label2 = new Label();
			heAbsAdress = new HexEdit();
			btnJump = new Button();
			btnTop = new Button();
			btnEnd = new Button();
			SuspendLayout();
			// 
			// heRelative
			// 
			heRelative.Alignment = StringAlignment.Center;
			heRelative.BackColor = SystemColors.Window;
			heRelative.BackColorMid = SystemColors.Control;
			heRelative.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			heRelative.ForeColor = SystemColors.ControlText;
			heRelative.Location = new Point(68, 104);
			heRelative.Name = "heRelative";
			heRelative.Size = new Size(96, 32);
			heRelative.TabIndex = 4;
			heRelative.Text = "hexEdit1";
			heRelative.UsedByte = 4;
			heRelative.Value = 0L;
			// 
			// btnSub
			// 
			btnSub.FlatStyle = FlatStyle.Flat;
			btnSub.Location = new Point(196, 108);
			btnSub.Name = "btnSub";
			btnSub.Size = new Size(32, 25);
			btnSub.TabIndex = 6;
			btnSub.Text = "- ";
			btnSub.UseVisualStyleBackColor = true;
			// 
			// btnAdd
			// 
			btnAdd.FlatStyle = FlatStyle.Flat;
			btnAdd.Location = new Point(234, 108);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(32, 25);
			btnAdd.TabIndex = 7;
			btnAdd.Text = "+";
			btnAdd.UseVisualStyleBackColor = true;
			// 
			// btnHis
			// 
			btnHis.FlatStyle = FlatStyle.Flat;
			btnHis.Location = new Point(166, 109);
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
			lbHistory.Location = new Point(68, 151);
			lbHistory.Name = "lbHistory";
			lbHistory.ScrollAlwaysVisible = true;
			lbHistory.Size = new Size(198, 214);
			lbHistory.Sorted = true;
			lbHistory.TabIndex = 10;
			// 
			// btnPush
			// 
			btnPush.FlatStyle = FlatStyle.Flat;
			btnPush.Location = new Point(7, 151);
			btnPush.Name = "btnPush";
			btnPush.Size = new Size(52, 23);
			btnPush.TabIndex = 8;
			btnPush.Text = "Push";
			btnPush.UseVisualStyleBackColor = true;
			// 
			// btnDelete
			// 
			btnDelete.FlatStyle = FlatStyle.Flat;
			btnDelete.Location = new Point(7, 342);
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
			label2.Location = new Point(14, 113);
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
			// btnJump
			// 
			btnJump.FlatStyle = FlatStyle.Flat;
			btnJump.Location = new Point(196, 68);
			btnJump.Name = "btnJump";
			btnJump.Size = new Size(64, 25);
			btnJump.TabIndex = 2;
			btnJump.Text = "Jump";
			btnJump.UseVisualStyleBackColor = true;
			// 
			// btnTop
			// 
			btnTop.FlatStyle = FlatStyle.Flat;
			btnTop.Location = new Point(68, 68);
			btnTop.Name = "btnTop";
			btnTop.Size = new Size(52, 25);
			btnTop.TabIndex = 11;
			btnTop.Text = "Top";
			btnTop.UseVisualStyleBackColor = true;
			// 
			// btnEnd
			// 
			btnEnd.FlatStyle = FlatStyle.Flat;
			btnEnd.Location = new Point(126, 68);
			btnEnd.Name = "btnEnd";
			btnEnd.Size = new Size(52, 25);
			btnEnd.TabIndex = 12;
			btnEnd.Text = "End";
			btnEnd.UseVisualStyleBackColor = true;
			// 
			// JumpPanel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CanResize = true;
			ClientSize = new Size(278, 372);
			Controls.Add(btnEnd);
			Controls.Add(btnTop);
			Controls.Add(btnJump);
			Controls.Add(heAbsAdress);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(btnDelete);
			Controls.Add(btnPush);
			Controls.Add(lbHistory);
			Controls.Add(btnHis);
			Controls.Add(btnAdd);
			Controls.Add(btnSub);
			Controls.Add(heRelative);
			Name = "JumpPanel";
			ShowInTaskbar = false;
			Text = "Adress Jump";
			TopMost = true;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private HexEdit heRelative;
		private Button btnSub;
		private Button btnAdd;
		private Button btnHis;
		private ListBox lbHistory;
		private Button btnPush;
		private Button btnDelete;
		private Label label1;
		private Label label2;
		private HexEdit heAbsAdress;
		private Button btnJump;
		private Button btnTop;
		private Button btnEnd;
	}
}