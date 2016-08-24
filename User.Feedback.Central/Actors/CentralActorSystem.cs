
using System;
using Akka.Actor;

namespace User.Feedback.Central.Actors
{
    public class CentralActorSystem : IDisposable
    {
        public CentralActorSystem()
        {
            Initialize();
        }

        public ActorSystem ActorSystem { get; private set; }

        private void Initialize()
        {
            ActorSystem = ActorSystem.Create("User-Feedback-Central");

            var persistenceActor = ActorSystem.ActorOf(Props.Create(() => new UserFeedbackPersistenceActor()), "UserFeedbackPersistence");

            ActorSystem.ActorOf(Props.Create(() => new UserFeedbackProcessorActor(persistenceActor)), "UserFeedbackReceiver");
        }

        public void Dispose()
        {
            ActorSystem.Terminate();
        }
    }

}
