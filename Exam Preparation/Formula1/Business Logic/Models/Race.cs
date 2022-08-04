using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace = false;
        private ICollection<IPilot> pilots;

        public Race()
        {
            pilots = new List<IPilot>();
        }

        public Race(string raceName, int numberOfLaps)
            : this()
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
        }

        public string RaceName
        {
            get
            {
                return this.raceName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return this.numberOfLaps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get
            {
                return this.tookPlace;
            }
            set
            {
                this.tookPlace = value;
            }
        }

        public ICollection<IPilot> Pilots
        {
            get
            {
                return this.pilots;
            }
            private set
            {
                this.pilots = value;
            }
        }

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            string tPlace = string.Empty;
            if (TookPlace == true)
            {
                tPlace = "Yes";
            }
            else if (TookPlace == false)
            {
                tPlace = "No";
            }

            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {this.Pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");
            sb.AppendLine($"Took place: {tPlace}");

            return sb.ToString().TrimEnd();
        }
    }
}
