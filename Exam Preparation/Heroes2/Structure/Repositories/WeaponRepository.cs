using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => throw new System.NotImplementedException();

        public void Add(IWeapon model)
        {
            throw new System.NotImplementedException();
        }

        public IWeapon FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IWeapon model)
        {
            throw new System.NotImplementedException();
        }
    }
}
