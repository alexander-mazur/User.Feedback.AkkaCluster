using System;
using System.Threading.Tasks;
using User.Feedback.Common;
using User.Feedback.Common.Messages;

namespace User.Feedback.Client.BusinessObjects
{
    public interface IUserFeedbackManager
    {
        void TellUserFeedback(UserFeedback userFeedback);

        void TellBatchOfUserFeedbacks(UserFeedback userFeedback, int count);

        Task<ReplyUserFeedbacksMessage> AskUserFeedbackCollection();

        void RaiseUserFeedbackUpdate(UserFeedback userFeedback);

        event EventHandler<UserFeedback> UserFeedbackUpdated;
    }
}