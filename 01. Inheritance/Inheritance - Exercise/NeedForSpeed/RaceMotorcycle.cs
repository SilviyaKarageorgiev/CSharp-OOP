namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 8;
        }

        public override double FuelConsumption
        {
            get
                { return DefaultFuelConsumption; }
        }
    }
}
