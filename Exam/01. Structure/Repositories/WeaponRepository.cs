using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => throw new System.NotImplementedException();

        public void AddItem(IWeapon model)
        {
            throw new System.NotImplementedException();
        }

        public IWeapon FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveItem(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
