﻿using System;
using Akka.Actor;
using User.Feedback.Central.Actors;

namespace User.Feedback.Central
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new CentralActorSystem())
            {
                Console.WriteLine("User.Feedback Central Application started.");
                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
