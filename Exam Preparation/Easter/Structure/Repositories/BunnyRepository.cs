using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> models;

        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => throw new System.NotImplementedException();

        public void Add(IBunny model)
        {
            throw new System.NotImplementedException();
        }

        public IBunny FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IBunny model)
        {
            throw new System.NotImplementedException();
        }
    }
}
