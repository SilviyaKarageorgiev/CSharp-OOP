using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {

        private bool sonarMode = false;
        private double BattleshipArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : base(name, mainWeaponCaliber, speed, armorThickness)
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
            throw new System.NotImplementedException();
        }

        public void ToggleSonarMode()
        {

        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
