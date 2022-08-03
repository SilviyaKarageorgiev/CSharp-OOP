using Heroes.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {

        public string Fight(ICollection<IHero> heroes)
        {
            List<IHero> knights = heroes.Where(h => h.GetType().Name == "Knight" && h.Weapon != null && h.IsAlive).ToList();

            List<IHero> barbarians = heroes.Where(hero => hero.GetType().Name == "Barbarian" && hero.Weapon != null && hero.IsAlive).ToList();

            bool winKnights = false;
            bool winBarbarians = false;

            while (knights.Any() && barbarians.Any())
            {
                foreach (var knight in knights)
                {

                    foreach (var barbarian in barbarians)
                    {

                        if (knight.IsAlive && barbarian.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {

                    foreach (var knight in knights)
                    {

                        if (barbarian.IsAlive && knight.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }

                if (knights.All(x => x.IsAlive == false))
                {
                    winBarbarians = true;
                    break;
                }
                else if (barbarians.All(x => x.IsAlive == false))
                {
                    winKnights = true;
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
