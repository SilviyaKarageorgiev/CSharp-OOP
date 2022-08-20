using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private List<string> items;

        public Planet(string name)
        {

        }

        public ICollection<string> Items => throw new System.NotImplementedException();

        public string Name => throw new System.NotImplementedException();
    }
}
