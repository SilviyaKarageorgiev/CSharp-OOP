using P02.VehiclesExtension.Core;
using System;

namespace P02.VehiclesExtension
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            IEngine engine = new Engine();
            engine.Start();

        }
    }
}
