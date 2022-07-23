using P01.Vehicles.Models.Interfaces;
using System;

namespace P01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; protected set; }

        public string Drive(double distance)
        {
            if (FuelQuantity < FuelConsumption * distance)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * FuelConsumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
