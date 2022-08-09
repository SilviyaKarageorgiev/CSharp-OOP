using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System.Collections.Generic;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {

        private readonly List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => throw new System.NotImplementedException();

        public void Add(IRacer model)
        {
            throw new System.NotImplementedException();
        }

        public IRacer FindBy(string property)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IRacer model)
        {
            throw new System.NotImplementedException();
        }
    }
}
