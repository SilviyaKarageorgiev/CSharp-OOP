namespace P01.Vehicles_1_.Models
{
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrement = 1.6;
        private const double RefuelCoefficient = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumptionModifier 
            => TruckFuelConsumptionIncrement;

        public override void Refuel(double liters)
        {
            base.Refuel(liters * RefuelCoefficient);
        }
    }
}
