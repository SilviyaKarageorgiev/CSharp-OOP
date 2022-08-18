using Heroes.Models.Contracts;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        private bool isAlive;

        public Hero(string name, int health, int armour)
        {

        }

        public string Name => throw new System.NotImplementedException();

        public int Health => throw new System.NotImplementedException();

        public int Armour => throw new System.NotImplementedException();

        public IWeapon Weapon => throw new System.NotImplementedException();

        public bool IsAlive => throw new System.NotImplementedException();

        public void AddWeapon(IWeapon weapon)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(int points)
        {
            throw new System.NotImplementedException();
        }
    }
}
