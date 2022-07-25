using P04.WildFarm.Core;
using P04.WildFarm.Factories;
using P04.WildFarm.Factories.Interfaces;
using System;

namespace P04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            IEngine engine = new Engine(foodFactory, animalFactory);
            engine.Start();
        }
    }
}
