using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
        }

        public double Cost
        {
            get => this.cost;
            private set
            {
                this.cost = value;
            }
        }

        public int EnduranceLevel
        {
            get => this.enduranceLevel;
        }

        public void IncreaseEndurance()
        {
            this.enduranceLevel++;

            if (enduranceLevel > 20)
            {
                enduranceLevel = 20;

                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
