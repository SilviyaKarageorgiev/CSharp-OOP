using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Threading;

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
            if (models.Any(x => x.Name == model.Name))
            {
                throw new InvalidOperationException($"The hero {model.Name} already exists.");
            }
            models.Add(model);
        }

        public IHero FindByName(string name)
        {
            var hero = models.FirstOrDefault(x => x.Name == name);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {name} does not exist.");
            }
            return hero;
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
