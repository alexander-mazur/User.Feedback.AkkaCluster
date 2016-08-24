using User.Feedback.Client.BusinessObjects;

namespace User.Feedback.Client.Actors
{
    public interface IClientActorSystem
    {
        IUserFeedbackManager UserFeedbackManager { get; }
    }
}