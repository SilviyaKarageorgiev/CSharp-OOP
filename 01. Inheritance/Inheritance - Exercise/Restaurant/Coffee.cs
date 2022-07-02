namespace Restaurant
{
    public class Coffee : HotBeverage
    {

        private double coffeeMilliliters;
        private decimal coffeePrice;
        private double caffeine;

        public Coffee(string name, double caffeine)
            : base(name, 3.50m, 50)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }

    }
}
