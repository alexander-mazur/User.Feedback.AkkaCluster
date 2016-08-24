using System;

namespace User.Feedback.Common
{
    public class UserFeedback
    {
        public string Message { get; private set; }

        public DateTime Created { get; private set; }

        public UserFeedback(string message, DateTime createDateTime)
        {
            Message = message;
            Created = createDateTime;
        }
    }
}

