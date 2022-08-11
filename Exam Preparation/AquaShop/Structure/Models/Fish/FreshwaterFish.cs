namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
        }

        public override void Eat()
        {
            throw new System.NotImplementedException();
        }
    }
}
