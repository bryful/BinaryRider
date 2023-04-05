namespace BinaryRider
{
	partial class EditValue
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
			hexEdit1 = new HexEdit();
			combosKind1 = new ComboSKind();
			bitEdit1 = new BitEdit();
			hexEdit2 = new HexEdit();
			radioButton1 = new RadioButton();
			radioButton2 = new RadioButton();
			numericUpDown1 = new NumericUpDown();
			button1 = new Button();
			button2 = new Button();
			radioButton3 = new RadioButton();
			groupBox1 = new GroupBox();
			label1 = new Label();
			checkBox1 = new CheckBox();
			groupBox2 = new GroupBox();
			button4 = new Button();
			button3 = new Button();
			groupBox3 = new GroupBox();
			textBox1 = new TextBox();
			radioButton5 = new RadioButton();
			radioButton4 = new RadioButton();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// hexEdit1
			// 
			hexEdit1.Alignment = StringAlignment.Center;
			hexEdit1.BackColor = SystemColors.Window;
			hexEdit1.BackColorMid = SystemColors.Control;
			hexEdit1.CanEdit = false;
			hexEdit1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			hexEdit1.ForeColor = SystemColors.ControlText;
			hexEdit1.Location = new Point(37, 14);
			hexEdit1.Name = "hexEdit1";
			hexEdit1.Size = new Size(160, 29);
			hexEdit1.TabIndex = 0;
			hexEdit1.Text = "hexEdit1";
			hexEdit1.UsedByte = 8;
			hexEdit1.Value = 0L;
			// 
			// combosKind1
			// 
			combosKind1.DropDownStyle = ComboBoxStyle.DropDownList;
			combosKind1.FormattingEnabled = true;
			combosKind1.Items.AddRange(new object[] { "None", "sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong", "StrShiftJIS", "StrUtf8" });
			combosKind1.Location = new Point(268, 17);
			combosKind1.Name = "combosKind1";
			combosKind1.Size = new Size(121, 23);
			combosKind1.SKind = SKind.Slong;
			combosKind1.TabIndex = 1;
			// 
			// bitEdit1
			// 
			bitEdit1.BitInter = 2;
			bitEdit1.BitType = BitType.Bulong;
			bitEdit1.BitWidth = 8;
			bitEdit1.Location = new Point(23, 41);
			bitEdit1.Name = "bitEdit1";
			bitEdit1.Size = new Size(656, 12);
			bitEdit1.TabIndex = 2;
			bitEdit1.Text = "bitEdit1";
			bitEdit1.Value = 100UL;
			// 
			// hexEdit2
			// 
			hexEdit2.Alignment = StringAlignment.Center;
			hexEdit2.BackColor = SystemColors.Window;
			hexEdit2.BackColorMid = SystemColors.Control;
			hexEdit2.CanEdit = true;
			hexEdit2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			hexEdit2.ForeColor = SystemColors.ControlText;
			hexEdit2.Location = new Point(129, 64);
			hexEdit2.Name = "hexEdit2";
			hexEdit2.Size = new Size(160, 29);
			hexEdit2.TabIndex = 3;
			hexEdit2.Text = "hexEdit2";
			hexEdit2.UsedByte = 8;
			hexEdit2.Value = 0L;
			// 
			// radioButton1
			// 
			radioButton1.AutoSize = true;
			radioButton1.Location = new Point(23, 16);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new Size(58, 19);
			radioButton1.TabIndex = 4;
			radioButton1.TabStop = true;
			radioButton1.Text = "binary";
			radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			radioButton2.AutoSize = true;
			radioButton2.Checked = true;
			radioButton2.Location = new Point(23, 70);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new Size(91, 19);
			radioButton2.TabIndex = 5;
			radioButton2.TabStop = true;
			radioButton2.Text = "hexadecimal";
			radioButton2.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			numericUpDown1.Location = new Point(120, 109);
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new Size(552, 23);
			numericUpDown1.TabIndex = 6;
			// 
			// button1
			// 
			button1.Location = new Point(496, 353);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 7;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Location = new Point(577, 353);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 8;
			button2.Text = "OK";
			button2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			radioButton3.AutoSize = true;
			radioButton3.Location = new Point(23, 109);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new Size(70, 19);
			radioButton3.TabIndex = 9;
			radioButton3.TabStop = true;
			radioButton3.Text = "Decimal ";
			radioButton3.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(hexEdit1);
			groupBox1.Controls.Add(combosKind1);
			groupBox1.Location = new Point(12, 28);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(693, 53);
			groupBox1.TabIndex = 10;
			groupBox1.TabStop = false;
			groupBox1.Text = "Adress";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(218, 21);
			label1.Name = "label1";
			label1.Size = new Size(44, 15);
			label1.TabIndex = 3;
			label1.Text = "Integer";
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = CheckState.Checked;
			checkBox1.Location = new Point(23, 160);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(79, 19);
			checkBox1.TabIndex = 2;
			checkBox1.Text = "BigEndian";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(button4);
			groupBox2.Controls.Add(checkBox1);
			groupBox2.Controls.Add(button3);
			groupBox2.Controls.Add(bitEdit1);
			groupBox2.Controls.Add(radioButton1);
			groupBox2.Controls.Add(radioButton3);
			groupBox2.Controls.Add(radioButton2);
			groupBox2.Controls.Add(hexEdit2);
			groupBox2.Controls.Add(numericUpDown1);
			groupBox2.Location = new Point(12, 87);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(693, 189);
			groupBox2.TabIndex = 11;
			groupBox2.TabStop = false;
			groupBox2.Text = "Value";
			// 
			// button4
			// 
			button4.Location = new Point(516, 160);
			button4.Name = "button4";
			button4.Size = new Size(75, 23);
			button4.TabIndex = 14;
			button4.Text = "bit <<";
			button4.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			button3.Location = new Point(597, 160);
			button3.Name = "button3";
			button3.Size = new Size(75, 23);
			button3.TabIndex = 13;
			button3.Text = "bit >>";
			button3.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(textBox1);
			groupBox3.Controls.Add(radioButton5);
			groupBox3.Controls.Add(radioButton4);
			groupBox3.Location = new Point(19, 282);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(689, 65);
			groupBox3.TabIndex = 12;
			groupBox3.TabStop = false;
			groupBox3.Text = "Rtring";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(184, 25);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new Size(484, 23);
			textBox1.TabIndex = 2;
			// 
			// radioButton5
			// 
			radioButton5.AutoSize = true;
			radioButton5.Location = new Point(84, 29);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new Size(55, 19);
			radioButton5.TabIndex = 1;
			radioButton5.TabStop = true;
			radioButton5.Text = "UTF-8";
			radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			radioButton4.AutoSize = true;
			radioButton4.Location = new Point(15, 29);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new Size(63, 19);
			radioButton4.TabIndex = 0;
			radioButton4.TabStop = true;
			radioButton4.Text = "Shit-JIS";
			radioButton4.UseVisualStyleBackColor = true;
			// 
			// EditValue
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(720, 389);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(button2);
			Controls.Add(button1);
			IsHideAndColse = true;
			Name = "EditValue";
			Text = "EditValue";
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private HexEdit hexEdit1;
		private ComboSKind combosKind1;
		private BitEdit bitEdit1;
		private HexEdit hexEdit2;
		private RadioButton radioButton1;
		private RadioButton radioButton2;
		private NumericUpDown numericUpDown1;
		private Button button1;
		private Button button2;
		private RadioButton radioButton3;
		private GroupBox groupBox1;
		private Label label1;
		private CheckBox checkBox1;
		private GroupBox groupBox2;
		private Button button4;
		private Button button3;
		private GroupBox groupBox3;
		private TextBox textBox1;
		private RadioButton radioButton5;
		private RadioButton radioButton4;
	}
}