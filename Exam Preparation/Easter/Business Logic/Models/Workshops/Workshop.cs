using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {

        public Workshop()
        {

        }

        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (var dye in bunny.Dyes.Where(x => x.IsFinished() == false))
            {
                while (dye.IsFinished() == false)
                {
                    egg.GetColored();
                    dye.Use();
                    bunny.Work();

                    if (egg.IsDone())
                    {
                        break;
                    }
                }

                if (bunny.Energy < 0)
                {
                    break;
                }
                if (egg.IsDone())
                {
                    break;
                }
                if (bunny.Dyes.All(x => x.IsFinished() == true))
                {
                    break;
                }
            }
        }
    }
}
