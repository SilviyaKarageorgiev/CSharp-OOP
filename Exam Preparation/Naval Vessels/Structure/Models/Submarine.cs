using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {

        private bool submergeMode = false;
        private double SubmarineArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {

        }

        public bool SubmergeMode
        {
            get
            {
                return this.submergeMode;
            }
            private set
            {
                this.submergeMode = value;
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
