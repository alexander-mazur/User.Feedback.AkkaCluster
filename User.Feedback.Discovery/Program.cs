using System;

namespace User.Feedback.Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DiscoveryHostFactory.LaunchLighthouse())
            {
                Console.WriteLine("User.Feedback Discovery Application started.");
                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
