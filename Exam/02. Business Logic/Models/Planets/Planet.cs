using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository units;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public double CalculateMilitaryPower()
        {
            double sumEndurances = Army.Sum(x => x.EnduranceLevel);
            double sumWeaponDestrLevels = Weapons.Sum(x => x.DestructionLevel);

            double totalAmount = sumEndurances + sumWeaponDestrLevels;

            if (Army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount += totalAmount * 0.3;
            }
            if (Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                totalAmount += totalAmount * 0.45;
            }

            return Math.Round(totalAmount, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");

            if (this.Army.Any())
            {
                sb.AppendLine($"--Forces: {string.Join(", ", Army.Select(x => x.GetType().Name))}");
            }
            else
            {
                sb.AppendLine("--Forces: No units");
            }

            if (this.Weapons.Any())
            {
                sb.AppendLine($"--Combat equipment: {string.Join(", ", Weapons.Select(x => x.GetType().Name))}");
            }
            else
            {
                sb.AppendLine("--Combat equipment: No weapons");
            }

            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
