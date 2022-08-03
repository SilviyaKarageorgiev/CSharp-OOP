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
            if (models.Any(w => w.Name == model.Name))
            {
                throw new InvalidOperationException($"The weapon {model.Name} already exists.");
            }
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var weapon = models.FirstOrDefault(x => x.Name == name);
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {name} does not exist.");
            }
            return weapon;
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
