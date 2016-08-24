using System;

using User.Feedback.Common;
using User.Feedback.Client.BusinessObjects;

namespace User.Feedback.Client.Views.ViewMessages
{
    public class ViewMessagesFormPresenter
    {
        public IViewMessagesForm View { get; }

        private IUserFeedbackManager UserFeedbackManager { get; }

        public ViewMessagesFormPresenter(IViewMessagesForm view, IUserFeedbackManager userFeedbackManager)
        {
            View = view;
            UserFeedbackManager = userFeedbackManager;

            View.MessagesRequested += OnMessagesRequested;

            UserFeedbackManager.UserFeedbackUpdated += OnUserFeedbackUpdated;
            UserFeedbackManager.SubscribeToUserFeedbackUpdates();
        }

        private void OnMessagesRequested(object sender, EventArgs e)
        {
            UserFeedbackManager.AskUserFeedbackCollection().ContinueWith(task =>
            {
                View.AppendUserFeedbacks(task.Result.UserFeedbacks);
            });
        }

        private void OnUserFeedbackUpdated(object sender, UserFeedback userFeedback)
        {
            View.AppendUserFeedback(userFeedback);
        }
    }
}