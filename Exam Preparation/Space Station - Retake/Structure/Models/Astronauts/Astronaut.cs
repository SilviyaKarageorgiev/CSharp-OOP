using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private bool canBreath;
        private IBag bag;

        public Astronaut(string name, double oxygen)
        {

        }

        public string Name => throw new System.NotImplementedException();

        public double Oxygen => throw new System.NotImplementedException();

        public bool CanBreath => throw new System.NotImplementedException();

        public IBag Bag => throw new System.NotImplementedException();

        public virtual void Breath()
        {
            throw new System.NotImplementedException();
        }
    }
}
