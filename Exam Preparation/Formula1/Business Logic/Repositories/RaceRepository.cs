using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {

        private readonly List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(x => x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            if (models.Any(x => x.RaceName == model.RaceName))
            {
                models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
