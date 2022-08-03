using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        public IReadOnlyCollection<IRace> Models => throw new System.NotImplementedException();

        public void Add(IRace model)
        {
            throw new System.NotImplementedException();
        }

        public IRace FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IRace model)
        {
            throw new System.NotImplementedException();
        }
    }
}
