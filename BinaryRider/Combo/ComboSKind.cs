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
	public enum SKind
	{
		None = 0,
		Ssbyte = 10,
		Sbyte = 11,
		Sshort = 20,
		Sushort = 21,
		Sint = 40,
		Suint = 41,
		Slong = 80,
		Sulong = 81,
		SStrShiftJIS = 90,
		SStrUtf8 = 91
	};
	public class SKindChangedEventArgs : EventArgs
	{
		public SKind SKind = SKind.None;
		public SKindChangedEventArgs(SKind sk)
		{
			SKind = sk;
		}
	}
	public partial class ComboSKind : ComboBox
	{
		//TimeEventArgs型のオブジェクトを返すようにする
		public delegate void SKindChangedEventHandler(object sender, SKindChangedEventArgs e);

		//イベントデリゲートの宣言
		public event SKindChangedEventHandler? SKindChanged;

		protected virtual void OnSKindChanged(SKindChangedEventArgs e)
		{
			if (SKindChanged != null)
			{
				SKindChanged(this, e);
			}
		}
		private SKind[] SKindTbl = new SKind[] 
		{
			SKind.None,
			SKind.Ssbyte,
			SKind.Sbyte,
			SKind.Sshort,
			SKind.Sushort,
			SKind.Sint,
			SKind.Suint,
			SKind.Slong,
			SKind.Sulong,
			SKind.SStrShiftJIS,
			SKind.SStrUtf8

		};
		private string[] SKindNameTbl = new string[]
		{
			"None",
			"sbyte",
			"byte",
			"short",
			"ushort",
			"int",
			"uint",
			"long",
			"ulong",
			"StrShiftJIS",
			"StrUtf8"

		};
		private SKind m_SKind = SKind.None;
		public SKind SKind
		{
			get
			{
				int sel = base.SelectedIndex;
				if (this.Items.Count > Enum.GetNames(typeof(SKind)).Length) { Init(); }
				RefFLag = true;
				base.SelectedIndex = sel;
				RefFLag = false;
				return m_SKind;
			}
			set
			{
				int sel = base.SelectedIndex;
				if (this.Items.Count > Enum.GetNames(typeof(SKind)).Length) { Init(); }
				RefFLag = true;
				base.SelectedIndex = sel;
				RefFLag = false;
				int v = FromSKind(value);
				bool b = (base.SelectedIndex == v);
				m_SKind = value;
				base.SelectedIndex = v;
				if (b) OnSKindChanged(new SKindChangedEventArgs(m_SKind));
			}
		}
		private int FromSKind(SKind value)
		{
			int ret = 0;
			switch (value)
			{
				case SKind.None: ret = 1; break;
				case SKind.Ssbyte: ret = 1; break;
				case SKind.Sbyte: ret = 2; break;

				case SKind.Sshort: ret = 3; break;
				case SKind.Sushort: ret = 4; break;
				case SKind.Sint: ret = 5; break;
				case SKind.Suint: ret = 6; break;
				case SKind.Slong: ret = 7; break;
				case SKind.Sulong: ret = 8; break;
				case SKind.SStrShiftJIS: ret = 9; break;
				case SKind.SStrUtf8: ret = 10; break;
			}
			return ret;
		}
		public new int SelectedIndex
		{
			get { return base.SelectedIndex;}
			set { }
		}
		public ComboSKind()
		{
			this.Items.Clear();
			InitializeComponent();
			Init();
		}

		public void Init()
		{
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Items.Clear();
			this.Items.AddRange(SKindNameTbl);
			RefFLag = true;
			this.SelectedIndex = 2;
			RefFLag = false;
		}
		private bool RefFLag = false;
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			if(RefFLag) return;
			m_SKind = SKindTbl[base.SelectedIndex];
			OnSKindChanged(new SKindChangedEventArgs(m_SKind));
		}
	}
}
