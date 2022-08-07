using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {

        private bool sonarMode = false;
        private const double BattleshipArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, BattleshipArmorThickness)
        {

        }

        public bool SonarMode
        {
            get
            {
                return this.sonarMode;
            }
            private set
            {
                this.sonarMode = value;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < BattleshipArmorThickness)
            {
                this.ArmorThickness = BattleshipArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;

                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;

                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }


        public override string ToString()
        {
            string currSonarMode = string.Empty;
            if (this.sonarMode == true)
            {
                currSonarMode = "ON";
            }
            else
            {
                currSonarMode = "OFF";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {currSonarMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
