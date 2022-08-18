namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int maceDamage = 25;

        public Mace(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}
