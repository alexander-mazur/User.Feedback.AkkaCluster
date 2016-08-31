
using System;
using System.Configuration;
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

            var remotePersistenceActor = ActorSystem.ActorSelection(ConfigurationManager.AppSettings["UserFeedbackPersistenceActor"]);

            ActorSystem.ActorOf(Props.Create(() => new UserFeedbackProcessorActor(remotePersistenceActor)), "UserFeedbackProcessor");
        }

        public void Dispose()
        {
            ActorSystem.Terminate();
        }
    }

}
