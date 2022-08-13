using Heroes.Models.Contracts;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        public Weapon(string name, int durability)
        {
        }


        public string Name => throw new System.NotImplementedException();

        public int Durability => throw new System.NotImplementedException();

        public abstract int DoDamage();
    }
}
