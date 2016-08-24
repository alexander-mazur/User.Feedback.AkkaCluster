using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using User.Feedback.Client.Actors;
using User.Feedback.Common;

namespace User.Feedback.Client.Views.ViewMessages
{
    public partial class ViewMessagesForm : Form, IViewMessagesForm
    {
        public ViewMessagesFormPresenter Presenter { get; set; }

        private BindingList<UserFeedback> _userFeedbacks = new BindingList<UserFeedback>();

        public void AppendUserFeedbacks(IList<UserFeedback> userFeedbacks)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<UserFeedback>>(obj => AppendUserFeedbacks(userFeedbacks)), userFeedbacks);
            }
            else
            {
                userFeedbackBindingSource.DataSource = _userFeedbacks = new BindingList<UserFeedback>(userFeedbacks);
            }
        }

        public void AppendUserFeedback(UserFeedback userFeedback)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<UserFeedback>(obj => AppendUserFeedback(userFeedback)), userFeedback);
            }
            else
            {
                _userFeedbacks.Add(userFeedback);
            }
        }

        public ViewMessagesForm()
        {
            InitializeComponent();

            userFeedbackBindingSource.DataSource = _userFeedbacks;
        }

        protected override void OnLoad(EventArgs e)
        {
            Presenter = new ViewMessagesFormPresenter(this, ClientActorSystem.Instance.UserFeedbackManager);
        }

        public event EventHandler MessagesRequested
        {
            add { getMessagesButton.Click += value; }
            remove { getMessagesButton.Click += value; }
        }

    }
}
