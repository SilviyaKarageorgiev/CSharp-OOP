using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {

            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Count > 0)
                {
                    var currItem = planet.Items.First();

                    astronaut.Bag.Items.Add(currItem);
                    planet.Items.Remove(currItem);
                    astronaut.Breath();

                    if (!astronaut.CanBreath || !planet.Items.Any())
                    {
                        break;
                    }
                }
            }

        }
    }
}
