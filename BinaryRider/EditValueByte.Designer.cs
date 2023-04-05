namespace BinaryRider
{
	partial class EditValueByte
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
			bitEdit1 = new BitEdit();
			hexEdit1 = new HexEdit();
			numericUpDown1 = new NumericUpDown();
			textBox1 = new TextBox();
			btnCancel = new Button();
			btnOK = new Button();
			btnShl = new Button();
			btnShr = new Button();
			lbBin = new Label();
			lbHex = new Label();
			lbDec = new Label();
			btnOrg = new Button();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			SuspendLayout();
			// 
			// bitEdit1
			// 
			bitEdit1.BitInter = 2;
			bitEdit1.BitType = BitType.Bbyte;
			bitEdit1.BitWidth = 15;
			bitEdit1.Location = new Point(42, 39);
			bitEdit1.Name = "bitEdit1";
			bitEdit1.Size = new Size(138, 19);
			bitEdit1.TabIndex = 1;
			bitEdit1.Text = "bitEdit1";
			bitEdit1.Value = 0UL;
			// 
			// hexEdit1
			// 
			hexEdit1.Alignment = StringAlignment.Center;
			hexEdit1.BackColor = SystemColors.Window;
			hexEdit1.BackColorMid = SystemColors.Control;
			hexEdit1.CanEdit = true;
			hexEdit1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			hexEdit1.ForeColor = SystemColors.ControlText;
			hexEdit1.Location = new Point(44, 63);
			hexEdit1.Name = "hexEdit1";
			hexEdit1.Size = new Size(24, 32);
			hexEdit1.TabIndex = 5;
			hexEdit1.Text = "hexEdit1";
			hexEdit1.UsedByte = 1;
			hexEdit1.Value = 0L;
			// 
			// numericUpDown1
			// 
			numericUpDown1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			numericUpDown1.Location = new Point(115, 67);
			numericUpDown1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new Size(60, 29);
			numericUpDown1.TabIndex = 7;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(186, 70);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new Size(70, 23);
			textBox1.TabIndex = 8;
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Location = new Point(105, 105);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 9;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(186, 105);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 10;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// btnShl
			// 
			btnShl.Location = new Point(186, 37);
			btnShl.Name = "btnShl";
			btnShl.Size = new Size(39, 23);
			btnShl.TabIndex = 2;
			btnShl.Text = "<<";
			btnShl.UseVisualStyleBackColor = true;
			// 
			// btnShr
			// 
			btnShr.Location = new Point(231, 37);
			btnShr.Name = "btnShr";
			btnShr.Size = new Size(39, 23);
			btnShr.TabIndex = 3;
			btnShr.Text = ">>";
			btnShr.UseVisualStyleBackColor = true;
			// 
			// lbBin
			// 
			lbBin.AutoSize = true;
			lbBin.Location = new Point(12, 40);
			lbBin.Name = "lbBin";
			lbBin.Size = new Size(24, 15);
			lbBin.TabIndex = 11;
			lbBin.Text = "bin";
			// 
			// lbHex
			// 
			lbHex.AutoSize = true;
			lbHex.Location = new Point(12, 73);
			lbHex.Name = "lbHex";
			lbHex.Size = new Size(26, 15);
			lbHex.TabIndex = 12;
			lbHex.Text = "hex";
			// 
			// lbDec
			// 
			lbDec.AutoSize = true;
			lbDec.Location = new Point(83, 74);
			lbDec.Name = "lbDec";
			lbDec.Size = new Size(26, 15);
			lbDec.TabIndex = 13;
			lbDec.Text = "dec";
			// 
			// btnOrg
			// 
			btnOrg.Location = new Point(12, 105);
			btnOrg.Name = "btnOrg";
			btnOrg.Size = new Size(56, 23);
			btnOrg.TabIndex = 14;
			btnOrg.Text = "Org";
			btnOrg.UseVisualStyleBackColor = true;
			// 
			// EditValueByte
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(283, 140);
			Controls.Add(btnOrg);
			Controls.Add(lbDec);
			Controls.Add(lbHex);
			Controls.Add(lbBin);
			Controls.Add(btnShr);
			Controls.Add(btnShl);
			Controls.Add(btnOK);
			Controls.Add(btnCancel);
			Controls.Add(textBox1);
			Controls.Add(numericUpDown1);
			Controls.Add(hexEdit1);
			Controls.Add(bitEdit1);
			IsHideAndColse = true;
			Name = "EditValueByte";
			StartPosition = FormStartPosition.CenterParent;
			Text = "EditValueByte";
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private BitEdit bitEdit1;
		private HexEdit hexEdit1;
		private NumericUpDown numericUpDown1;
		private TextBox textBox1;
		private Button btnCancel;
		private Button btnOK;
		private Button btnShl;
		private Button btnShr;
		private Label lbBin;
		private Label lbHex;
		private Label lbDec;
		private Button btnOrg;
	}
}