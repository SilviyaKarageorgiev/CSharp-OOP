using Heroes.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {

        public string Fight(ICollection<IHero> heroes)
        {
            List<IHero> knights = heroes.Where(h => h.GetType().Name == "Knight").ToList();

            List<IHero> barbarians = heroes.Where(hero => hero.GetType().Name == "Barbarian").ToList();

            bool winKnights = false;
            bool winBarbarians = false;

            while (knights.Any(k => k.IsAlive) || barbarians.Any(b => b.IsAlive))
            {
                foreach (var knight in knights.Where(k => k.IsAlive == true))
                {
                    foreach (var barb in barbarians.Where(b => b.IsAlive == true))
                    {
                        barb.TakeDamage(knight.Weapon.DoDamage());
                    }

                    if (barbarians.All(b => b.IsAlive == false))
                    {
                        winKnights = true;
                        break;
                    }
                }
                if (winKnights)
                {
                    break;
                }

                foreach (var barb in barbarians.Where(b => b.IsAlive == true))
                {
                    foreach (var knight in knights.Where(k => k.IsAlive == true))
                    {
                        knight.TakeDamage(barb.Weapon.DoDamage());
                    }

                    if (knights.All(k => k.IsAlive == false))
                    {
                        winBarbarians = true;
                        break;
                    }
                }

                if (winBarbarians)
                {
                    break;
                }
            }

            if (winKnights)
            {
                int casualties = knights.Count(x => x.IsAlive == false);
                return $"The knights took {casualties} casualties but won the battle.";
            }
            else
            {
                int casualties = barbarians.Count(x => x.IsAlive == false);
                return $"The barbarians took {casualties} casualties but won the battle.";
            }

        }
    }
}
