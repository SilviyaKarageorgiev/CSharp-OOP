using P04.BorderControl.Models;
using P04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace P04.BorderControl.Core
{
    public class Engine : IEngine
    {
        public void Start()
        {
            List<IIdentifiable> allParticipants = new List<IIdentifiable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 2)
                {
                    Robot robot = new Robot(input[0], input[1]);
                    allParticipants.Add(robot);
                }
                else if (input.Length == 3)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    allParticipants.Add(citizen);
                }
            }

            string endsTo = Console.ReadLine();
            List<IIdentifiable> detained = new List<IIdentifiable>();

            foreach (var participant in allParticipants)
            {
                if (participant.Id.EndsWith(endsTo))
                {
                    detained.Add(participant);
                }
            }

            PrintDetained(detained);
        }

        private void PrintDetained(List<IIdentifiable> detained)
        {
            foreach (var det in detained)
            {
                Console.WriteLine(det.Id);
            }
        }
    }
}
