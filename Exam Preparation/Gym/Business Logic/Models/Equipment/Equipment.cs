using Gym.Models.Equipment.Contracts;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;

        public Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }

        public double Weight
        {
            get
            {
                return this.weight; 
            }
            private set
            {
                this.weight = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }
    }
}
