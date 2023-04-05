using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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
					m_EStructItem.BApply += (sender, e) =>
					{
						ApplyItem(m_EStructItem.StructItem);
					};
					m_EStructItem.BUp += (sender, e) =>
					{
						ItemUp();
					};
					m_EStructItem.BDown += (sender, e) =>
					{
						ItemDown();
					};
					m_EStructItem.BDelete += (sender, e) =>
					{
						ItemDelete();
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
			if(item.Kind == SKind.None) { item.Kind = SKind.Sbyte; }
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
		public void ApplyItem(StructItem item)
		{
			int idx = this.SelectedIndex;
			if (idx < 0) return;
			if (item.Kind == SKind.None) { item.Kind = SKind.Sbyte; }

			_items[idx].Kind = item.Kind;
			_items[idx].ByteLength = item.ByteLength;
			_items[idx].IsBigEndian = item.IsBigEndian;
			_items[idx].Comment = item.Comment;


			Items[idx] = _items[idx];
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
					this.Items[i] = _items[i];
				}
			}
			this.Invalidate();
		}
		public void ItemUp()
		{
			int idx = this.SelectedIndex;
			if (idx < 0) return;
			if (idx>=1)
			{
				if(Swap(idx, idx-1))
				{
					Rescan();
					this.SelectedIndex = idx-1;
				}

			}
		}
		public void ItemDown()
		{
			int idx = this.SelectedIndex;
			if (idx < 0) return;
			if (idx <_items.Count-1)
			{
				if (Swap(idx, idx + 1))
				{
					Rescan();
					this.SelectedIndex = idx + 1;
				}

			}
		}
		public bool Swap(int a, int b)
		{
			bool ret = false;
			if(a==b) return ret;
			if ((a < 0) || (a >= _items.Count)) return ret;
			if ((b < 0) || (b >= _items.Count)) return ret;
			SKind sk = _items[a].Kind;
			long bs = _items[a].ByteLength;
			bool bb = _items[a].IsBigEndian;
			string cm = _items[a].Comment;
			_items[a].Kind = _items[b].Kind;
			_items[a].ByteLength = _items[b].ByteLength;
			_items[a].IsBigEndian = _items[b].IsBigEndian;
			_items[a].Comment = _items[b].Comment;
			_items[b].Kind = sk;
			_items[b].ByteLength = bs;
			_items[b].IsBigEndian = bb;
			_items[b].Comment = cm;
			this.Items[a] = _items[a];
			this.Items[b] = _items[b];
			ret =true;
			return ret;
		}
		public void ItemDelete()
		{
			int idx = this.SelectedIndex;
			if((idx>=0)&&(idx<_items.Count))
			{
				_items.RemoveAt(idx);
				this.Items.RemoveAt(idx);
				Rescan();
			}
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
				Font? ff = e.Font;
				if (ff == null) ff = this.Font;
				Rectangle bb = e.Bounds;
				StructItem si = _items[e.Index];
				Debug.WriteLine(si.ToString());
				using (SolidBrush sb = new SolidBrush(ForeColor))
				{
					_format.Alignment = StringAlignment.Far;

					Rectangle r = new Rectangle(bb.Left, bb.Top, 20, bb.Height);
					g.DrawString($"{si.Index}", ff, sb, r, _format);

					r = new Rectangle(r.Left + r.Width, r.Top, 80, r.Height);
					g.DrawString($"{si.Adress:X4}", ff, sb, r, _format);

					r = new Rectangle(r.Left + r.Width, r.Top, 40, r.Height);
					g.DrawString($"{si.RAdress:X2}", ff, sb, r, _format);

					r = new Rectangle(r.Left + r.Width, r.Top, 20, r.Height);
					g.DrawString($"{si.ByteLength}", ff, sb, r, _format);

					r = new Rectangle(r.Left + r.Width, r.Top, 10, r.Height);
					string be = "B";
					if (si.IsBigEndian) be = "B"; else be = "L";
					g.DrawString($"{be}", ff, sb, r, _format);

					_format.Alignment = StringAlignment.Near;
					int w = this.Width - (r.Left + r.Width);

					r = new Rectangle(r.Left + r.Width, r.Top, w, r.Height);
					g.DrawString($"{si.ValueStr()}", ff, sb, r, _format);
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
		public JsonObject ToJson()
		{
			JsonObject jo = new JsonObject();

			jo.Add("Header", "StructListBox");
			JsonArray ja = new JsonArray();
			if(_items.Count>0)
			{
				foreach( StructItem item in _items)
				{
					ja.Add(item.ToJson());
				}
			}
			jo.Add("Items", ja);

			return jo;
		}
		public bool SaveJsonFile(string path)
		{
			bool ret = false;
			try
			{
				JsonObject jo = ToJson();
				File.WriteAllText(path, jo.ToJsonString());
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public bool FromJson(JsonObject? jo)
		{
			bool ret = false;
			Clear();
			if (jo == null) return ret;
			string key = "Items";
			if (jo.ContainsKey(key))
			{
				JsonArray? ja = jo[key].AsArray();
				if(ja!= null )
				{
					if( ja.Count>0 )
					{
						foreach( JsonObject? item in ja)
						{
							if (item == null) continue;
							StructItem si = new StructItem();
							if(si.FromJson(item)==true )
							{
								AddItem(si);
							}
						}
					}
				}
			}

			return ret;
		}
		public bool Load(string p)
		{
			bool ret = false;

			try
			{
				if (File.Exists(p) == true)
				{
					string str = File.ReadAllText(p);
					if (str != "")
					{
						var doc = JsonNode.Parse(str);
						if (doc != null)
						{
							FromJson((JsonObject)doc);
						}
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
	}
}
