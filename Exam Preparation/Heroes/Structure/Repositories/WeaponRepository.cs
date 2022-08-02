using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {

        private readonly Collection<IWeapon> models;

        public WeaponRepository()
        {
            models = new Collection<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IWeapon model)
        {
            if (!Models.All(w => w.Name == model.Name))
            {
                models.Add(model);
            }
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(w => w.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            if (models.FirstOrDefault(w => w.Name == model.Name) == null)
            {
                return false;
            }
            models.Remove(model);
            return true;
        }
    }
}
