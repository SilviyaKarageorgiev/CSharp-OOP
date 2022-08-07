using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {

        private readonly VesselRepository vessels;
        private readonly List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            var vessel = vessels.FindByName(selectedVesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vessels.FindByName(attackingVesselName);
            var defendingVessel = vessels.FindByName(defendingVesselName);

            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defendingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.FirstOrDefault(x => x.FullName == captainFullName);
            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, captainFullName);
            }

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (captains.Any(x => x.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            captains.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel;

            if (vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return string.Format(OutputMessages.InvalidVesselType);
            }

            vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            
            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            
            var vessel = vessels.FindByName(vesselName);

            if (vessel != null && vessel.GetType().Name == nameof(Submarine))
            {
                Submarine submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();

                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
            else if (vessel != null && vessel.GetType().Name == nameof(Battleship))
            {
                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();

                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            return vessel.ToString();
        }
    }
}
