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
	public partial class ComboCharCode : ComboBox
	{
		public CharCodeMode CharCodeMode
		{
			get
			{
				if (this.Items.Count > Enum.GetNames(typeof(CharCodeMode)).Length) { Init(); }
				return (CharCodeMode)this.SelectedIndex;
			}
			set
			{
				Init();
				this.SelectedIndex= (int)value;
			}
		}
		
		public ComboCharCode()
		{
			this.Items.Clear();
			InitializeComponent();
			Init();

		}
		public void Init()
		{
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			string[] ims = Enum.GetNames(typeof(CharCodeMode));
			this.Items.Clear();
			this.Items.AddRange(ims);
			this.SelectedIndex = 0;
		}
		protected override void InitLayout()
		{
			Init();
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
	}
}
