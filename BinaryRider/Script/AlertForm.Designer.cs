namespace BinaryRider
{
	partial class AlertForm
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
			textBox1 = new TextBox();
			btnOK = new Button();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBox1.BackColor = SystemColors.ControlLightLight;
			textBox1.BorderStyle = BorderStyle.FixedSingle;
			textBox1.ForeColor = SystemColors.ControlText;
			textBox1.Location = new Point(12, 12);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.ScrollBars = ScrollBars.Both;
			textBox1.Size = new Size(398, 129);
			textBox1.TabIndex = 0;
			// 
			// btnOK
			// 
			btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnOK.DialogResult = DialogResult.OK;
			btnOK.FlatStyle = FlatStyle.Flat;
			btnOK.ForeColor = SystemColors.ControlText;
			btnOK.Location = new Point(335, 147);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// AlertForm
			// 
			AcceptButton = btnOK;
			AutoScaleMode = AutoScaleMode.None;
			BackColor = SystemColors.Control;
			ClientSize = new Size(422, 182);
			Controls.Add(btnOK);
			Controls.Add(textBox1);
			ForeColor = SystemColors.ControlText;
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			MaximizeBox = false;
			MdiChildrenMinimizedAnchorBottom = false;
			MinimizeBox = false;
			Name = "AlertForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			TopMost = true;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private Button btnOK;
	}
}