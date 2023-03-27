namespace BinaryRider
{
	partial class JumpDialog
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
			btnJump = new Button();
			btnClose = new Button();
			lbInfo = new Label();
			hexEdit1 = new HexEdit();
			SuspendLayout();
			// 
			// btnJump
			// 
			btnJump.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnJump.Location = new Point(126, 66);
			btnJump.Name = "btnJump";
			btnJump.Size = new Size(85, 28);
			btnJump.TabIndex = 3;
			btnJump.Text = "Jump";
			btnJump.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			btnClose.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnClose.Location = new Point(35, 66);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(85, 28);
			btnClose.TabIndex = 2;
			btnClose.Text = "Close";
			btnClose.UseVisualStyleBackColor = true;
			// 
			// lbInfo
			// 
			lbInfo.AutoSize = true;
			lbInfo.Location = new Point(14, 10);
			lbInfo.Name = "lbInfo";
			lbInfo.Size = new Size(35, 15);
			lbInfo.TabIndex = 0;
			lbInfo.Text = "Jump";
			// 
			// hexEdit1
			// 
			hexEdit1.Alignment = StringAlignment.Center;
			hexEdit1.BackColor = SystemColors.Window;
			hexEdit1.BackColorMid = SystemColors.Control;
			hexEdit1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			hexEdit1.ForeColor = SystemColors.ControlText;
			hexEdit1.Location = new Point(17, 28);
			hexEdit1.Name = "hexEdit1";
			hexEdit1.Size = new Size(195, 35);
			hexEdit1.TabIndex = 1;
			hexEdit1.Text = "hexEdit3";
			hexEdit1.UsedByte = 8;
			hexEdit1.Value = 3L;
			// 
			// JumpDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(228, 106);
			Controls.Add(hexEdit1);
			Controls.Add(lbInfo);
			Controls.Add(btnClose);
			Controls.Add(btnJump);
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "JumpDialog";
			StartPosition = FormStartPosition.CenterParent;
			Text = "JumpDialog";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button btnJump;
		private Button btnClose;
		private Label lbInfo;
		private HexEdit hexEdit1;
	}
}