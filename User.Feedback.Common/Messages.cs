using System.Collections.Generic;
using Akka.Actor;

namespace User.Feedback.Common
{
    public class TellUserFeedbackMessage
    {
        public UserFeedback UserFeedback { get; private set; }

        public TellUserFeedbackMessage(UserFeedback userFeedback)
        {
            UserFeedback = userFeedback;
        }
    }

    public class RequestUserFeedbacksMessage { }

    public class ReplyUserFeedbacksMessage
    {
        public IList<UserFeedback> UserFeedbacks { get; private set; }

        public ReplyUserFeedbacksMessage(IList<UserFeedback> userFeedbacks)
        {
            UserFeedbacks = userFeedbacks;
        }
    }

    public class SubscribeToUserFeedbackUpdateMessage
    {
        public IActorRef Subscriber { get; private set; }

        public SubscribeToUserFeedbackUpdateMessage(IActorRef subscriber)
        {
            Subscriber = subscriber;
        }
    }

    public class UnsubscribeFromUserFeedbackUpdateMessage
    {
        public IActorRef Subscriber { get; private set; }

        public UnsubscribeFromUserFeedbackUpdateMessage(IActorRef subscriber)
        {
            Subscriber = subscriber;
        }
    }

    public class UserFeedbackUpdateMessage
    {
        public UserFeedback UserFeedback { get; private set; }

        public UserFeedbackUpdateMessage(UserFeedback userFeedback)
        {
            UserFeedback = userFeedback;
        }
    }
}

