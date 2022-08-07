using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private readonly List<IEquipment> equipment;
        private readonly List<IAthlete> athletes;


        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public double EquipmentWeight => this.equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment
        {
            get
            {
                return this.equipment;
            }
        }

        public ICollection<IAthlete> Athletes
        {
            get
            {
                return this.athletes;
            }
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.athletes.Add(athlete);
            this.Capacity--;
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");

            if (athletes.Count == 0)
            {
                sb.AppendLine("Athletes: No athletes");
            }
            else
            {
                sb.AppendLine($"Athletes: {string.Join(", ", athletes.Select(x => x.FullName))}");
            }

            sb.AppendLine($"Equipment total count: {this.equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();

        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            if (athletes.FirstOrDefault(x => x.FullName == athlete.FullName) == null)
            {
                return false;
            }

            athletes.Remove(athlete);
            return true;
        }
    }
}
