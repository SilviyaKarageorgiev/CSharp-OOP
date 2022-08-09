using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;


        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {

        }

        public string Make => throw new System.NotImplementedException();

        public string Model => throw new System.NotImplementedException();

        public string VIN => throw new System.NotImplementedException();

        public int HorsePower => throw new System.NotImplementedException();

        public double FuelAvailable => throw new System.NotImplementedException();

        public double FuelConsumptionPerRace => throw new System.NotImplementedException();

        public void Drive()
        {
            throw new System.NotImplementedException();
        }
    }
}
