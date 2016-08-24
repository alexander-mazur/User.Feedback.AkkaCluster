using System;
using System.Windows.Forms;

using User.Feedback.Client.BusinessObjects;

namespace User.Feedback.Client.Views.Main
{
    public partial class MainForm : Form, IMainForm
    {
        public MainFormPresenter Presenter { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Presenter = new MainFormPresenter(this);
        }

        public event EventHandler ShowSendMessageForm
        {
            add { sendMessageButton.Click += value; }
            remove { sendMessageButton.Click += value; }
        }

        public event EventHandler ShowViewMessagesForm
        {
            add { viewMessagesButton.Click += value; }
            remove { viewMessagesButton.Click += value; }
        }
    }
}
