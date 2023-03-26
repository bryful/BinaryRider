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
using Microsoft.CodeAnalysis.CSharp.Scripting.Hosting;
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
	public partial class MainForm : Form
	{
		public ConsoleForm? ConsoleForm = null;
		public Root Root = new Root();

		public ScriptEditor? Editor = null;
		public CustomRoslynHost? ScriptHost = null;

		private RiderForm? m_ActiveRider = null;
		public RiderForm? ActiveRider { get { return m_ActiveRider; } }
		private int Id_Counter = 0;
		public List<RiderForm> Forms = new List<RiderForm>();
		public MainForm()
		// *********************************************************************
		{
			Root.MainForm = this;
			CreateScriptHost();

			InitializeComponent();
			this.Visible = false;
			this.Opacity = 0;
			this.Size = new Size(0, 0);
			AddForm();
		}
		public CharCodeMode CharCodeMode { get; set; } = CharCodeMode.UTF8;
		// *********************************************************************
		public RiderForm AddForm()
		{
			RiderForm form = new RiderForm();
			form.MainForm = this;
			form.Id = Id_Counter;
			Id_Counter++;
			form.Text = $"BinaryRider{Id_Counter}";
			form.Name = $"BinaryRider{Id_Counter}";
			form.CharCodeMode = this.CharCodeMode;
			form.WinClose += Form_WinClose1;
			form.Activated += (senter, e) =>
			{
				if(senter != null)
				{
					if (senter is RiderForm)
					{
						m_ActiveRider = (RiderForm)senter;
					}
				}
			};
			Forms.Add(form);
			form.Show();
			return form;
		}
		// *********************************************************************
		public void OpenForm(string p)
		{
			RiderForm rf = AddForm();
			rf.OpenFile(p);
		}
		// *********************************************************************
		private void Form_WinClose1(object sender, RiderForm.WinCloseEventArgs e)
		{
			int id = e.Id;
			if (Forms.Count > 0)
			{
				for (int i = Forms.Count - 1; i >= 0; i--)
				{
					if (Forms[i].Id == id)
					{
						Forms.RemoveAt(i);
					}
				}
			}
			if (Forms.Count <= 0)
			{
				Application.Exit();
			}
		}
		// *********************************************************************
		public bool ShowConsoleForm()
		{
			if (ConsoleForm == null)
			{
				ConsoleForm = new ConsoleForm();
				ConsoleForm.SetMainForm(this);
				ConsoleForm.Show(this);
			}
			if (ConsoleForm.Visible == false)
			{
				ConsoleForm.Visible = true;
			}
			ConsoleForm.Activate();
			return true;
		}
		// *********************************************************************
		public bool ShowScriptEditor()
		{
			if (Editor == null)
			{
				Editor = new ScriptEditor();
				Editor.SetMainForm(this);
				Editor.Show(this);
			}
			if (Editor != null)
			{
				if (Editor.Visible == false)
				{
					Editor.Visible = true;
				}
				Editor.Activate();
			}
			return true;
		}
		public void WriteLine(object? o)
		{
			ShowConsoleForm();
			if (ConsoleForm != null) ConsoleForm.WriteLine(ObjToString(o));
		}
		public void Write(object? o)
		{
			ShowConsoleForm();
			if (ConsoleForm != null) ConsoleForm.Write(ObjToString(o));
		}
		public void ClearScreen()
		{
			ShowConsoleForm();
			if (ConsoleForm != null) ConsoleForm.Clear();
		}
		public void Alert(object? obj, string cap = "")
		{
			using (AlertForm dlg = new AlertForm())
			{
				dlg.Text = ObjToString(obj);
				if (cap != "") dlg.Title = cap;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
				}
			}
		}
		static public string ObjToString(object? obj)
		{
			string ret = "";
			if (obj == null)
			{
				ret = "null";
			}
			else if (obj is string)
			{
				ret = (string)obj;
			}
			else
			{
				ret = CSharpObjectFormatter.Instance.FormatObject(obj);
			}
			/*
			else if (obj is bool)
			{
				ret = obj.ToString().ToLower();
			}
			else if (obj is Array)
			{
				foreach (object o1 in (Array)obj)
				{
					if (ret != "") ret += ",";
					if (o1 == null)
					{
						ret += "null";
					}
					else
					{
						ret += ObjToString(o1);
					}
				}
				ret = "[" + ret + "]";
			}
			else
			{
				try
				{
					ret = obj.ToString();

				}
				catch (Exception ex)
				{
					ret = ex.ToString();
				}
			}
			*/
			if (ret == null) { ret = "null"; }
			return ret;
		}
		public void ScriptExecute(string code)
		{
			try
			{
				if(ScriptHost ==null) CreateScriptHost();
				if (ScriptHost == null) return;
				ScriptOptions options = ScriptOptions.Default
					.WithReferences(ScriptHost.DefaultReferences)
					.WithImports(ScriptHost.DefaultImports);

				var script = CSharpScript.Create(code, options, typeof(Root));
				script.RunAsync(this.Root);
			}
			catch (CompilationErrorException ex)
			{
				Alert(ex.Message, "コンパイルエラー");
			}
			catch (Exception ex)
			{
				Alert(ex.Message, "エラー");

			}
		}
		public void CreateScriptHost()
		{
			var roslynPadAssemblies = new[]
			{
				Assembly.Load("RoslynPad.Roslyn.Windows"),
				Assembly.Load("RoslynPad.Editor.Windows"),
				Assembly.Load("System"),
				Assembly.Load("System.IO"),
				Assembly.Load("System.Windows.Forms"),
				typeof(System.Dynamic.DynamicObject).Assembly,  // System.Code
				//typeof(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo).Assembly,  // Microsoft.CSharp
				typeof(System.Dynamic.ExpandoObject).Assembly,
				typeof(System.Data.DataTable).Assembly,
				typeof(System.Object).Assembly,
				typeof(BinaryRider.Root).Assembly,
				Assembly.GetExecutingAssembly(),
			};
			var assemblies = new[]
			{
				Assembly.Load("System.Private.CoreLib"),
				typeof(System.Dynamic.DynamicObject).Assembly,
				typeof(System.Dynamic.ExpandoObject).Assembly,
				typeof(System.Text.RegularExpressions.Regex).Assembly,
				typeof(System.Object).Assembly,
				typeof(System.Runtime.DependentHandle).Assembly,
				typeof(System.Windows.Forms.MessageBox).Assembly,
				typeof(BinaryRider.Root).Assembly,
				Assembly.GetExecutingAssembly(),


			};
			ScriptHost = new CustomRoslynHost(
				typeof(BinaryRider.Root),
				roslynPadAssemblies,
				RoslynHostReferences.NamespaceDefault.With(assemblyReferences: assemblies));

		}

	}
}