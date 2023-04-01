using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRider
{
	public partial class StructListBox : ListBox
	{
		private EditStructItem? m_EStructItem = null; 
		public EditStructItem? EStructItem
		{
			get { return m_EStructItem; }
			set
			{
				m_EStructItem = value;
				if(m_EStructItem !=null)
				{
					m_EStructItem.BAdd += (sender, e) =>
					{
						AddItem(m_EStructItem.StructItem);
					};
				}
			}
		}
		
		// ***********************************************************************
		private byte[]? _data = null;
		public void SetData(byte[]? b) { _data = b; Rescan(); }
		private long _StartAdr = 0;
		public long StartAdr
		{
			get { return _StartAdr;}
			set 
			{
				long aa = value;
				if(_data==null)
				{
					aa = 0;
				}
				else
				{
					if (aa >= _data.Length)
					{
						aa = _data.Length - 1;
					}
					if (aa < 0) aa = 0;
				}
				if(_StartAdr !=aa)
				{
					_StartAdr = aa;
					Rescan();
				}
			}
		}
		private StringFormat _format = new StringFormat();
		List<StructItem> _items = new List<StructItem>();
		public StructListBox()
		{
			InitializeComponent();
			this.DrawMode = DrawMode.OwnerDrawFixed;
			_format.Alignment = StringAlignment.Center;
			_format.LineAlignment = StringAlignment.Center;
			Clear();
		}
		public void AddItem(StructItem item)
		{
			if (_items.Count != this.Items.Count)
			{
				this.Items.Clear();
				if (_items.Count > 0)
				{
					this.Items.AddRange(_items.ToArray());
				}
			}

			item.Adress = _items.Count + 1;
			item.RAdress = 0;
			if (_items.Count>0)
			{
				item.RAdress = _items[_items.Count-1].RAdress
					+ _items[_items.Count - 1].ByteLength;
			}
			_items.Add(item);
			Items.Add(item);
			Rescan();
		}
		public void Rescan()
		{
			if (_items.Count != this.Items.Count)
			{
				this.Items.Clear();
				if (_items.Count > 0)
				{
					this.Items.AddRange(_items.ToArray());
				}
			}
			if (_items.Count > 0)
			{
				for(int i=0; i< _items.Count; i++)
				{

					_items[i].Index = i;
					_items[i].Adress = i;
					if(i==0)
					{
						_items[i].RAdress = 0;
					}
					else
					{
						_items[i].RAdress =
							_items[i - 1].RAdress +
							_items[i - 1].ByteLength;
					}
					if(_data!=null)
					{
						_items[i].Adress = _StartAdr + _items[i].RAdress;
						for (int j=0; j< _items[i].ByteLength;j++)
						{
							long adr = _StartAdr + _items[i].RAdress + (long)j;
							if((adr>=0)&&(adr<_data.Length))
							{
								_items[i].Bytes[j] = _data[adr];
							}
						}
					}

				}
			}
			this.Invalidate();
		}
		public void Clear()
		{
			_items.Clear();
			this.Items.Clear();
		}
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;
			e.DrawBackground();
			if ((e.Index >=0)&&(e.Index < _items.Count))
			{
				Rectangle bb = e.Bounds;
				StructItem si = _items[e.Index];
				Debug.WriteLine(si.ToString());
				using (SolidBrush sb = new SolidBrush(ForeColor))
				{
					_format.Alignment = StringAlignment.Far;

					Rectangle r = new Rectangle(bb.Left, bb.Top, 20, bb.Height);
					g.DrawString($"{si.Index}", e.Font, sb, r, _format);

					r = new Rectangle(r.Left + r.Width, r.Top, 40, r.Height);
					g.DrawString($"{si.Adress:X4}", e.Font, sb, r, _format);

					r = new Rectangle(r.Left + r.Width, r.Top, 40, r.Height);
					g.DrawString($"{si.RAdress:X2}", e.Font, sb, r, _format);

					r = new Rectangle(r.Left + r.Width, r.Top, 20, r.Height);
					g.DrawString($"{si.ByteLength}", e.Font, sb, r, _format);

					r = new Rectangle(r.Left + r.Width, r.Top, 10, r.Height);
					string be = "B";
					if (si.IsBigEndian) be = "B"; else be = "L";
					g.DrawString($"{be}", e.Font, sb, r, _format);

					_format.Alignment = StringAlignment.Near;
					r = new Rectangle(r.Left + r.Width, r.Top, 200, r.Height);
					g.DrawString($"{si.ValueStr()}", e.Font, sb, r, _format);
					r = new Rectangle(r.Left + r.Width, r.Top, 200, r.Height);
					g.DrawString($"{si.Comment}", e.Font, sb, r, _format);
				}
			}
			e.DrawFocusRectangle();
			
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			if(m_EStructItem != null)
			{
				if((this.SelectedIndex>=0)&&(_items.Count>0))
				{
					m_EStructItem.StructItem = _items[this.SelectedIndex];
				}
			}
		}
	}
}
