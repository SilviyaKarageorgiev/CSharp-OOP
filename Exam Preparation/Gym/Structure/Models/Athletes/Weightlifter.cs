namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int stamina = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, stamina)
        {
        }
    }
}
