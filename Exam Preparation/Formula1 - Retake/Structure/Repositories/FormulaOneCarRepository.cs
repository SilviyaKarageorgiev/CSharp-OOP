using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => throw new System.NotImplementedException();

        public void Add(IFormulaOneCar model)
        {
            throw new System.NotImplementedException();
        }

        public IFormulaOneCar FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IFormulaOneCar model)
        {
            throw new System.NotImplementedException();
        }
    }
}
