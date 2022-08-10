using Easter.Models.Eggs.Contracts;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {

        }

        public string Name => throw new System.NotImplementedException();

        public int EnergyRequired => throw new System.NotImplementedException();

        public void GetColored()
        {
            throw new System.NotImplementedException();
        }

        public bool IsDone()
        {
            throw new System.NotImplementedException();
        }
    }
}
