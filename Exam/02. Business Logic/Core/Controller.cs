using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit unit = null;

            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = planets.FindByName(planetName);

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IWeapon weapon = null;

            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = planets.FindByName(planetName);

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = null;

            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planet = new Planet(name, budget);
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var ordered = planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in ordered)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.FindByName(planetOne);
            var secondPlanet = planets.FindByName(planetTwo);

            bool firstHasNuclear = firstPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));
            bool secondHasNuclear = secondPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));

            IPlanet winner = null;
            IPlanet looser = null;

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                winner = firstPlanet;
                looser = secondPlanet;
            }
            else if (secondPlanet.MilitaryPower > firstPlanet.MilitaryPower)
            {
                winner = secondPlanet;
                looser = firstPlanet;
            }
            else
            {
                if (firstHasNuclear && !secondHasNuclear)
                {
                    winner = firstPlanet;
                    looser = secondPlanet;
                }
                else if (secondHasNuclear && !firstHasNuclear)
                {
                    winner = secondPlanet;
                    looser = firstPlanet;
                }
                else
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            winner.Profit(looser.Army.Sum(x => x.Cost) + looser.Weapons.Sum(x => x.Price));

            planets.RemoveItem(looser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);

        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
