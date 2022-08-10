using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System.Collections.Generic;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private string energy;
        private readonly List<IDye> dyes;

        public Bunny(string name, int energy)
        {
            dyes = new List<IDye>();
        }

        public string Name => throw new System.NotImplementedException();

        public int Energy => throw new System.NotImplementedException();

        public ICollection<IDye> Dyes => throw new System.NotImplementedException();

        public void AddDye(IDye dye)
        {
            throw new System.NotImplementedException();
        }

        public abstract void Work();
    }
}
