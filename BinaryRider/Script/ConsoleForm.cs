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
	public partial class ConsoleForm : RiderPanelForm
	{
		public MainForm? MainForm = null;
		public void SetMainForm(MainForm mf)
		{
			this.MainForm = mf;
		}
		public ConsoleForm()
		{
			InitializeComponent();
			Clear();
		}
		public void WriteLine(string s)
		{

			s += "\r\n";
			try
			{
				tbOutput.AppendText(s);
				tbOutput.Focus();
			}
			catch
			{

			}
		}
		public void Write(String s)
		{
			try
			{
				tbOutput.AppendText(s);
				tbOutput.Focus();
			}
			catch { }
		}
		public void Clear()
		{
			tbOutput.Text = "";
			tbOutput.Focus();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void btnHide_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

	}
}
