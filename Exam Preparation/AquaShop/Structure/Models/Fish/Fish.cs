using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;

        public Fish(string name, string species, decimal price)
        {

        }

        public string Name => throw new System.NotImplementedException();

        public string Species => throw new System.NotImplementedException();

        public int Size => throw new System.NotImplementedException();

        public decimal Price => throw new System.NotImplementedException();

        public abstract void Eat();
    }
}
