using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VehiclesExtension.Models
{
    internal class Bus : Vehicle
    {

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumptionModifier => 1.4;

    }
}
