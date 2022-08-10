namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int energy = 100;

        public HappyBunny(string name)
            : base(name, energy)
        {
        }

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}
