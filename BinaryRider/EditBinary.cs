using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRider
{
	public partial class EditBinary : Control
	{
		private bool DrawFlag = true;
		public BAdressH BAdressHor { get; set; }= new BAdressH();
		public BAdressV BAdressVur { get; set; } = new BAdressV();
		public BSheet BinSheet { get; set; } = new BSheet();

		private VScrollBar vsbar = new VScrollBar();

		public BSelection Selection { get; set; } = new BSelection();
		public BSize BSz = new BSize();
		public BDisp BDp = new BDisp();

		// *************************************************************
		private Color m_Gay = Color.DimGray;
		private Color m_ColorSelect = Color.Gray;
		// *************************************************************
		public new Font Font 
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				if(BSz != null)
				{
					BSz.GetSizeFromFont();
					ChkSize();
				}
			} 
		}
		// *************************************************************
		public void ChkSize()
		{
			BDp.ChkSize();
			if (BAdressHor != null) BAdressHor.ChkSize();
			if (BAdressVur != null) BAdressVur.ChkSize();
			if (BinSheet != null) BinSheet.ChkSize();

			vsbar.Location = new Point(this.Width - vsbar.Width, 0);
			vsbar.Size = new Size(vsbar.Width, this.Height);
			vsbar.Maximum = BDp.MaxY;
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
				if((m_DataFile != null)&&(BinSheet !=null))
				{
					BinSheet.SetDataFile(m_DataFile);
					m_DataFile.OpenedFile += (sender, e) =>
					{
						ChkSize();
						vsbar.Maximum = BDp.MaxY;
						vsbar.Value = BDp.Y;
						DrawOffScr();
						this.Invalidate();
					};
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
			get{ return BDp.DispStartAdress; }
		}
		public int DispByteSize
		{
			get {return BDp.DispByteSize;}
		}

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
			BSz.SetEditBinary(this);
			BDp.SetEditBinary(this);
			BAdressHor.SetEditBinary(this);
			BAdressVur.SetEditBinary(this);
			BinSheet.SetEditBinary(this);
			BSz.GetSizeFromFont();

			vsbar.Name = "vsbar";
			vsbar.Location = new Point(this.Width - vsbar.Width, 0);
			vsbar.Size = new Size(vsbar.Width, this.Height);

			this.Controls.Add(vsbar);
			ChkSize();
			vsbar.Maximum = BDp.MaxY;
			vsbar.Value = BDp.Y;

			vsbar.ValueChanged += (sender, e) =>
			{
				if (BDp.Y != vsbar.Value)
				{
					BDp.Y = vsbar.Value;
					if (BAdressVur != null) BAdressVur.DrawOffScr();
					if (BinSheet != null) BinSheet.DrawOffScr();
					this.Refresh();
				}
			};
			DrawFlag = true;
			this.Refresh();
		}
		// *************************************************************
		private void DrawOffScr()
		{
			if (BAdressHor != null) BAdressHor.DrawOffScr();
			if (BAdressVur != null) BAdressVur.DrawOffScr();
			if (BinSheet != null) BinSheet.DrawOffScr();
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
				if (BAdressHor != null) BAdressHor.Draw(g);
				if (BAdressVur != null) BAdressVur.Draw(g);
				if (BinSheet != null) BinSheet.Draw(g);
			}
		}
		// *************************************************************
		
		private BSheet.MouseDownStatus?  m_MDStat = null;
		private Point m_MDPoint = new Point();
		private int m_Start = 0;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (BinSheet != null)
			{
				BSheet.MouseDownStatus stat = BinSheet.MousePosStatus(e);
				if(stat.Down==true)
				{
					m_MDStat = stat;
					Selection.Start = stat.Adress;
					Selection.Length = 1;
					BinSheet.DrawOffScr();
					this.Invalidate();
				}
			}
			//base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(m_MDStat !=null)
			{
				if (BinSheet != null)
				{
					BSheet.MouseDownStatus stat = BinSheet.MousePosStatus(e);
					if (stat.Down == true)
					{
						if (m_MDStat.IsByte == stat.IsByte)
						{
							Selection.SetStartLast(m_MDStat.Adress, stat.Adress);
							BinSheet.DrawOffScr();
							this.Invalidate();
						}
					}
				}
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_MDStat != null)
			{
				if (BinSheet != null)
				{
					m_MDStat = null;
					BinSheet.DrawOffScr();
					this.Refresh();
				}
			}
		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
		}
		// *************************************************************
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			int x = e.Delta/120;

			BDp.Y += x * BSz.LineHeight;
			vsbar.Value = BDp.Y;
			if(BinSheet!=null) BinSheet.DrawOffScr();
			if (BAdressVur != null) BAdressVur.DrawOffScr();
			Refresh();
		}
		// *************************************************************
		protected override void OnResize(EventArgs e)
		{
			ChkSize();
		}
		// *************************************************************
		public bool Jump(int adr,int len =1)
		{
			if(m_DataFile==null) return false;
			if (adr < 0) adr = 0;
			else if (adr >= m_DataFile.ByteSize) adr = m_DataFile.ByteSize - 1;
			if (adr < BDp.DispStartAdress) return false;
			Selection.Start = adr;
			Selection.Length = len;

			int y = ((adr - BDp.DispStartAdress) / BDisp.HexC);

			int ds = BDp.Y * BDisp.HexC;
			int de = ds + (BinSheet.Size.Height / BSz.LineHeight) * BDisp.HexC;
			if((adr<ds)||(adr>=de))
			{
				BDp.Y = (adr / BDisp.HexC) * BSz.LineHeight;
				if(vsbar.Value != BDp.Y) { vsbar.Value = BDp.Y; }
			}
			if (BinSheet !=null) { BinSheet.DrawOffScr(); }
			if (BAdressVur != null) { BAdressVur.DrawOffScr(); }

			this.Invalidate();
			return true;
		}
		public bool JumpTop()
		{
			int adr = BDp.DispStartAdress;
			return Jump(adr, 1);
		}
		public bool JumpEnd()
		{
			bool ret = false;
			if (m_DataFile != null)
			{
				int adr = m_DataFile.ByteSize-1;
				if (adr < 0) adr = 0;
				ret = Jump(adr, 1);
			}
			return ret;
		}
	}
}
