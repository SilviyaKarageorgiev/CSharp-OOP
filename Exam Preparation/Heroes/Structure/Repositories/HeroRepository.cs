using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly Collection<IHero> models;

        public HeroRepository()
        {
            models = new Collection<IHero>();
        }

        public IReadOnlyCollection<IHero> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IHero model)
        {
            if (!Models.All(h => h.Name == model.Name))
            {
                models.Add(model);
            }
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            if (models.FirstOrDefault(h => h.Name == model.Name) == null)
            {
                return false;
            }
            models.Remove(model);
            return true;
        }
    }
}
