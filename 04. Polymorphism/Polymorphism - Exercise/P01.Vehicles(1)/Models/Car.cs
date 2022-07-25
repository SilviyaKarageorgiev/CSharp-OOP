namespace P01.Vehicles_1_.Models
{
    public class Car : Vehicle
    {
        private const double CarFuelConsumptionIncrement = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumptionModifier
            => CarFuelConsumptionIncrement;

    }
}
