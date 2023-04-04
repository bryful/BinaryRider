using Microsoft.CodeAnalysis.CSharp.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public class Root
	{
		//public ScriptEditor? Editor = null;

		public MainForm? MainForm { get; set; } = null;
		public Root()
		{
		}
		public Root(MainForm main)
		{
			MainForm = main;
		}
		private Object? m_Result = null;
		[Category("BinaryRider")]
		public Object? Result
		{
			get { return m_Result; }
		}
		[Category("BinaryRider")]
		public int FormsCount
		{
			get 
			{
				int ret = 0;
				if(MainForm!=null)
				{
					ret =MainForm.Forms.Count;	
				}
				return ret; 
			}
		}
		[Category("BinaryRider")]
		public RiderForm[] Forms
		{
			get
			{
				RiderForm[] ret = new RiderForm[0];
				if (MainForm != null)
				{
					ret = MainForm.Forms.ToArray();
				}
				return ret;
			}
		}
		[Category("BinaryRider")]
		public RiderForm? ThisForm
		{
			get
			{
				RiderForm? ret = null;
				if (MainForm != null)
				{
					ret = MainForm.ActiveRider;
				}
				return ret;
			}
		}
		public string FormNames()
		{
			string ret = "";
			if (MainForm != null)
				ret = MainForm.FormNames();
			return ret;
		}
		public void Alert(object? obj, string cap = "")
		{
			if (MainForm != null)
				MainForm.Alert(obj, cap);
		}
		public void WriteLine(object? o)
		{
			if(MainForm != null)
				MainForm.WriteLine(o);
		}
		public void Write(object? o)
		{
			if (MainForm != null)
				MainForm.Write(o);
		}
		public void ClearScreen()
		{
			if (MainForm != null)
				MainForm.ClearScreen();
		}
		public void Clr()
		{
			if (MainForm != null)
				MainForm.ClearScreen();
		}


	}
}

