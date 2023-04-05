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
	public partial class MainForm : RiderPanelForm
	{
		private string m_FileName = "";
		public string FileName
		{
			get { return m_FileName; }
			set
			{
				m_FileName = value;
				if (m_FileName != "")
				{
					windowMenu.Text = Path.GetFileName(m_FileName);
				}
				else
				{
					windowMenu.Text = "Window";
				}
			}
		}
		public Root Root = new Root();
		public ConsoleForm? ConsoleForm = null;
		public ScriptEditor? Editor = null;
		public CustomRoslynHost? ScriptHost = null;
		public JumpPanel? JumpPanel = null;
		public FindDialog? FindDialog = null;
		public StructView? StructView = null;
		// **********************************************************************
		public class TargetRiderEventArgs : EventArgs
		{
			public RiderForm? Rider = null;
			public TargetRiderEventArgs(RiderForm r)
			{
				Rider = r;
			}
			public Point Point { get; }
		}
		//TimeEventArgs型のオブジェクトを返すようにする
		public delegate void TargetRiderEventHandler(object sender, TargetRiderEventArgs e);

		//イベントデリゲートの宣言
		public event TargetRiderEventHandler? TargetRider;

		protected virtual void OnTargetRider(TargetRiderEventArgs e)
		{
			if (TargetRider != null)
			{
				TargetRider(this, e);
			}
		}
		// *********************************************************************
		public delegate void SelChangedEventHandler(object sender, SelChangedEventArgs e);

		//イベントデリゲートの宣言
		public event SelChangedEventHandler? SelChanged;

		protected virtual void OnSelChanged(SelChangedEventArgs e)
		{
			if (SelChanged != null)
			{
				SelChanged(this, e);
			}
		}
		// *********************************************************************
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

			this.Size = new Size(400, 30);

			mainFormMaxSizeMenu.Click += (center, e) => { MainFormMaxSize(); };
			MainFormMaxSize();
			newMenu.Click += (center, e) => { AddForm(); };
			openMenu.Click += (center, e) => { OpenForm(); };
			quitMenu.Click += (center, e) => { Application.Exit(); };
			scriptEditorMenu.Click += (center, e) => { ShowScriptEditor(); };
			consoleMenu.Click += (center, e) => { ShowConsoleForm(); };
			jumpMenu.Click += (center, e) => { ShowJumpPanel(); };
			findMenu.Click += (center, e) => { ShowFindDialog(); };
			structViewMenu.Click += (center, e) => { ShowStructView(); };
			windowMenu.Click += (center, e) => { MakeWindowMenu(); };
			//AddForm();
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
			form.TopMost = false;
			form.CharCodeMode = this.CharCodeMode;
			form.WinClose += Form_WinClose1;
			m_ActiveRider = form;
			form.Activated += (senter, e) =>
			{
				if (senter != null)
				{
					if (senter is RiderForm)
					{
						m_ActiveRider = (RiderForm)senter;
						this.FileName = m_ActiveRider.BDataFile.FileName;
						OnTargetRider(new TargetRiderEventArgs(m_ActiveRider));
						OnSelChanged(new SelChangedEventArgs(m_ActiveRider.Selection));
					}
				}
			};
			Forms.Add(form);
			form.Show(this);
			form.Activate();
			return form;
		}
		// *********************************************************************
		public void OpenForm(string p)
		{
			RiderForm rf = AddForm();
			rf.OpenFile(p);
		}
		public void OpenForm()
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				if (m_FileName != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(m_FileName);
				}
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					OpenForm(dlg.FileName);
				}
			}
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
				m_ActiveRider = null;
			}
			if (Forms.Count > 0)
			{
				Forms[0].Activate();
				this.ShowInTaskbar = false;
			}
			else
			{
				if (this.Visible == false)
				{
					Application.Exit();
				}
				else
				{
					this.Activate();
					this.ShowInTaskbar = true;
				}
			}
		}
		// *********************************************************************
		protected override void OnVisibleChanged(EventArgs e)
		{
			if (Forms.Count == 0)
			{
				if (this.Visible == false)
				{
					Application.Exit();
				}
			}
			base.OnVisibleChanged(e);
		}
		// *********************************************************************
		public RiderForm? Form(int idx)
		{
			RiderForm? ret = null;
			if ((idx >= 0) && (idx < Forms.Count))
			{
				ret = Forms[idx];
			}
			return ret;
		}
		public int IndexOf(RiderForm rf)
		{
			return Forms.IndexOf(rf);
		}
		public int IndexOf(string name)
		{
			int ret = -1;
			for (int i = 0; i < Forms.Count; i++)
			{
				if (Forms[i].Name == name)
				{
					ret = i;
					break;
				}
			}
			return ret;
		}
		// *********************************************************************
		public bool ShowMainForm()
		{
			if (this.Visible == false)
			{
				this.Visible = true;
			}
			this.Activate();
			return true;
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
		// *********************************************************************
		public bool ShowJumpPanel()
		{
			if (JumpPanel == null)
			{
				JumpPanel = new JumpPanel();
				JumpPanel.SetMainForm(this);
				JumpPanel.Show(this);
			}
			if (JumpPanel != null)
			{
				if (JumpPanel.Visible == false)
				{
					JumpPanel.Visible = true;
				}
				JumpPanel.Activate();
			}
			return true;
		}
		// *********************************************************************
		public bool ShowFindDialog()
		{
			if (FindDialog == null)
			{
				FindDialog = new FindDialog();
				FindDialog.SetMainForm(this);
				FindDialog.Show(this);
			}
			if (FindDialog != null)
			{
				if (FindDialog.Visible == false)
				{
					FindDialog.Visible = true;
				}
				FindDialog.Activate();
			}
			return true;
		}
		// *********************************************************************
		public bool ShowStructView()
		{
			if (StructView == null)
			{
				StructView = new StructView();
				StructView.SetMainForm(this);
				StructView.Show(this);
			}
			if (StructView != null)
			{
				if (StructView.Visible == false)
				{
					StructView.Visible = true;
				}
				StructView.Activate();
			}
			return true;
		}
		// *********************************************************************
		public void MakeWindowMenu()
		{
			if (windowMenu.DropDownItems.Count > 0)
			{
				windowMenu.DropDownItems.Clear();
			}
			if (Forms.Count<= 0) return;
			List<ToolStripMenuItem> ms = new List<ToolStripMenuItem>();
			foreach (RiderForm rf in Forms)
			{
				ToolStripMenuItem m = new ToolStripMenuItem();
				m.Text = rf.Text;
				m.Checked = rf.IsActive;
				m.Tag = (Object)rf;
				m.Click += (sender, e) =>
				{
					ToolStripMenuItem? m = (ToolStripMenuItem?)sender;
					if (m != null)
					{
						RiderForm? rr = (RiderForm?)m.Tag;
						if (rr != null) rr.Activate();
					}
					windowMenu.DropDownItems.Clear();
				};
				ms.Add(m);
			}
			windowMenu.DropDownItems.AddRange(ms.ToArray());
		}
		// *********************************************************************
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
				if (cap == "") cap = "Alert";
				dlg.Title = cap;
				dlg.Text = ObjToString(obj);
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
		// *****************************************************************************
		public string FormNames()
		{
			string ret = "";
			if (Forms.Count > 0)
			{
				foreach (Form form in Forms)
				{
					if (ret != "") ret += ", ";
					ret += $"\"{form.Name}\"";

				}
			}
			return ret;
		}
		// *****************************************************************************
		public void ScriptExecute(string code)
		{
			try
			{
				if (ScriptHost == null) CreateScriptHost();
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
		// ********************************************************************************
		public void MainFormMaxSize()
		{
			Screen s = Screen.FromControl(this);
			this.Location = new Point(s.WorkingArea.Left, s.WorkingArea.Top);
			this.Size = new Size(s.WorkingArea.Width, this.Height);
		}
	}
}