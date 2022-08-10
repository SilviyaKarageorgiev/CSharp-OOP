using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => throw new System.NotImplementedException();

        public void Add(IEgg model)
        {
            throw new System.NotImplementedException();
        }

        public IEgg FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IEgg model)
        {
            throw new System.NotImplementedException();
        }
    }
}
