using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            if (models.Any(x => x.Model == model.Model))
            {
                models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
