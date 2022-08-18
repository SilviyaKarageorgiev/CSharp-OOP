using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

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
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                captain = value;
            }
        }
        public double ArmorThickness
        {
            get => armorThickness;
            set
            {
                armorThickness = value;
            }
        }

        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set
            {
                mainWeaponCaliber = value;
            }
        }

        public double Speed
        {
            get => speed;
            protected set
            {
                speed = value;
            }
        }

        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            string targetsString = this.Targets.Count > 0 ? string.Join(", ", Targets) : "None";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            sb.AppendLine($" *Targets: {targetsString}");

            return sb.ToString().TrimEnd();
        }
    }
}
