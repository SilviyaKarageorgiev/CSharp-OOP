using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => throw new System.NotImplementedException();

        public void Add(IDecoration model)
        {
            throw new System.NotImplementedException();
        }

        public IDecoration FindByType(string type)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IDecoration model)
        {
            throw new System.NotImplementedException();
        }
    }
}
