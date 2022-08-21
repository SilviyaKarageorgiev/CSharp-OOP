using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
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
        private UnitRepository army;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            army = new UnitRepository();
            weapons = new WeaponRepository();
            Name = name;
            Budget = budget;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }
        
        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string forcesString = Army.Count == 0 ? "No units" : string.Join(", ", Army.Select(x => x.GetType().Name));
            string combatString = Weapons.Count == 0 ? "No weapons" : string.Join(", ", Weapons.Select(x => x.GetType().Name));

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: {forcesString}");
            sb.AppendLine($"--Combat equipment: {combatString}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public double CalculateMilitaryPower()
        {
            double totalAmount = Army.Sum(x => x.EnduranceLevel) + Weapons.Sum(x => x.DestructionLevel);

            if (Army.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmount *= 1.3;
            }

            if (Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmount *= 1.45;
            }

            return Math.Round(totalAmount, 3);
        }

    }
}
