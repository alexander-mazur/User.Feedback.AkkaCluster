using System;
using System.Configuration;

using Akka.Actor;

using User.Feedback.Client.BusinessObjects;

namespace User.Feedback.Client.Actors
{
    public class ClientActorSystem : IDisposable, IClientActorSystem
    {
        public static ClientActorSystem Instance = new ClientActorSystem();

        private ClientActorSystem()
        {
            Initialize();
        }

        private ActorSystem ActorSystem { get; set; }

        public IUserFeedbackManager UserFeedbackManager { get; private set; }

        private void Initialize()
        {
            ActorSystem = ActorSystem.Create("User-Feedback-Central"); ;

            UserFeedbackManager = new UserFeedbackManager(ActorSystem);
        }

        public void Dispose()
        {
            ActorSystem.Terminate();
        }
    }
}
