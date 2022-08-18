using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double armorThickness = 300;
        private bool sonarMode = false;

        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness)
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
