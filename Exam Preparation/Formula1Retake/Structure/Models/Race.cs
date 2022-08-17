using Formula1.Models.Contracts;
using System.Collections.Generic;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            pilots = new List<IPilot>();
        }

        public string RaceName => throw new System.NotImplementedException();

        public int NumberOfLaps => throw new System.NotImplementedException();

        public bool TookPlace { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ICollection<IPilot> Pilots => throw new System.NotImplementedException();

        public void AddPilot(IPilot pilot)
        {
            throw new System.NotImplementedException();
        }

        public string RaceInfo()
        {
            throw new System.NotImplementedException();
        }

    }
}
