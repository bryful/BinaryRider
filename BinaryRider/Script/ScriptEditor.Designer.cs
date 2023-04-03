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
			btnV8Execute = new ToolStripButton();
			btnFont = new ToolStripButton();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// roslynEdit1
			// 
			roslynEdit1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			roslynEdit1.Font = new Font("源ノ角ゴシック Code JP R", 12F, FontStyle.Regular, GraphicsUnit.Point);
			roslynEdit1.Location = new Point(0, 50);
			roslynEdit1.Name = "roslynEdit1";
			roslynEdit1.Size = new Size(790, 347);
			roslynEdit1.TabIndex = 1;
			// 
			// toolStrip1
			// 
			toolStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			toolStrip1.AutoSize = false;
			toolStrip1.Dock = DockStyle.None;
			toolStrip1.Items.AddRange(new ToolStripItem[] { btnV8Execute, btnFont });
			toolStrip1.Location = new Point(0, 22);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(790, 25);
			toolStrip1.TabIndex = 2;
			toolStrip1.Text = "toolStrip1";
			// 
			// btnV8Execute
			// 
			btnV8Execute.AutoSize = false;
			btnV8Execute.BackColor = SystemColors.ControlLight;
			btnV8Execute.DisplayStyle = ToolStripItemDisplayStyle.Text;
			btnV8Execute.Image = (Image)resources.GetObject("btnV8Execute.Image");
			btnV8Execute.ImageTransparentColor = Color.Magenta;
			btnV8Execute.Margin = new Padding(5, 1, 5, 2);
			btnV8Execute.Name = "btnV8Execute";
			btnV8Execute.Padding = new Padding(5, 0, 5, 0);
			btnV8Execute.RightToLeft = RightToLeft.No;
			btnV8Execute.Size = new Size(100, 22);
			btnV8Execute.Text = "Execute";
			btnV8Execute.Click += btnV8Execute_Click;
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
			// ScriptEditor
			// 
			AutoScaleMode = AutoScaleMode.None;
			CanResize = true;
			ClientSize = new Size(790, 419);
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
		}

		#endregion

		private RoslynEdit roslynEdit1;
		private ToolStrip toolStrip1;
		private ToolStripButton btnFont;
		private ToolStripButton btnV8Execute;
	}
}