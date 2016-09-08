using System;
using Akka.Actor;
using Akka.Cluster;
using Akka.Cluster.Tools.PublishSubscribe;

using User.Feedback.Common;
using User.Feedback.Common.Messages;

namespace User.Feedback.Central.Actors
{
    public class UserFeedbackProcessorActor : ReceiveActor
    {
        public readonly IActorRef Mediator = DistributedPubSub.Get(Context.System).Mediator;

        private readonly ActorSelection _remotePersistenceActor;

        public UserFeedbackProcessorActor(ActorSelection remotePersistenceActor)
        {
            _remotePersistenceActor = remotePersistenceActor;

            Receive<TellUserFeedbackMessage>(tellUserFeedback => ProcessTellUserFeedbackMessage(tellUserFeedback));
            Receive<UserFeedbackUpdateMessage>(userFeedbackUpdate => ProcessUserFeedbackUpdateMessage(userFeedbackUpdate));
        }

        private void ProcessTellUserFeedbackMessage(TellUserFeedbackMessage tellUserFeedbackMessage)
        {
            _remotePersistenceActor.Tell(tellUserFeedbackMessage);
        }

        private void ProcessUserFeedbackUpdateMessage(UserFeedbackUpdateMessage userFeedbackUpdate)
        {
            Console.WriteLine($"Processed message: {userFeedbackUpdate.UserFeedback.Message}");

            Mediator.Tell(new Publish(Metadata.UserFeedback.Topic, userFeedbackUpdate));
        }
    }
}
