using Easter.Models.Bunnies.Contracts;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int energy = 50;

        public SleepyBunny(string name)
            : base(name, energy)
        {
        }

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}
