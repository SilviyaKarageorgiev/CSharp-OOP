namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int stamina = 60;

        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, stamina)
        {
        }

        public override void Exercise()
        {
            throw new System.NotImplementedException();
        }
    }
}
