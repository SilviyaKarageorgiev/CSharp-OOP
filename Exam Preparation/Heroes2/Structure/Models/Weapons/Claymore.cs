namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int claymoreDamage = 20;

        public Claymore(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}
