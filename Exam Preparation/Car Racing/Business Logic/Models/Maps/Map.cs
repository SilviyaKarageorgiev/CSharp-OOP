using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {

            if (racerOne.IsAvailable() == true && racerTwo.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (racerTwo.IsAvailable() == true && racerOne.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            racerOne.Race();
            racerTwo.Race();

            double racerOneRacingBehaviorMultiplier = 0;

            if (racerOne.RacingBehavior == "strict")
            {
                racerOneRacingBehaviorMultiplier = 1.2;
            }
            else
            {
                racerOneRacingBehaviorMultiplier = 1.1;
            }

            double calculateRacerOneResult = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneRacingBehaviorMultiplier;

            double racerTwoRacingBehaviorMultiplier = 0;

            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoRacingBehaviorMultiplier = 1.2;
            }
            else
            {
                racerTwoRacingBehaviorMultiplier = 1.1;
            }

            double calculateRacerTwoResult = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoRacingBehaviorMultiplier;

            if (calculateRacerOneResult > calculateRacerTwoResult)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }
    }
}
