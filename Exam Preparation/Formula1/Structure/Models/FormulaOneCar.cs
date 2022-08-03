using Formula1.Models.Contracts;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {

        }

        public string Model => throw new System.NotImplementedException();

        public int Horsepower => throw new System.NotImplementedException();

        public double EngineDisplacement => throw new System.NotImplementedException();

        public double RaceScoreCalculator(int laps)
        {
            throw new System.NotImplementedException();
        }
    }
}
