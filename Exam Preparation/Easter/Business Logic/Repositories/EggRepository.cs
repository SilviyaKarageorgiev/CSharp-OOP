using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IEgg model)
        {
            this.models.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            return this.models.Remove(model);
        }
    }
}
