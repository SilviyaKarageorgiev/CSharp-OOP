using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(x => x.GetType().Name == "Knight" && x.Weapon != null && x.IsAlive).ToList();

            List<IHero> barbarians = players.Where(x => x.GetType().Name == "Barbarian" && x.Weapon != null && x.IsAlive).ToList();

            bool knightsWin = false;
            bool barbariansWin = false;

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
                        if (knight.IsAlive && barbarian.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }

                if (knights.All(x => x.IsAlive == false))
                {
                    barbariansWin = true;
                    break;
                }
                else if (barbarians.All(x => x.IsAlive == false))
                {
                    knightsWin = true;
                    break;
                }
            }

            if (knightsWin)
            {
                return $"The knights took {knights.Count(x => x.IsAlive == false)} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {barbarians.Count(x => x.IsAlive == false)} casualties but won the battle.";
            }

        }
    }
}
