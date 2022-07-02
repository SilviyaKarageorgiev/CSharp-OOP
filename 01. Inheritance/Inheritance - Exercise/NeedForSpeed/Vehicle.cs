namespace NeedForSpeed
{
    public class Vehicle
    {
        private double defaultFuelConsumption;
        private double fuelConsumption;
        private double fuel;
        private int horsePower;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public double DefaultFuelConsumption { get; set; } = 1.25;
        public virtual double FuelConsumption 
        {
            get
            {
                return this.DefaultFuelConsumption;
            }
        }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.DefaultFuelConsumption;
        }

    }
}
