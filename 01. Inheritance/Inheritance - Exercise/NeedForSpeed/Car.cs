namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel)
            :base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 3;
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
