using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> models;

        public VesselRepository()
        {
            models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IVessel model)
        {
            models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            if (models.Any(x => x.Name == model.Name))
            {
                models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
