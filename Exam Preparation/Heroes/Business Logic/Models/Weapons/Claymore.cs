namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int ClaymoreDamage = 20;

        public Claymore(string name, int durability)
            : base(name, durability)
        {
            
        }

        public override int DoDamage()
        {
            if (this.Durability > 0)
            {
                this.Durability -= 1;
                return ClaymoreDamage;
            }

            return 0;
        }
    }
}
