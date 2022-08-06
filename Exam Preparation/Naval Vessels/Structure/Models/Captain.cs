using NavalVessels.Models.Contracts;
using System.Collections.Generic;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private readonly ICollection<IVessel> vessels;

        public Captain(string fullName)
        {

        }

        public string FullName => throw new System.NotImplementedException();

        public int CombatExperience => throw new System.NotImplementedException();

        public ICollection<IVessel> Vessels => throw new System.NotImplementedException();

        public void AddVessel(IVessel vessel)
        {
            throw new System.NotImplementedException();
        }

        public void IncreaseCombatExperience()
        {
            throw new System.NotImplementedException();
        }

        public string Report()
        {
            throw new System.NotImplementedException();
        }

    }
}
