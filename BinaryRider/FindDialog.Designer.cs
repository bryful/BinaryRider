namespace BinaryRider
{
	partial class FindDialog
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
			rbByte = new RadioButton();
			rbString = new RadioButton();
			groupBox1 = new GroupBox();
			cmbString = new ComboHistory();
			cmbByte = new ComboHistory();
			cmbCharMode = new ComboCharCode();
			label2 = new Label();
			label1 = new Label();
			btnFromTop = new Button();
			btnBackward = new Button();
			btnForward = new Button();
			btnFromEnd = new Button();
			label3 = new Label();
			groupBox2 = new GroupBox();
			tbResult = new TextBox();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// rbByte
			// 
			rbByte.AutoSize = true;
			rbByte.Checked = true;
			rbByte.Location = new Point(14, 22);
			rbByte.Name = "rbByte";
			rbByte.Size = new Size(79, 19);
			rbByte.TabIndex = 0;
			rbByte.TabStop = true;
			rbByte.Text = "Byte Array";
			rbByte.UseVisualStyleBackColor = true;
			// 
			// rbString
			// 
			rbString.AutoSize = true;
			rbString.Location = new Point(14, 66);
			rbString.Name = "rbString";
			rbString.Size = new Size(61, 19);
			rbString.TabIndex = 2;
			rbString.Text = "Strings";
			rbString.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(cmbString);
			groupBox1.Controls.Add(cmbByte);
			groupBox1.Controls.Add(cmbCharMode);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(rbString);
			groupBox1.Controls.Add(rbByte);
			groupBox1.Location = new Point(12, 26);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(423, 128);
			groupBox1.TabIndex = 9;
			groupBox1.TabStop = false;
			groupBox1.Text = "Target";
			// 
			// cmbString
			// 
			cmbString.FormattingEnabled = true;
			cmbString.Location = new Point(102, 65);
			cmbString.Name = "cmbString";
			cmbString.Size = new Size(295, 23);
			cmbString.TabIndex = 14;
			// 
			// cmbByte
			// 
			cmbByte.FormattingEnabled = true;
			cmbByte.Location = new Point(102, 20);
			cmbByte.Name = "cmbByte";
			cmbByte.Size = new Size(295, 23);
			cmbByte.TabIndex = 13;
			// 
			// cmbCharMode
			// 
			cmbCharMode.CharCodeMode = CharCodeMode.UTF8;
			cmbCharMode.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbCharMode.FormattingEnabled = true;
			cmbCharMode.Items.AddRange(new object[] { "UTF8", "ShiftJIS" });
			cmbCharMode.Location = new Point(194, 91);
			cmbCharMode.Name = "cmbCharMode";
			cmbCharMode.Size = new Size(203, 23);
			cmbCharMode.TabIndex = 12;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(130, 94);
			label2.Name = "label2";
			label2.Size = new Size(58, 15);
			label2.TabIndex = 11;
			label2.Text = "CharCode";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(15, 44);
			label1.Name = "label1";
			label1.Size = new Size(382, 15);
			label1.TabIndex = 10;
			label1.Text = "Hexadecimal values should start with '0x' and be separated by commas.";
			// 
			// btnFromTop
			// 
			btnFromTop.Location = new Point(14, 22);
			btnFromTop.Name = "btnFromTop";
			btnFromTop.Size = new Size(75, 23);
			btnFromTop.TabIndex = 10;
			btnFromTop.Text = "FromTop";
			btnFromTop.UseVisualStyleBackColor = true;
			btnFromTop.Click += btnFromTop_Click;
			// 
			// btnBackward
			// 
			btnBackward.Location = new Point(322, 22);
			btnBackward.Name = "btnBackward";
			btnBackward.Size = new Size(75, 23);
			btnBackward.TabIndex = 11;
			btnBackward.Text = "Backward";
			btnBackward.UseVisualStyleBackColor = true;
			btnBackward.Click += btnBackward_Click;
			// 
			// btnForward
			// 
			btnForward.Location = new Point(241, 22);
			btnForward.Name = "btnForward";
			btnForward.Size = new Size(75, 23);
			btnForward.TabIndex = 12;
			btnForward.Text = "Forward";
			btnForward.UseVisualStyleBackColor = true;
			btnForward.Click += btnForward_Click;
			// 
			// btnFromEnd
			// 
			btnFromEnd.Location = new Point(95, 22);
			btnFromEnd.Name = "btnFromEnd";
			btnFromEnd.Size = new Size(75, 23);
			btnFromEnd.TabIndex = 13;
			btnFromEnd.Text = "FromEnd";
			btnFromEnd.UseVisualStyleBackColor = true;
			btnFromEnd.Click += btnFromEnd_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(21, 226);
			label3.Name = "label3";
			label3.Size = new Size(39, 15);
			label3.TabIndex = 15;
			label3.Text = "Result";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnFromTop);
			groupBox2.Controls.Add(btnForward);
			groupBox2.Controls.Add(btnBackward);
			groupBox2.Controls.Add(btnFromEnd);
			groupBox2.Location = new Point(12, 160);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(423, 57);
			groupBox2.TabIndex = 16;
			groupBox2.TabStop = false;
			groupBox2.Text = "Find";
			// 
			// tbResult
			// 
			tbResult.BorderStyle = BorderStyle.FixedSingle;
			tbResult.Location = new Point(66, 226);
			tbResult.Multiline = true;
			tbResult.Name = "tbResult";
			tbResult.ReadOnly = true;
			tbResult.Size = new Size(369, 68);
			tbResult.TabIndex = 17;
			// 
			// FindDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(449, 304);
			Controls.Add(tbResult);
			Controls.Add(groupBox2);
			Controls.Add(label3);
			Controls.Add(groupBox1);
			Name = "FindDialog";
			Text = "Find";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private RadioButton rbByte;
		private RadioButton rbString;
		private GroupBox groupBox1;
		private Label label1;
		private Button btnFromTop;
		private Button btnBackward;
		private Button btnForward;
		private Label label2;
		private Button btnFromEnd;
		private Label label3;
		private ComboCharCode cmbCharMode;
		private ComboHistory cmbString;
		private ComboHistory cmbByte;
		private GroupBox groupBox2;
		private TextBox tbResult;
	}
}