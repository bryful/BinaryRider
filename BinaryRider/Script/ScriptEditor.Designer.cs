namespace BinaryRider
{
	partial class ScriptEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptEditor));
			roslynEdit1 = new RoslynEdit();
			toolStrip1 = new ToolStrip();
			btnHide = new ToolStripButton();
			btnFont = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
			btnV8Execute = new ToolStripButton();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// roslynEdit1
			// 
			roslynEdit1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			roslynEdit1.Font = new Font("源ノ角ゴシック Code JP R", 12F, FontStyle.Regular, GraphicsUnit.Point);
			roslynEdit1.Location = new Point(0, 28);
			roslynEdit1.Name = "roslynEdit1";
			roslynEdit1.Size = new Size(790, 345);
			roslynEdit1.TabIndex = 1;
			// 
			// toolStrip1
			// 
			toolStrip1.Items.AddRange(new ToolStripItem[] { btnHide, btnFont, toolStripSeparator2, btnV8Execute });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(790, 25);
			toolStrip1.TabIndex = 2;
			toolStrip1.Text = "toolStrip1";
			// 
			// btnHide
			// 
			btnHide.Alignment = ToolStripItemAlignment.Right;
			btnHide.DisplayStyle = ToolStripItemDisplayStyle.Text;
			btnHide.Image = (Image)resources.GetObject("btnHide.Image");
			btnHide.ImageTransparentColor = Color.Magenta;
			btnHide.Name = "btnHide";
			btnHide.Size = new Size(36, 22);
			btnHide.Text = "Hide";
			btnHide.Click += btnHide_Click;
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
			// toolStripSeparator2
			// 
			toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 25);
			// 
			// btnV8Execute
			// 
			btnV8Execute.Alignment = ToolStripItemAlignment.Right;
			btnV8Execute.AutoSize = false;
			btnV8Execute.BackColor = SystemColors.ControlLight;
			btnV8Execute.DisplayStyle = ToolStripItemDisplayStyle.Text;
			btnV8Execute.Image = (Image)resources.GetObject("btnV8Execute.Image");
			btnV8Execute.ImageTransparentColor = Color.Magenta;
			btnV8Execute.Margin = new Padding(5, 1, 5, 2);
			btnV8Execute.Name = "btnV8Execute";
			btnV8Execute.Padding = new Padding(5, 0, 5, 0);
			btnV8Execute.Size = new Size(100, 22);
			btnV8Execute.Text = "Execute";
			btnV8Execute.Click += btnV8Execute_Click;
			// 
			// ScriptEditor
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(790, 373);
			ControlBox = false;
			Controls.Add(toolStrip1);
			Controls.Add(roslynEdit1);
			MaximizeBox = false;
			MdiChildrenMinimizedAnchorBottom = false;
			MinimizeBox = false;
			Name = "ScriptEditor";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "ScriptEditor";
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private RoslynEdit roslynEdit1;
		private ToolStrip toolStrip1;
		private ToolStripButton btnFont;
		private ToolStripButton btnV8Execute;
		private ToolStripButton btnHide;
		private ToolStripSeparator toolStripSeparator2;
	}
}