using Formula1.Models.Contracts;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;

        public Pilot(string fullName)
        {

        }

        public string FullName => throw new System.NotImplementedException();

        public IFormulaOneCar Car => throw new System.NotImplementedException();

        public int NumberOfWins => throw new System.NotImplementedException();

        public bool CanRace => throw new System.NotImplementedException();

        public void AddCar(IFormulaOneCar car)
        {
            throw new System.NotImplementedException();
        }

        public void WinRace()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
