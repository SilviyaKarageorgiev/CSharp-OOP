using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models
        {
            get => this.models;
        }

        public void AddItem(IMilitaryUnit model)
        {
            models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            var model = models.FirstOrDefault(x => x.GetType().Name == name);

            if (model == null)
            {
                return false;
            }
            else
            {
                models.Remove(model);
                return true;
            }
        }
    }
}
