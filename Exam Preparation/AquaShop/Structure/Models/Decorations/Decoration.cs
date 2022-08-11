using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        public Decoration(int comfort, decimal price)
        {

        }

        public int Comfort => throw new System.NotImplementedException();

        public decimal Price => throw new System.NotImplementedException();
    }
}
