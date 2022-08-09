using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {

        }

        public string Username => throw new System.NotImplementedException();

        public string RacingBehavior => throw new System.NotImplementedException();

        public int DrivingExperience => throw new System.NotImplementedException();

        public ICar Car => throw new System.NotImplementedException();

        public bool IsAvailable()
        {
            throw new System.NotImplementedException();
        }

        public void Race()
        {
            throw new System.NotImplementedException();
        }
    }
}
