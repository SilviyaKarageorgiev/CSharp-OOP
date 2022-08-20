using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private bool canBreath;
        private IBag bag;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }

        public bool CanBreath => Oxygen > 0;

        public IBag Bag
        {
            get => bag;
        }

        public virtual void Breath()
        {
            Oxygen -= 10;

            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string bagItems = Bag.Items.Count == 0 ? "none" : string.Join(", ", Bag.Items);

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");
            sb.AppendLine($"Bag items: {bagItems}");

            return sb.ToString().TrimEnd();
        }
    }
}
