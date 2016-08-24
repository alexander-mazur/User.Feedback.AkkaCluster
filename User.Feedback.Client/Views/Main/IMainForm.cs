using System;
using User.Feedback.Client.BusinessObjects;

namespace User.Feedback.Client.Views.Main
{
    public interface IMainForm 
    {
        event EventHandler ShowSendMessageForm;

        event EventHandler ShowViewMessagesForm;
    }
}