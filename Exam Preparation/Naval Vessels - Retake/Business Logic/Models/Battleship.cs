using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double armorThickness = 300;
        private bool sonarMode = false;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
        }

        public bool SonarMode
        {
            get => sonarMode;
            private set
            {
                sonarMode = value;
            }
        }
        public override void RepairVessel()
        {
            if (this.ArmorThickness < armorThickness)
            {
                this.ArmorThickness = armorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode == true)
            {
                SonarMode = false;

                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                SonarMode = true;

                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }

        }

        public override string ToString()
        {
            string sonarModeString = this.SonarMode == true ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {sonarModeString}");

            return sb.ToString().TrimEnd();
        }
    }
}
