using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double armorThickness = 200;
        private bool submergeMode = false;

        public Submarine(string name, double mainWeaponCaliber, double speed)
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
            if (this.ArmorThickness < armorThickness)
            {
                this.ArmorThickness = armorThickness;
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
            string submergeModeString = this.SubmergeMode == true ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {submergeModeString}");

            return sb.ToString().TrimEnd();
        }
    }
}
