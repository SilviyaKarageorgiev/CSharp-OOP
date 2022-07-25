using P01.Vehicles_1_.Core;
using P01.Vehicles_1_.Factory;
using P01.Vehicles_1_.Factory.Interfaces;
using P01.Vehicles_1_.Models;
using System;

namespace P01.Vehicles_1_
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            string[] truckData = Console.ReadLine().Split();

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory.CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
            Vehicle truck = vehicleFactory.CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));

            IEngine engine = new Engine(car, truck);
            engine.Start();
        }
    }
}
