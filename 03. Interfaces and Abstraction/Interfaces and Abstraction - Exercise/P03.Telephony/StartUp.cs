using P03.Telephony.Core;
using System;

namespace P03.Telephony
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
