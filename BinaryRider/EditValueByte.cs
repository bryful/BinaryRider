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
	public partial class EditValueByte : RiderPanelForm
	{
		private bool refFlag = false;
		private byte m_Value = 0;
		private byte m_ValueOrg = 0;
		public byte Value
		{
			get { return m_Value; }
			set
			{
				m_Value = value;
				m_ValueOrg = value;
				btnOrg.Text = $"0x{m_ValueOrg:X2}";
				SetValueA(value);
			}
		}
		public EditValueByte()
		{
			InitializeComponent();
			bitEdit1.ValueChanged += (sender, e) =>
			{
				if (refFlag) return;
				m_Value = (byte)bitEdit1.Value;
				SetValueA(m_Value);
			};
			hexEdit1.ValueChanged += (sender, e) =>
			{
				if (refFlag) return;
				m_Value = (byte)hexEdit1.Value;
				SetValueA(m_Value);
			};
			numericUpDown1.ValueChanged += (sender, e) =>
			{
				if (refFlag) return;
				m_Value = (byte)numericUpDown1.Value;
				SetValueA(m_Value);
			};
			btnShr.Click += (sender, e) =>
			{
				m_Value >>= 1;
				SetValueA(m_Value);
			};
			btnShl.Click += (sender, e) =>
			{
				m_Value <<= 1;
				SetValueA(m_Value);
			};
			btnOK.Click += (sender, e) =>
			{
				this.DialogResult = DialogResult.OK;
			};
			btnOrg.Click += (sender, e) =>
			{
				m_Value = m_ValueOrg;
				SetValueA(m_Value);
			};
		}
		private void SetValueA(byte b)
		{
			refFlag = true;
			if (bitEdit1.Value != (ulong)b) bitEdit1.Value = (ulong)b;
			if (hexEdit1.Value != (long)b) hexEdit1.Value = (long)b;
			if (numericUpDown1.Value != (decimal)b) numericUpDown1.Value = (decimal)b;
			byte[] bb = new byte[1];
			bb[0] = b;
			textBox1.Text = Encoding.UTF8.GetString(bb);
			refFlag = false;
		}
	}
}
