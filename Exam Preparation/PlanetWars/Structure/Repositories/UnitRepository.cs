using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => throw new System.NotImplementedException();

        public void AddItem(IMilitaryUnit model)
        {
            throw new System.NotImplementedException();
        }

        public IMilitaryUnit FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveItem(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
