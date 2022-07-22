using P05.BirthdayCelebrations.Models;
using P05.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace P05.BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        public void Start()
        {

            List<IBirthable> birthables = new List<IBirthable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    birthables.Add(citizen);
                }

                else if (input[0] == "Robot")
                {
                    continue;
                }

                else if (input[0] == "Pet")
                {
                    Pet pet = new Pet(input[1], input[2]);
                    birthables.Add(pet);
                }

            }

            string wantedYear = Console.ReadLine();
            List<IBirthable> birthInWantedYear = new List<IBirthable>();

            foreach (var creature in birthables)
            {
                if (creature.Birthdate.EndsWith(wantedYear))
                {
                    birthInWantedYear.Add(creature);
                }
            }

            PrintBirthInWantedYear(birthInWantedYear);
        }

        private void PrintBirthInWantedYear(List<IBirthable> birthInWantedYear)
        {

            foreach (var creature in birthInWantedYear)
            {
                Console.WriteLine(creature.Birthdate);
            }

        }
    }
}
