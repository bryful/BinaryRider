﻿using System;
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
	public partial class AlertForm : Form
	{

		public new string Text
		{
			get { return textBox1.Text; }
			set
			{ 
				textBox1.Text =value;
				textBox1.SelectionLength = 0;
			}
		}
		
		public string Title
		{
			get { return base.Text; }
			set { base.Text = value; }
		}

		public AlertForm()
		{
			InitializeComponent();
		}
	}
}
