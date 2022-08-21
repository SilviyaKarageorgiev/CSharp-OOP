namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double price = 3.2;

        public BioChemicalWeapon(int destructionLevel)
            : base(destructionLevel, price)
        {
        }
    }
}
