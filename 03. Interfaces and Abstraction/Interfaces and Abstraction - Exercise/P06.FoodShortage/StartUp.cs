using P06.FoodShortage.Core;
using System;

namespace P06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Start();
        }
    }
}
