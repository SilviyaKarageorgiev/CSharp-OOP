using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return models.Remove(model);
        }
    }
}
