
using System;
using Akka.Actor;

namespace User.Feedback.Persistence.Actors
{
    public class PersistenceActorSystem : IDisposable
    {
        public PersistenceActorSystem()
        {
            Initialize();
        }

        public ActorSystem ActorSystem { get; private set; }

        private void Initialize()
        {
            ActorSystem = ActorSystem.Create("User-Feedback-Persistence");

            ActorSystem.ActorOf(Props.Create(() => new UserFeedbackPersistenceActor()), "UserFeedbackPersistence");
        }

        public void Dispose()
        {
            ActorSystem.Terminate();
        }
    }

}
