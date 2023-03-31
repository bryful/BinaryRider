using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using RoslynPad.Editor;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using RoslynPad.Roslyn;
using System.Collections.Immutable;
using System.Windows.Forms.Integration;
using System.IO;


namespace BinaryRider
{
	public partial class ScriptEditor : RiderPanelForm
	{
		public CustomRoslynHost? Host
		{
			get { return roslynEdit1.Host; }
		}
		public MainForm? MainForm = null;
		public void SetMainForm(MainForm mf)
		{
			this.MainForm = mf;
		}
		public ScriptEditor()
		{
			InitializeComponent();

		}


		private void btnHide_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnV8Execute_Click(object sender, EventArgs e)
		{
			if (MainForm == null) return;
			MainForm.ScriptExecute(roslynEdit1.Text);
		}
	}
}
