using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
        private readonly ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.vessels = new List<IVessel>();
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidCaptainName));
                }

                this.fullName = value;
            }
        }

        public int CombatExperience
        {
            get
            {
                return this.combatExperience;
            }
            private set
            {
                if (value % 10 == 0)
                {
                    this.combatExperience = value;
                }
            }
        }

        public ICollection<IVessel> Vessels
        {
            get
            {
                return this.vessels;
            }
        }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidVesselForCaptain));
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            if (vessels.Count > 0)
            {
                foreach (var vessel in vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
