using P04.WildFarm.Animals;

namespace P04.WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string thirdParam, string forthParam = null);
    }
}
