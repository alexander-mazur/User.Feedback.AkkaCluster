using Akka.Actor;
using Akka.Cluster.Tools.PublishSubscribe;

using User.Feedback.Client.BusinessObjects;
using User.Feedback.Common;
using User.Feedback.Common.Messages;

namespace User.Feedback.Client.Actors
{
    public class UserFeedbackUpdateActor : ReceiveActor
    {
        public readonly IActorRef Mediator = DistributedPubSub.Get(Context.System).Mediator;

        public UserFeedbackUpdateActor(IUserFeedbackManager userFeedbackManager)
        {
            Receive<UserFeedbackUpdateMessage>(userFeedbackUpdate =>
            {
                userFeedbackManager.RaiseUserFeedbackUpdate(userFeedbackUpdate.UserFeedback);
            });
        }

        protected override void PreStart()
        {
            base.PreStart();
            Mediator.Tell(new Subscribe(Metadata.UserFeedback.Topic, Self));
        }

        protected override void PostStop()
        {
            Mediator.Tell(new Unsubscribe(Metadata.UserFeedback.Topic, Self));
            base.PostStop();
        }
    }
}
