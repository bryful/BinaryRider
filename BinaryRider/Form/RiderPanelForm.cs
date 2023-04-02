using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRider
{
	public partial class RiderPanelForm : Form
	{
		public int BarHeight { get; set; } = 20;
		public Color BarColor = SystemColors.ControlDark;
		private Rectangle TopMostRect = new Rectangle(0, 0, 0, 0);
		private Rectangle HideRect = new Rectangle(0, 0, 0, 0);
		private StringFormat m_Format = new StringFormat();
		private bool m_CanResize = false;
		public bool CanResize
		{
			get { return m_CanResize; }
			set { m_CanResize = value; }
		}

		// *************************************************************
		public new bool TopMost
		{
			get { return base.TopMost; }
			set
			{
				base.TopMost = value;
				this.Invalidate();
			}
		}
		// *************************************************************
		public RiderPanelForm()
		{
			this.FormBorderStyle = FormBorderStyle.None;
			m_Format.Alignment = StringAlignment.Near;
			m_Format.LineAlignment = StringAlignment.Center;
			InitializeComponent();
			ChkSize();
			this.SetStyle(
				ControlStyles.DoubleBuffer |
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.SupportsTransparentBackColor,
				true);
		}
		// *************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{

			using (Pen p = new Pen(ForeColor))
			using (SolidBrush sb = new SolidBrush(BackColor))
			{
				Graphics g = e.Graphics;
				Rectangle r = this.ClientRectangle;
				sb.Color = BackColor;
				g.FillRectangle(sb, r);
				r = new Rectangle(0, 0, this.Width, BarHeight);
				sb.Color = BarColor;
				g.FillRectangle(sb, r);
				// **: TopMost
				p.Color = ForeColor;
				g.DrawRectangle(p, TopMostRect);
				if (this.TopMost == true)
				{
					r = new Rectangle(TopMostRect.Left + 2, TopMostRect.Top + 2, TopMostRect.Width - 3, TopMostRect.Height - 3);
					sb.Color = ForeColor;
					g.FillRectangle(sb, r);
				}
				// Text
				int l = TopMostRect.Left + 2 + TopMostRect.Width + 3;
				int ww = this.Width - l*2;
				r = new Rectangle(l, 0, ww, BarHeight);
				sb.Color = ForeColor;

				g.DrawString(this.Text, this.Font,sb,r,m_Format);


				// Hide
				p.Color = ForeColor;
				g.DrawRectangle(p, HideRect);
				g.DrawLine(p,
					HideRect.Left, HideRect.Top,
					HideRect.Right, HideRect.Bottom
					);
				g.DrawLine(p,
					HideRect.Left, HideRect.Bottom,
					HideRect.Right, HideRect.Top
					);

				r = new Rectangle(0,0,this.Width-1,this.Height-1);
				p.Color = BarColor;
				g.DrawRectangle(p, r);
			}
		}
		// *************************************************************
		private void ChkSize()
		{
			int ww = 4;
			int h = BarHeight - ww * 2;
			TopMostRect = new Rectangle(5, ww, h, h);
			HideRect = new Rectangle(this.Width - (5 + h), ww, h, h);
		}
		protected override void OnResize(EventArgs e)
		{
			ChkSize();
			this.Refresh();
			base.OnResize(e);
		}
		// *************************************************************
		private bool InPoint(MouseEventArgs e, Rectangle rct)
		{
			return ((e.X >= rct.Left) && (e.X < rct.Right) && (e.Y >= rct.Top) && (e.Y < rct.Bottom));
		}
		// *************************************************************
		private Point m_mdp = new Point(0, 0);
		private bool m_md = false;
		private bool m_mdReSize = false;
		private Size m_mdSize = new Size(0, 0);
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				if (InPoint(e, TopMostRect))
				{
					this.TopMost = !this.TopMost;
					this.Invalidate();
				}
				else if (InPoint(e, HideRect))
				{
					this.Hide();
				}
				else
				{
					m_mdp = new Point(e.X, e.Y);
					if ((m_CanResize)&&( (e.X>(this.Width-20))&& (e.Y > (this.Height - 20))))
					{
						m_mdReSize = true;
						m_mdSize = new Size(this.Width,this.Height);
					}
					else
					{
						m_md = true;

					}
				}
			}
			else
			{
				base.OnMouseDown(e);
			}
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				if (m_md)
				{
					this.Left += e.X - m_mdp.X;
					this.Top += e.Y - m_mdp.Y;
				}else if (m_mdReSize)
				{
					this.Width =  m_mdSize.Width + e.X - m_mdp.X;
					this.Height =  m_mdSize.Height + e.Y - m_mdp.Y;
				}
			}
			else
			{
				base.OnMouseMove(e);
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_md == true)
			{
				m_md = false;
			}else if(m_mdReSize==true)
			{
				m_mdReSize = false;
			}
			base.OnMouseUp(e);
		}
	}
}
