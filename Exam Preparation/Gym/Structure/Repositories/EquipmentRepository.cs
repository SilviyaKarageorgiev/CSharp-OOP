using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => throw new System.NotImplementedException();

        public void Add(IEquipment model)
        {
            throw new System.NotImplementedException();
        }

        public IEquipment FindByType(string type)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IEquipment model)
        {
            throw new System.NotImplementedException();
        }
    }
}
