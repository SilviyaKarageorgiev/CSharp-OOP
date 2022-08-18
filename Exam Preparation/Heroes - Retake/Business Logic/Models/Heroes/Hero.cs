using Heroes.Models.Contracts;
using System;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                this.armour = value;
            }
        }


        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value;
            }
        }

        public bool IsAlive => Health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            int leftPoints = 0;

            this.armour -= points;

            if (this.armour <= 0)
            {
                leftPoints = Math.Abs(this.Armour);
                this.armour = 0;
            }

            if (leftPoints > 0)
            {
                this.health -= leftPoints;

                if (this.health < 0)
                {
                    this.health = 0;
                }
            }
        }
    }
}
