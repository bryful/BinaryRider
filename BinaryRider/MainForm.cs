namespace BinaryRider
{
	public partial class MainForm : Form
	{
		private int Id_Counter = 0;
		public List<RiderForm> Forms = new List<RiderForm>();
		public MainForm()
		{
			InitializeComponent();
			this.Visible = false;
			this.Opacity = 0;
			this.Size = new Size(0, 0);
			AddForm();
		}
		public CharCodeMode CharCodeMode { get; set; } = CharCodeMode.UTF8;
		// *********************************************************************
		public void AddForm()
		{
			RiderForm form = new RiderForm();
			form.MainForm = this;
			form.Id = Id_Counter;
			Id_Counter++;
			form.Text = $"BinaryRider{Id_Counter}";
			form.CharCodeMode = this.CharCodeMode;
			form.WinClose += Form_WinClose1;
			Forms.Add(form);
			form.Show();
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
	}
}