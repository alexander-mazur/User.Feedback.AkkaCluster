
namespace User.Feedback.Common.Messages
{
    public class TellUserFeedbackMessage
    {
        public UserFeedback UserFeedback { get; private set; }

        public TellUserFeedbackMessage(UserFeedback userFeedback)
        {
            UserFeedback = userFeedback;
        }
    }
}
