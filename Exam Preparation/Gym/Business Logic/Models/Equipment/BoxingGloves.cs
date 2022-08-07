namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {

        private const double weight = 227;
        private const decimal price = 120m;

        public BoxingGloves()
            : base(weight, price)
        {
        }
    }
}
