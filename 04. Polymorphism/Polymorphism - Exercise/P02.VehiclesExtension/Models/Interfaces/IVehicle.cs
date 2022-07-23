namespace P02.VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {

        double TankCapacity { get; }
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        string Drive(double distance);
        string DriveEmpty(double distance);
        void Refuel(double fuel);
    }
}
