namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private int size;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = 5;
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
            this.Size += 2;
        }
    }
}
