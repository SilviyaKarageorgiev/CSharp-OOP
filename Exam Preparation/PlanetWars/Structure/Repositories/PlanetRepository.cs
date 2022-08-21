using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => throw new System.NotImplementedException();

        public void AddItem(IPlanet model)
        {
            throw new System.NotImplementedException();
        }

        public IPlanet FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveItem(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
