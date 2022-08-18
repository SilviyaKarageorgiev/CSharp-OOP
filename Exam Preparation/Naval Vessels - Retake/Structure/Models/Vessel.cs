using NavalVessels.Models.Contracts;
using System.Collections.Generic;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private readonly ICollection<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {

        }

        public string Name => throw new System.NotImplementedException();

        public ICaptain Captain { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public double ArmorThickness { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public double MainWeaponCaliber => throw new System.NotImplementedException();

        public double Speed => throw new System.NotImplementedException();

        public ICollection<string> Targets => throw new System.NotImplementedException();

        public void Attack(IVessel target)
        {
            throw new System.NotImplementedException();
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
