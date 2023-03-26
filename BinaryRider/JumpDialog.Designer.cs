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
			hexBox1 = new HexBox();
			cbHex = new CheckBox();
			btnJump = new Button();
			btnClose = new Button();
			lbInfo = new Label();
			hexEdit1 = new HexEdit();
			SuspendLayout();
			// 
			// hexBox1
			// 
			hexBox1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			hexBox1.IsHex = true;
			hexBox1.Location = new Point(24, 28);
			hexBox1.Name = "hexBox1";
			hexBox1.Size = new Size(203, 29);
			hexBox1.TabIndex = 0;
			hexBox1.Text = "0";
			hexBox1.Value = 0L;
			// 
			// cbHex
			// 
			cbHex.AutoSize = true;
			cbHex.Checked = true;
			cbHex.CheckState = CheckState.Checked;
			cbHex.Location = new Point(233, 32);
			cbHex.Name = "cbHex";
			cbHex.Size = new Size(62, 19);
			cbHex.TabIndex = 1;
			cbHex.Text = "16進数";
			cbHex.UseVisualStyleBackColor = true;
			// 
			// btnJump
			// 
			btnJump.DialogResult = DialogResult.OK;
			btnJump.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnJump.Location = new Point(210, 63);
			btnJump.Name = "btnJump";
			btnJump.Size = new Size(85, 28);
			btnJump.TabIndex = 2;
			btnJump.Text = "Jump";
			btnJump.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			btnClose.DialogResult = DialogResult.Cancel;
			btnClose.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnClose.Location = new Point(119, 63);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(85, 28);
			btnClose.TabIndex = 3;
			btnClose.Text = "Close";
			btnClose.UseVisualStyleBackColor = true;
			// 
			// lbInfo
			// 
			lbInfo.AutoSize = true;
			lbInfo.Location = new Point(14, 10);
			lbInfo.Name = "lbInfo";
			lbInfo.Size = new Size(35, 15);
			lbInfo.TabIndex = 4;
			lbInfo.Text = "Jump";
			// 
			// hexEdit1
			// 
			hexEdit1.Alignment = StringAlignment.Center;
			hexEdit1.BackColor = SystemColors.Control;
			hexEdit1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			hexEdit1.ForeColor = SystemColors.ControlText;
			hexEdit1.Location = new Point(24, 97);
			hexEdit1.Name = "hexEdit1";
			hexEdit1.Size = new Size(120, 33);
			hexEdit1.TabIndex = 5;
			hexEdit1.Text = "hexEdit1";
			hexEdit1.Value = 0L;
			// 
			// JumpDialog
			// 
			AcceptButton = btnJump;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnClose;
			ClientSize = new Size(338, 147);
			Controls.Add(hexEdit1);
			Controls.Add(lbInfo);
			Controls.Add(btnClose);
			Controls.Add(btnJump);
			Controls.Add(cbHex);
			Controls.Add(hexBox1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "JumpDialog";
			StartPosition = FormStartPosition.CenterParent;
			Text = "JumpDialog";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private HexBox hexBox1;
		private CheckBox cbHex;
		private Button btnJump;
		private Button btnClose;
		private Label lbInfo;
		private HexEdit hexEdit1;
	}
}