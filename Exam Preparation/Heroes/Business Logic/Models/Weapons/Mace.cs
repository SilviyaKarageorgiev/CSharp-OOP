namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {

        private const int MaceDamage = 25;

        public Mace(string name, int durability)
            : base(name, durability)
        {
            
        }

        public override int DoDamage()
        {
            if (this.Durability > 0)
            {
                this.Durability -= 1;
                return MaceDamage;
            }

            return 0;
        }
    }
}
