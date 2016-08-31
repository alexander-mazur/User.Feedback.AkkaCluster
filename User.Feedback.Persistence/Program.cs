using System;

using User.Feedback.Persistence.Actors;

namespace User.Feedback.Persistence
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new PersistenceActorSystem())
            {
                Console.WriteLine("User.Feedback Persistence Application started.");
                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
