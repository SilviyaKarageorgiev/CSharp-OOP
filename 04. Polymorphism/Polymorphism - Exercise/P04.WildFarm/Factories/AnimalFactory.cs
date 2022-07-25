using P04.WildFarm.Animals;
using P04.WildFarm.Animals.Birds;
using P04.WildFarm.Animals.Mammals;
using P04.WildFarm.Exceptions;
using P04.WildFarm.Factories.Interfaces;

namespace P04.WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string thirdParam, string forthParam = null)
        {
            Animal animal;

            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(thirdParam));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(thirdParam));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, thirdParam);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, thirdParam);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, thirdParam, forthParam);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, thirdParam, forthParam);
            }
            else
            {
                throw new InvalidFactoryTypeException();
            }

            return animal;
        }
    }
}
