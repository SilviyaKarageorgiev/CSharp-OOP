namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private int size;

        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            Size = 3;
        }

        public override int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public override void Eat()
        {
            Size += 3;
        }
    }
}
