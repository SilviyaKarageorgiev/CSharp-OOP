using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System.Collections.Generic;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private double equipmentWeight;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {

        }

        public string Name => throw new System.NotImplementedException();

        public int Capacity => throw new System.NotImplementedException();

        public double EquipmentWeight => throw new System.NotImplementedException();

        public ICollection<IEquipment> Equipment => throw new System.NotImplementedException();

        public ICollection<IAthlete> Athletes => throw new System.NotImplementedException();

        public void AddAthlete(IAthlete athlete)
        {
            throw new System.NotImplementedException();
        }

        public void AddEquipment(IEquipment equipment)
        {
            throw new System.NotImplementedException();
        }

        public void Exercise()
        {
            throw new System.NotImplementedException();
        }

        public string GymInfo()
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            throw new System.NotImplementedException();
        }
    }
}
