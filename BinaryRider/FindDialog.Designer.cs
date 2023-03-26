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
			comboBox1 = new ComboBox();
			groupBox1 = new GroupBox();
			radioButton1 = new RadioButton();
			groupBox2 = new GroupBox();
			radioButton4 = new RadioButton();
			radioButton5 = new RadioButton();
			radioButton6 = new RadioButton();
			button1 = new Button();
			button2 = new Button();
			comboBox2 = new ComboBox();
			comboBox3 = new ComboBox();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(22, 25);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(318, 23);
			comboBox1.TabIndex = 0;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(radioButton1);
			groupBox1.Location = new Point(22, 54);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(318, 49);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "種別";
			// 
			// radioButton1
			// 
			radioButton1.AutoSize = true;
			radioButton1.Location = new Point(8, 22);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new Size(54, 19);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "1Byte";
			radioButton1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(comboBox3);
			groupBox2.Controls.Add(comboBox2);
			groupBox2.Controls.Add(radioButton4);
			groupBox2.Controls.Add(radioButton5);
			groupBox2.Controls.Add(radioButton6);
			groupBox2.Location = new Point(22, 109);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(318, 85);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "検索範囲";
			// 
			// radioButton4
			// 
			radioButton4.AutoSize = true;
			radioButton4.Location = new Point(8, 47);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new Size(117, 19);
			radioButton4.TabIndex = 2;
			radioButton4.TabStop = true;
			radioButton4.Text = "範囲指定(16進数)";
			radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			radioButton5.AutoSize = true;
			radioButton5.Location = new Point(108, 22);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new Size(68, 19);
			radioButton5.TabIndex = 1;
			radioButton5.TabStop = true;
			radioButton5.Text = "先頭から";
			radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton6
			// 
			radioButton6.AutoSize = true;
			radioButton6.Location = new Point(8, 22);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new Size(85, 19);
			radioButton6.TabIndex = 0;
			radioButton6.TabStop = true;
			radioButton6.Text = "カーソル位置";
			radioButton6.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.Location = new Point(164, 200);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 4;
			button1.Text = "前検索";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Location = new Point(245, 200);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 5;
			button2.Text = "後検索";
			button2.UseVisualStyleBackColor = true;
			// 
			// comboBox2
			// 
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new Point(131, 47);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new Size(73, 23);
			comboBox2.TabIndex = 3;
			// 
			// comboBox3
			// 
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new Point(223, 46);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new Size(73, 23);
			comboBox3.TabIndex = 4;
			// 
			// FindDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(364, 236);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(comboBox1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "FindDialog";
			Text = "FindDialog";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private ComboBox comboBox1;
		private GroupBox groupBox1;
		private RadioButton radioButton1;
		private GroupBox groupBox2;
		private ComboBox comboBox3;
		private ComboBox comboBox2;
		private RadioButton radioButton4;
		private RadioButton radioButton5;
		private RadioButton radioButton6;
		private Button button1;
		private Button button2;
	}
}