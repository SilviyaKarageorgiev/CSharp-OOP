using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private ICollection<IHero> models;

        public HeroRepository()
        {
            models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => throw new System.NotImplementedException();

        public void Add(IHero model)
        {
            throw new System.NotImplementedException();
        }

        public IHero FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IHero model)
        {
            throw new System.NotImplementedException();
        }
    }
}
