namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double price = 15;

        public NuclearWeapon(int destructionLevel)
            : base(destructionLevel, price)
        {
        }
    }
}
