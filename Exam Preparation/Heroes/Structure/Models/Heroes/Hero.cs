using Heroes.Models.Contracts;
using System;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private bool isAlive;
        private IWeapon weapon;


        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
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
            get
            {
                return this.health;
            }
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
            get
            {
                return this.armour;
            }
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
            get
            {
                return this.weapon;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return isAlive; 
            }
            private set
            {
                if (this.Health > 0)
                {
                    isAlive = true;
                }
                else
                {
                    isAlive = false;
                }
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            int leftPoints = 0;

            this.Armour -= points;

            if (this.Armour <= 0)
            {
                leftPoints = Math.Abs(this.Armour);
                this.Armour = 0;
            }

            if (leftPoints > 0)
            {
                this.Health -= leftPoints;

                if (this.Health < 0)
                {
                    this.Health = 0;
                }
            }
        }
    }
}
