using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;

        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => throw new System.NotImplementedException();

        public void Add(IAstronaut model)
        {
            throw new System.NotImplementedException();
        }

        public IAstronaut FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IAstronaut model)
        {
            throw new System.NotImplementedException();
        }
    }
}
