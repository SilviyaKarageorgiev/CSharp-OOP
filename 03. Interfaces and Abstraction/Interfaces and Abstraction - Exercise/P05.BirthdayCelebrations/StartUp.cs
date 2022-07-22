using Microsoft.VisualBasic;
using P05.BirthdayCelebrations.Core;

namespace P05.BirthdayCelebrations
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
