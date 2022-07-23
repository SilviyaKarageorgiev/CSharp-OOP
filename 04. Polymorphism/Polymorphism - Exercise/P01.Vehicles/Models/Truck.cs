namespace P01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionCoefIncreasement = 1.6;
        private const double FuelRefuelCoef = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + FuelConsumptionCoefIncreasement;
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * FuelRefuelCoef);
        }
    }
}
