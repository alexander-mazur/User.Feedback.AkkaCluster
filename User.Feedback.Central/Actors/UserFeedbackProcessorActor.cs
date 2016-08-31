using System.Collections.Generic;
using Akka.Actor;
using User.Feedback.Common.Messages;

namespace User.Feedback.Central.Actors
{
    public class UserFeedbackProcessorActor : ReceiveActor
    {
        private readonly ActorSelection _remotePersistenceActor;
        private readonly IList<IActorRef> _subscribers = new List<IActorRef>();

        public UserFeedbackProcessorActor(ActorSelection remotePersistenceActor)
        {
            _remotePersistenceActor = remotePersistenceActor;

            Receive<TellUserFeedbackMessage>(tellUserFeedback => ProcessTellUserFeedbackMessage(tellUserFeedback));

            Receive<SubscribeToUserFeedbackUpdateMessage>(subscription => ProcessSubscriptionMessage(subscription));

            Receive<UserFeedbackUpdateMessage>(userFeedbackUpdate => ProcessUserFeedbackUpdateMessage(userFeedbackUpdate));
        }

        private void ProcessTellUserFeedbackMessage(TellUserFeedbackMessage tellUserFeedbackMessage)
        {
            _remotePersistenceActor.Tell(tellUserFeedbackMessage);
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
