using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System.Collections.Generic;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private UnitRepository army;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            army = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name => throw new System.NotImplementedException();

        public double Budget => throw new System.NotImplementedException();

        public double MilitaryPower => throw new System.NotImplementedException();

        public IReadOnlyCollection<IMilitaryUnit> Army => throw new System.NotImplementedException();

        public IReadOnlyCollection<IWeapon> Weapons => throw new System.NotImplementedException();

        public void AddUnit(IMilitaryUnit unit)
        {
            throw new System.NotImplementedException();
        }

        public void AddWeapon(IWeapon weapon)
        {
            throw new System.NotImplementedException();
        }

        public string PlanetInfo()
        {
            throw new System.NotImplementedException();
        }

        public void Profit(double amount)
        {
            throw new System.NotImplementedException();
        }

        public void Spend(double amount)
        {
            throw new System.NotImplementedException();
        }

        public void TrainArmy()
        {
            throw new System.NotImplementedException();
        }
    }
}
