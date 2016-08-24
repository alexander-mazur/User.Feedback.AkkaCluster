using System;

using User.Feedback.Client.Views.SendMessage;
using User.Feedback.Client.Views.ViewMessages;

namespace User.Feedback.Client.Views.Main
{
    public class MainFormPresenter 
    {
        public IMainForm View { get; }

        public MainFormPresenter(IMainForm view)
        {
            View = view;

            View.ShowSendMessageForm += OnShowSendMessageForm;
            View.ShowViewMessagesForm += OnShowViewMessagesForm;
        }

        private void OnShowViewMessagesForm(object sender, EventArgs e)
        {
            var viewMessagesForm = new ViewMessagesForm();
            viewMessagesForm.Show();
        }

        private void OnShowSendMessageForm(object sender, EventArgs e)
        {
            var sendMessageForm = new SendMessageForm();
            sendMessageForm.Show();
        }
    }
}