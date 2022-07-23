namespace P02.VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double RefuelModifier => 0.95;
        public override double FuelConsumptionModifier => 1.6;
    }
}
