using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
        {
            get => this.models;
        }

        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            var model = models.FirstOrDefault(x => x.Name == name);

            if (model == null)
            {
                return false;
            }
            else
            {
                models.Remove(model);
                return true;
            }
        }
    }
}
