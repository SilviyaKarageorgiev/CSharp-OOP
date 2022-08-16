using PlanetWars.Models.Weapons.Contracts;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;

        public Weapon(int destructionLevel, double price)
        {

        }

        public double Price => throw new System.NotImplementedException();

        public int DestructionLevel => throw new System.NotImplementedException();
    }
}
