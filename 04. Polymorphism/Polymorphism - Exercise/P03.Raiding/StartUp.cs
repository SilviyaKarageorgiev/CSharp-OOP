using System;
using System.Collections.Generic;

namespace P03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int points = 0;
            List<BaseHero> heroes = new List<BaseHero>();

            while (n > heroes.Count)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Druid":
                        BaseHero heroDruid = new Druid(name);
                        heroes.Add(heroDruid);
                        break;
                    case "Paladin":
                        BaseHero heroPaladin = new Paladin(name);
                        heroes.Add(heroPaladin);
                        break;
                    case "Rogue":
                        BaseHero heroRogue = new Rogue(name);
                        heroes.Add(heroRogue);
                        break;
                    case "Warrior":
                        BaseHero heroWarrior = new Warrior(name);
                        heroes.Add(heroWarrior);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            foreach (var hero in heroes)
            {
                points += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            int bossPoints = int.Parse(Console.ReadLine());

            if (points >= bossPoints)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
