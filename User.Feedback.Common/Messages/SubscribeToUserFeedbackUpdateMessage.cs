using Akka.Actor;

namespace User.Feedback.Common.Messages
{
    public class SubscribeToUserFeedbackUpdateMessage
    {
        public IActorRef Subscriber { get; private set; }

        public SubscribeToUserFeedbackUpdateMessage(IActorRef subscriber)
        {
            Subscriber = subscriber;
        }
    }
}
