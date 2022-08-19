namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double weight = 227;
        private const decimal price = 120;

        public BoxingGloves()
            : base(weight, price)
        {

        }

        public BoxingGloves(double weight, decimal price)
            : base(weight, price)
        {
        }
    }
}
