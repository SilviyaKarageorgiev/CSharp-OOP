using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double armorThickness = 200;
        private bool submergeMode = false;

        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
        }


        public bool SubmergeMode
        {
            get => submergeMode;
            private set
            {
                submergeMode = value;
            }
        }

        public override void RepairVessel()
        {
            throw new System.NotImplementedException();
        }

        public void ToggleSubmergeMode()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
