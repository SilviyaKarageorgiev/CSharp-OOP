using P04.BorderControl.Core;
using System;

namespace P04.BorderControl
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
