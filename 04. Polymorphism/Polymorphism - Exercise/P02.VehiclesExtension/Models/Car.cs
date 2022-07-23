namespace P02.VehiclesExtension.Models
{
    public class Car : Vehicle
    {

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumptionModifier => 0.9;

    }
}
