using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRider
{
	public partial class EditBinary : Control
	{
		private bool DrawFlag = true;
		public BAdressH? BAdrH { get; set; }=null;
		public BAdressV? BAdrV { get; set; } = null;
		public BSheet? BSheet { get; set; } = null;

		private VScrollBar vsbar = new VScrollBar();
		// *************************************************************
		private Color m_Gay = Color.DimGray;
		// *************************************************************
		public new Font Font 
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				if(BSize != null)
				{
					BSize.GetSizeFromFont();
					ChkSize();
				}
			} 
		}
		// *************************************************************
		public void ChkSize()
		{
			BDisp.ChkSize();
			if (BAdrH != null) BAdrH.ChkSize();
			if (BAdrV != null) BAdrV.ChkSize();
			if (BSheet != null) BSheet.ChkSize();

			vsbar.Location = new Point(this.Width - vsbar.Width, 0);
			vsbar.Size = new Size(vsbar.Width, this.Height);
			vsbar.Maximum = BDisp.MaxY;
			DrawOffScr();
			this.Invalidate();
		}
		// *************************************************************
		private BDataFile? m_DataFile = null;
		public BDataFile? DataFile
		{
			get { return m_DataFile; }
			set
			{
				m_DataFile = value;
				if((m_DataFile != null)&&(BSheet !=null))
				{
					BSheet.SetDataFile(m_DataFile);
				}
			} 
		}
		public int ByteSize
		{
			get
			{
				int ret = 0;
				if(m_DataFile != null)
				{
					ret = m_DataFile.ByteSize;
				}
				return ret;
			}
		}
		public int DispStartAdress
		{
			get{ return BDisp.DispStartAdress; }
		}
		public int DispByteSize
		{
			get {return BDisp.DispByteSize;}
		}
		public BSelection Selection = new BSelection();
		public BSize BSize = new BSize();
		public BDisp BDisp = new BDisp();
		// *************************************************************
		private StringFormat m_form = new StringFormat();
		// *************************************************************
		public EditBinary()
		{
			DrawFlag = false;

			m_form.Alignment = StringAlignment.Center;
			m_form.LineAlignment = StringAlignment.Center;
			this.Size = new Size(300, 300);

			InitializeComponent();
			this.SetStyle(
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.SupportsTransparentBackColor,
true);
			Selection.SetEditBinary(this);
			BSize.SetEditBinary(this);
			BDisp.SetEditBinary(this);
			BAdrH = new BAdressH(this);
			BAdrV = new BAdressV(this);
			BSheet = new BSheet(this);
			BSize.GetSizeFromFont();

			vsbar.Name = "vsbar";
			vsbar.Location = new Point(this.Width - vsbar.Width, 0);
			vsbar.Size = new Size(vsbar.Width, this.Height);

			this.Controls.Add(vsbar);
			ChkSize();
			vsbar.Maximum = BDisp.MaxY;
			vsbar.Value = BDisp.Y;

			vsbar.ValueChanged += (sender, e) =>
			{
				if (BDisp.Y != vsbar.Value)
				{
					BDisp.Y = vsbar.Value;
					if (BAdrV != null) BAdrV.DrawOffScr();
					if (BSheet != null) BSheet.DrawOffScr();
					this.Refresh();
				}
			};
			DrawFlag = true;
			this.Refresh();
		}
		// *************************************************************
		public bool LoadFile(string fn)
		{
			bool ret = false;
			if(m_DataFile != null)
			{
				ret = m_DataFile.LoadFile(fn);
				if (ret)
				{
					ChkSize();
					vsbar.Maximum = BDisp.MaxY;
					vsbar.Value = BDisp.Y;
					DrawOffScr();
					this.Invalidate();
				}
			}
			return ret;
		}
		// *************************************************************
		private void DrawOffScr()
		{
			if (BAdrH != null) BAdrH.DrawOffScr();
			if (BAdrV != null) BAdrV.DrawOffScr();
			if (BSheet != null) BSheet.DrawOffScr();
		}
		// *************************************************************
		protected override void OnPaint(PaintEventArgs pe)
		{
			if (DrawFlag == false) return;
			Graphics g = pe.Graphics;
			using(SolidBrush sb = new SolidBrush(BackColor))
			using (Pen p = new Pen(ForeColor))
			{
				g.Clear(BackColor);
				if (BAdrH != null) BAdrH.Draw(g);
				if (BAdrV != null) BAdrV.Draw(g);
				if (BSheet != null) BSheet.Draw(g);
			}
		}
		// *************************************************************
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
		}
		// *************************************************************
		protected override void OnResize(EventArgs e)
		{
			ChkSize();
		}
	}
}
