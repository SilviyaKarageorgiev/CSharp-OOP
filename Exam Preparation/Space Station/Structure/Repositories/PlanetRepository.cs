using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => throw new System.NotImplementedException();

        public void Add(IPlanet model)
        {
            throw new System.NotImplementedException();
        }

        public IPlanet FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IPlanet model)
        {
            throw new System.NotImplementedException();
        }
    }
}
