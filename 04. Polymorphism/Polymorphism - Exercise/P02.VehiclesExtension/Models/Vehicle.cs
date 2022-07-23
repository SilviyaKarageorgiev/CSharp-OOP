using P02.VehiclesExtension.Models.Interfaces;
using System;

namespace P02.VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {

        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            private set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; protected set; }
        public double TankCapacity { get; protected set; }

        public virtual double RefuelModifier => 1;
        public virtual double FuelConsumptionModifier => 0;

        public string Drive(double distance)
        {
            if (FuelQuantity < (FuelConsumption + FuelConsumptionModifier) * distance)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * (FuelConsumption + FuelConsumptionModifier);

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * (FuelConsumption);

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }

            else if (FuelQuantity + fuel * RefuelModifier > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }

            else
            {
                FuelQuantity += fuel * RefuelModifier;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
