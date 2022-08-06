using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System.Collections.Generic;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> models;

        public VesselRepository()
        {
            models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => throw new System.NotImplementedException();

        public void Add(IVessel model)
        {
            throw new System.NotImplementedException();
        }

        public IVessel FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IVessel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
