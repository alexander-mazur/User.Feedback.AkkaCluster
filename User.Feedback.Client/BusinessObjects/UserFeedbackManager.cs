using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Akka.Actor;
using Akka.Routing;
using User.Feedback.Client.Actors;
using User.Feedback.Common;
using User.Feedback.Common.Messages;

namespace User.Feedback.Client.BusinessObjects
{
    public class UserFeedbackManager : IUserFeedbackManager
    {
        private readonly IActorRef _remoteProcessorActor;
        private readonly ActorSelection _remotePersistenceActor;

        private readonly Stopwatch _stopwatch;
        private string _lastUserFeedbackMessage = string.Empty;

        public UserFeedbackManager(ActorSystem actorSystem)
        {
            _remoteProcessorActor = actorSystem.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "processor");
            _remotePersistenceActor = actorSystem.ActorSelection(ConfigurationManager.AppSettings["UserFeedbackPersistenceActor"]);

            actorSystem.ActorOf(Props.Create(() => new UserFeedbackUpdateActor(this)), "UserFeedbackUpdate");

            _stopwatch = new Stopwatch();
        }

        public void TellUserFeedback(UserFeedback userFeedback)
        {
            _remoteProcessorActor.Tell(new TellUserFeedbackMessage(userFeedback));
        }

        public void TellBatchOfUserFeedbacks(UserFeedback userFeedback, int count)
        {
            _stopwatch.Reset();
            _stopwatch.Start();

            for (var index = 0; index < count; index++)
            {
                var newUserFeedback = new UserFeedback($"{index + 1}:{userFeedback.Message}", userFeedback.Created);

                if (index == count - 1)
                {
                    _lastUserFeedbackMessage = newUserFeedback.Message;
                }

                TellUserFeedback(newUserFeedback);
            }
        }

        public Task<ReplyUserFeedbacksMessage> AskUserFeedbackCollection()
        {
            return _remotePersistenceActor.Ask<ReplyUserFeedbacksMessage>(new RequestUserFeedbacksMessage());
        }

        public void RaiseUserFeedbackUpdate(UserFeedback userFeedback)
        {
            UserFeedbackUpdated?.Invoke(this, userFeedback);

            if (_stopwatch.IsRunning && userFeedback.Message.StartsWith(_lastUserFeedbackMessage))
            {
                _stopwatch.Stop();

                MessageBox.Show($"The process time of batch messages is {_stopwatch.ElapsedMilliseconds} ms.");
            }
        }

        public event EventHandler<UserFeedback> UserFeedbackUpdated;
    }
}