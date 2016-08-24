using System;
using System.Windows.Forms;
using User.Feedback.Client.Actors;

namespace User.Feedback.Client.Views.SendMessage
{
    public partial class SendMessageForm : Form, ISendMessageForm
    {
        public SendMessageFormPresenter Presenter { get; set; }

        public SendMessageForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Presenter = new SendMessageFormPresenter(this, ClientActorSystem.Instance.UserFeedbackManager);
        }

        public string Message
        {
            get { return messageTextBox.Text; }
            set { messageTextBox.Text = value; }
        }

        public int MessagesCount => Convert.ToInt32(messagesCountNumericUpDown.Value);

        public event EventHandler MessageSent
        {
            add { sendMessageButton.Click += value; }
            remove { sendMessageButton.Click += value; }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                messageTextBox.Text = string.Empty;
                e.Cancel = true;

                Hide();
            }
        }
    }
}
