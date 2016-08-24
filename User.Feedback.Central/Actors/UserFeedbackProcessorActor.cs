using System.Collections.Generic;
using Akka.Actor;
using User.Feedback.Common.Messages;

namespace User.Feedback.Central.Actors
{
    public class UserFeedbackProcessorActor : ReceiveActor
    {
        private readonly IActorRef _persistenceActor;
        private IList<IActorRef> _subscribers = new List<IActorRef>();

        public UserFeedbackProcessorActor(IActorRef persistenceActor)
        {
            _persistenceActor = persistenceActor;

            Receive<TellUserFeedbackMessage>(tellUserFeedback => ProcessTellUserFeedbackMessage(tellUserFeedback));

            Receive<RequestUserFeedbacksMessage>(request => ProcessRequestUserFeedbacksMessage(request));

            Receive<SubscribeToUserFeedbackUpdateMessage>(subscription => ProcessSubscriptionMessage(subscription));

            Receive<UserFeedbackUpdateMessage>(userFeedbackUpdate => ProcessUserFeedbackUpdateMessage(userFeedbackUpdate));
        }

        private void ProcessTellUserFeedbackMessage(TellUserFeedbackMessage tellUserFeedbackMessage)
        {
            _persistenceActor.Tell(tellUserFeedbackMessage);
        }

        private void ProcessRequestUserFeedbacksMessage(RequestUserFeedbacksMessage message)
        {
            _persistenceActor.Forward(message);
        }

        private void ProcessSubscriptionMessage(SubscribeToUserFeedbackUpdateMessage subscription)
        {
            if (!_subscribers.Contains(subscription.Subscriber))
            {
                _subscribers.Add(subscription.Subscriber);
            }
        }

        private void ProcessUserFeedbackUpdateMessage(UserFeedbackUpdateMessage userFeedbackUpdate)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Tell(userFeedbackUpdate);
            }
        }
    }
}
