using Gym.Models.Equipment.Contracts;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;

        public Equipment(double weight, decimal price)
        {

        }

        public double Weight => throw new System.NotImplementedException();

        public decimal Price => throw new System.NotImplementedException();
    }
}
