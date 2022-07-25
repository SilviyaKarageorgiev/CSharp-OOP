using P01.Vehicles_1_.Models;

namespace P01.Vehicles_1_.Factory.Interfaces
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption);
    }
}
