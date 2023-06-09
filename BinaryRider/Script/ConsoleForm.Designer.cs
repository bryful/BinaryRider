﻿namespace BinaryRider
{
	partial class ConsoleForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleForm));
			toolStrip1 = new ToolStrip();
			btnClear = new ToolStripButton();
			btnFont = new ToolStripButton();
			tbOutput = new TextBox();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// toolStrip1
			// 
			toolStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			toolStrip1.AutoSize = false;
			toolStrip1.Dock = DockStyle.None;
			toolStrip1.Items.AddRange(new ToolStripItem[] { btnClear, btnFont });
			toolStrip1.Location = new Point(0, 22);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(702, 25);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			// 
			// btnClear
			// 
			btnClear.DisplayStyle = ToolStripItemDisplayStyle.Text;
			btnClear.Image = (Image)resources.GetObject("btnClear.Image");
			btnClear.ImageTransparentColor = Color.Magenta;
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(37, 22);
			btnClear.Text = "Clear";
			btnClear.Click += btnClear_Click;
			// 
			// btnFont
			// 
			btnFont.DisplayStyle = ToolStripItemDisplayStyle.Text;
			btnFont.Image = (Image)resources.GetObject("btnFont.Image");
			btnFont.ImageTransparentColor = Color.Magenta;
			btnFont.Name = "btnFont";
			btnFont.Size = new Size(35, 22);
			btnFont.Text = "Font";
			// 
			// tbOutput
			// 
			tbOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tbOutput.BackColor = SystemColors.Control;
			tbOutput.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbOutput.ForeColor = SystemColors.ControlText;
			tbOutput.Location = new Point(0, 48);
			tbOutput.Margin = new Padding(5);
			tbOutput.MaxLength = 65536;
			tbOutput.Multiline = true;
			tbOutput.Name = "tbOutput";
			tbOutput.ScrollBars = ScrollBars.Vertical;
			tbOutput.Size = new Size(702, 122);
			tbOutput.TabIndex = 1;
			tbOutput.Text = "123456";
			// 
			// ConsoleForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CanResize = true;
			ClientSize = new Size(702, 186);
			ControlBox = false;
			Controls.Add(tbOutput);
			Controls.Add(toolStrip1);
			MaximizeBox = false;
			MdiChildrenMinimizedAnchorBottom = false;
			MinimizeBox = false;
			Name = "ConsoleForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "ConsoleForm";
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip toolStrip1;
		private TextBox tbOutput;
		private ToolStripButton btnClear;
		private ToolStripButton btnFont;
	}
}