namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 10;
        }

        public override double FuelConsumption
        {
            get
            {
                return this.DefaultFuelConsumption;
            }
        }
    }
}
