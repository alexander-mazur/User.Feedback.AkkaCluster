using System;
using System.Windows.Forms;

using User.Feedback.Client.BusinessObjects;
using User.Feedback.Client.Properties;
using User.Feedback.Common;

namespace User.Feedback.Client.Views.SendMessage
{
    public class SendMessageFormPresenter
    {
        public ISendMessageForm View { get; }

        private IUserFeedbackManager UserFeedbackManager { get; }

        public SendMessageFormPresenter(ISendMessageForm view, IUserFeedbackManager userFeedbackManager)
        {
            View = view;
            UserFeedbackManager = userFeedbackManager;

            View.MessageSent += OnMessageSent;
        }

        private void OnMessageSent(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(View.Message))
            {
                MessageBox.Show(Resources.SendMessageFormPresenter_EmptyMessageError, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (View.MessagesCount == 1)
            {
                UserFeedbackManager.TellUserFeedback(new UserFeedback(View.Message, DateTime.Now));
            }
            else
            {
                UserFeedbackManager.TellBatchOfUserFeedbacks(new UserFeedback(View.Message, DateTime.Now), View.MessagesCount);
            }

            View.Message = string.Empty;
        }
    }
}