
namespace User.Feedback.Common.Messages
{
    public class UserFeedbackUpdateMessage
    {
        public UserFeedback UserFeedback { get; private set; }

        public UserFeedbackUpdateMessage(UserFeedback userFeedback)
        {
            UserFeedback = userFeedback;
        }
    }
}
