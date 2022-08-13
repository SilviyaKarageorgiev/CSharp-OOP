using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {

        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IWeapon weapon = weapons.FindByName(weaponName);
            IHero hero = heroes.FindByName(heroName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = null;

            if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
            }
            else if (type == nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            this.heroes.Add(hero);

            if (type == nameof(Knight))
            {
                return $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                return $"Successfully added Barbarian {name} to the collection.";
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon;

            if (type == nameof(Mace))
            {
                weapon = new Mace(name, durability);
            }
            else if (type == nameof(Claymore))
            {
                weapon = new Claymore(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            this.weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            var orderedHeroes = heroes.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var hero in orderedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.AppendLine(hero.Weapon != null ? $"--Weapon: {hero.Weapon.Name}" : "--Weapon: Unarmed");
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            var map = new Map();
            var result = map.Fight(heroes.Models as ICollection<IHero>);

            return result;
        }
    }
}
