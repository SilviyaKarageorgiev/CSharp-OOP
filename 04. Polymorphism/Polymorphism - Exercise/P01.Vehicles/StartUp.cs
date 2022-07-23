using P01.Vehicles.Core;
using System;

namespace P01.Vehicles
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
