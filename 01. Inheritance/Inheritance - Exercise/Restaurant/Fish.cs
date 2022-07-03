namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double grams = 22;
        public Fish(string name, decimal price)
            : base(name, price, grams)
        {

        }
    }
}
