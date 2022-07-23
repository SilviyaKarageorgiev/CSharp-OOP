using P02.VehiclesExtension.Models;
using System;

namespace P02.VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        public void Start()
        {

            string[] inputCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]), double.Parse(inputCar[3]));

            string[] inputTruck = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]), double.Parse(inputTruck[3]));

            string[] inputBus = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle bus = new Bus(double.Parse(inputBus[1]), double.Parse(inputBus[2]), double.Parse(inputBus[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Drive")
                {
                    if (cmdArgs[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(cmdArgs[2])));
                    }
                    else if (cmdArgs[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(cmdArgs[2])));
                    }
                    else if (cmdArgs[1] == "Bus")
                    {
                        Console.WriteLine(bus.Drive(double.Parse(cmdArgs[2])));
                    }
                }

                else if (cmdArgs[0] == "Refuel")
                {
                    if (cmdArgs[1] == "Car")
                    {
                        car.Refuel(double.Parse(cmdArgs[2]));
                    }
                    else if (cmdArgs[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(cmdArgs[2]));
                    }
                    else if (cmdArgs[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(cmdArgs[2]));
                    }
                }

                else if (cmdArgs[0] == "DriveEmpty")
                {
                    if (cmdArgs[1] == "Car")
                    {
                        Console.WriteLine(car.DriveEmpty(double.Parse(cmdArgs[2])));
                    }
                    else if (cmdArgs[1] == "Truck")
                    {
                        Console.WriteLine(truck.DriveEmpty(double.Parse(cmdArgs[2])));
                    }
                    else if (cmdArgs[1] == "Bus")
                    {
                        Console.WriteLine(bus.DriveEmpty(double.Parse(cmdArgs[2])));
                    }
                }

            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());

        }
    }
}

