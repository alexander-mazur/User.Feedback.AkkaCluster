using System;
using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using User.Feedback.Common;
using User.Feedback.Common.Messages;

namespace User.Feedback.Persistence.Actors
{
    public class UserFeedbackPersistenceActor : ReceiveActor
    {
        private readonly IList<UserFeedback> _userFeedbacks = new List<UserFeedback>();

        public UserFeedbackPersistenceActor()
        {
            Receive<TellUserFeedbackMessage>(tellUserFeedback =>
            {
                Console.WriteLine($"Save message in the persistance storage: {tellUserFeedback.UserFeedback.Message}; total count: {_userFeedbacks.Count}");

                _userFeedbacks.Add(tellUserFeedback.UserFeedback);
                Sender.Tell(new UserFeedbackUpdateMessage(
                    new UserFeedback(tellUserFeedback.UserFeedback.Message + "*", tellUserFeedback.UserFeedback.Created)));
            });

            Receive<RequestUserFeedbacksMessage>(request =>
            {
                var result = new ReplyUserFeedbacksMessage(_userFeedbacks);
                Sender.Tell(result, Self);
            });
        }
    }
}
