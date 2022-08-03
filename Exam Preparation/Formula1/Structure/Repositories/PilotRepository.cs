using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        public IReadOnlyCollection<IPilot> Models => throw new System.NotImplementedException();

        public void Add(IPilot model)
        {
            throw new System.NotImplementedException();
        }

        public IPilot FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IPilot model)
        {
            throw new System.NotImplementedException();
        }
    }
}
