using System.Collections.Generic;

namespace User.Feedback.Common.Messages
{
    public class ReplyUserFeedbacksMessage
    {
        public IList<UserFeedback> UserFeedbacks { get; private set; }

        public ReplyUserFeedbacksMessage(IList<UserFeedback> userFeedbacks)
        {
            UserFeedbacks = userFeedbacks;
        }
    }
}
