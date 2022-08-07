using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {

        private bool submergeMode = false;
        private const double SubmarineArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, SubmarineArmorThickness)
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
            if (this.ArmorThickness < SubmarineArmorThickness)
            {
                this.ArmorThickness = SubmarineArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.SubmergeMode = true;

                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.SubmergeMode = false;

                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }


        public override string ToString()
        {
            string currSubmergeMode = string.Empty;
            if (this.submergeMode == true)
            {
                currSubmergeMode = "ON";
            }
            else
            {
                currSubmergeMode = "OFF";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {currSubmergeMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
