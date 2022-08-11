namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int comfort = 5;
        private const decimal price = 10m;

        public Plant(int comfort, decimal price)
            : base(comfort, price)
        {
        }
    }
}
