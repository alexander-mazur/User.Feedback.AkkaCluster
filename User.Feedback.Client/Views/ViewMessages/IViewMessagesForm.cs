using System;
using System.Collections.Generic;

using User.Feedback.Common;

namespace User.Feedback.Client.Views.ViewMessages
{
    public interface IViewMessagesForm
    {
        event EventHandler MessagesRequested;

        void AppendUserFeedbacks(IList<UserFeedback> userFeedbacks);

        void AppendUserFeedback(UserFeedback userFeedback);
    }
}