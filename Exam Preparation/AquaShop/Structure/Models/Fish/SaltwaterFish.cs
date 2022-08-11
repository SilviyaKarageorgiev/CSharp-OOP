namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
        }

        public override void Eat()
        {
            throw new System.NotImplementedException();
        }
    }
}
