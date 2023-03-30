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
			radioButton1 = new RadioButton();
			radioButton3 = new RadioButton();
			comboBox1 = new ComboBox();
			comboBox3 = new ComboBox();
			groupBox1 = new GroupBox();
			label1 = new Label();
			comboBox2 = new ComboBox();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			label2 = new Label();
			button4 = new Button();
			textBox1 = new TextBox();
			label3 = new Label();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// radioButton1
			// 
			radioButton1.AutoSize = true;
			radioButton1.Location = new Point(14, 22);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new Size(79, 19);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "Byte Array";
			radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			radioButton3.AutoSize = true;
			radioButton3.Location = new Point(14, 66);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new Size(61, 19);
			radioButton3.TabIndex = 2;
			radioButton3.TabStop = true;
			radioButton3.Text = "Strings";
			radioButton3.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(99, 18);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(279, 23);
			comboBox1.TabIndex = 6;
			// 
			// comboBox3
			// 
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new Point(99, 62);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new Size(279, 23);
			comboBox3.TabIndex = 8;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(comboBox2);
			groupBox1.Controls.Add(radioButton3);
			groupBox1.Controls.Add(comboBox1);
			groupBox1.Controls.Add(comboBox3);
			groupBox1.Controls.Add(radioButton1);
			groupBox1.Location = new Point(12, 38);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(423, 128);
			groupBox1.TabIndex = 9;
			groupBox1.TabStop = false;
			groupBox1.Text = "groupBox1";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(99, 44);
			label1.Name = "label1";
			label1.Size = new Size(254, 15);
			label1.TabIndex = 10;
			label1.Text = "１６進数は0xで　カンマ(,)区切りで指定してください";
			// 
			// comboBox2
			// 
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new Point(189, 91);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new Size(189, 23);
			comboBox2.TabIndex = 9;
			// 
			// button1
			// 
			button1.Location = new Point(27, 172);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 10;
			button1.Text = "先頭から";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Location = new Point(252, 172);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 11;
			button2.Text = "カーソルの後";
			button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			button3.Location = new Point(171, 171);
			button3.Name = "button3";
			button3.Size = new Size(75, 23);
			button3.TabIndex = 12;
			button3.Text = "カーソルの前";
			button3.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(118, 94);
			label2.Name = "label2";
			label2.Size = new Size(58, 15);
			label2.TabIndex = 11;
			label2.Text = "CharCode";
			// 
			// button4
			// 
			button4.Location = new Point(360, 172);
			button4.Name = "button4";
			button4.Size = new Size(75, 23);
			button4.TabIndex = 13;
			button4.Text = "末尾から";
			button4.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(72, 214);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(363, 23);
			textBox1.TabIndex = 14;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(27, 217);
			label3.Name = "label3";
			label3.Size = new Size(39, 15);
			label3.TabIndex = 15;
			label3.Text = "Result";
			// 
			// FindDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(447, 257);
			Controls.Add(label3);
			Controls.Add(textBox1);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(groupBox1);
			Name = "FindDialog";
			Text = "FindDialog";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private RadioButton radioButton1;
		private RadioButton radioButton3;
		private ComboBox comboBox1;
		private ComboBox comboBox3;
		private GroupBox groupBox1;
		private Label label1;
		private ComboBox comboBox2;
		private Button button1;
		private Button button2;
		private Button button3;
		private Label label2;
		private Button button4;
		private TextBox textBox1;
		private Label label3;
	}
}