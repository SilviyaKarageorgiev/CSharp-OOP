using P03.Telephony.Core;
using System;
using Telephony.IO;
using Telephony.IO.Interfaces;

namespace P03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            //IReader fileReader = new FileReader("../../../Storage/data.txt");
            //IWriter fileWriter = new FileWriter("../../../Storage/result.txt");


            IEngine engine = new Engine();
            engine.Start();

        }
    }
}
