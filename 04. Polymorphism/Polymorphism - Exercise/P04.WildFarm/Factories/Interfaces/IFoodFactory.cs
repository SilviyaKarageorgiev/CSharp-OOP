using P04.WildFarm.Foods;

namespace P04.WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}
