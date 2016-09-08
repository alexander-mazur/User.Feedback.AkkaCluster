using System;
using System.Windows.Forms;
using Akka.Actor;
using User.Feedback.Client.Actors;
using User.Feedback.Client.Views.Main;

namespace User.Feedback.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (ClientActorSystem.Instance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
