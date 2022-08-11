using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {

        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var orderedBunnies = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            IEgg egg = eggs.FindByName(eggName);

            if (orderedBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            Workshop workshop = new Workshop();

            foreach (var bunny in orderedBunnies)
            {
                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }
                if (egg.IsDone())
                {
                    break;
                }
            }

            if (egg.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            int doneEggs = eggs.Models.Count(x => x.IsDone());

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{doneEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                int dyesNotFinished = bunny.Dyes.Count(x => x.IsFinished() == false);

                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {dyesNotFinished} not finished");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
