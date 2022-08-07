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

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.targets = new List<string>();
            captain = null;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get
            {
                return this.captain;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }

                this.captain = value;
            }
        }
        public double ArmorThickness
        {
            get
            {
                return this.armorThickness;
            }
            set
            {
                this.armorThickness = value;
            }
        }

        public double MainWeaponCaliber
        {
            get
            {
                return this.mainWeaponCaliber;
            }
            protected set
            {
                this.mainWeaponCaliber = value;
            }
        }

        public double Speed
        {
            get
            {
                return this.speed;
            }
            protected set
            {
                this.speed = value;
            }
        }

        public ICollection<string> Targets
        {
            get
            {
                return this.targets;
            }
        }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            this.targets.Add(target.Name);

            Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();

        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            if (targets.Count == 0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(", ", targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
