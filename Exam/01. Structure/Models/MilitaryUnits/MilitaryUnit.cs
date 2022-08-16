using PlanetWars.Models.MilitaryUnits.Contracts;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {

        }

        public double Cost => throw new System.NotImplementedException();

        public int EnduranceLevel => throw new System.NotImplementedException();

        public void IncreaseEndurance()
        {
            throw new System.NotImplementedException();
        }
    }
}
