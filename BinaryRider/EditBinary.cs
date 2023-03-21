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
		public BAdrH? BAdrH { get; set; }=null;
		public BAdrV? BAdrV { get; set; } = null;
		public BBin? BBin { get; set; } = null;
		// *************************************************************
		private Color m_Gay = Color.DimGray;
		// *************************************************************
		private string m_FileName = "";
		public string FileName { get { return m_FileName; } }
		// *************************************************************
		private byte[] m_Data = new byte[0];
		public byte[] Data { get { return m_Data; } }
		public int ByteSize {get { return m_Data.Length; }}
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
			BAdrH = new BAdrH(this);
			BAdrV = new BAdrV(this);
			BBin = new BBin(this);
			DrawFlag = true;
			this.Refresh();
		}
		// *************************************************************
		public bool LoadFile(string fn)
		{
			bool ret = false;
			if (File.Exists(fn) == false) return ret;
			try
			{
				m_Data = new byte[0];
				m_FileName = "";
				using (FileStream fs = new FileStream(fn, FileMode.Open, FileAccess.Read))
				{
					byte[] bs = new byte[fs.Length];
					int sz = fs.Read(bs, 0, bs.Length);
					if (sz == fs.Length)
					{
						m_Data = bs;
						m_FileName = fn;
						DrawOffScr();
						this.Invalidate();
						ret = true;
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// *************************************************************
		private void DrawOffScr()
		{
			if (BAdrH != null) BAdrH.DrawOffScr();
			if (BAdrV != null) BAdrV.DrawOffScr();
			if (BBin != null) BBin.DrawOffScr();
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
				if (BBin != null) BBin.Draw(g);
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
	}
}
