using Akka.Actor;

using User.Feedback.Client.BusinessObjects;
using User.Feedback.Common.Messages;

namespace User.Feedback.Client.Actors
{
    public class UserFeedbackUpdateActor : ReceiveActor
    {
        public UserFeedbackUpdateActor(IUserFeedbackManager userFeedbackManager)
        {
            Receive<UserFeedbackUpdateMessage>(userFeedbackUpdate =>
            {
                userFeedbackManager.RaiseUserFeedbackUpdate(userFeedbackUpdate.UserFeedback);
            });
        }
    }
}
