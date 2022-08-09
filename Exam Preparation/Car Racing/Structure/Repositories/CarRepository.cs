using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System.Collections.Generic;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {

        private readonly List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => throw new System.NotImplementedException();

        public void Add(ICar model)
        {
            throw new System.NotImplementedException();
        }

        public ICar FindBy(string property)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(ICar model)
        {
            throw new System.NotImplementedException();
        }
    }
}
