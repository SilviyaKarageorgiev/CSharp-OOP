using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int stamina = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, stamina)
        {

        }

        public override void Exercise()
        {
            this.Stamina += 10;

            if (this.Stamina > 100)
            {
                this.Stamina = 100;

                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
