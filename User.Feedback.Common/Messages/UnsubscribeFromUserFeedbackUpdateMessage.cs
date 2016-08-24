using Akka.Actor;

namespace User.Feedback.Common.Messages
{
    public class UnsubscribeFromUserFeedbackUpdateMessage
    {
        public IActorRef Subscriber { get; private set; }

        public UnsubscribeFromUserFeedbackUpdateMessage(IActorRef subscriber)
        {
            Subscriber = subscriber;
        }
    }
}
