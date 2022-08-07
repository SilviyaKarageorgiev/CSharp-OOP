using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;

            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym gym = gyms.First(x => x.Name == gymName);
            string gymType = gym.GetType().Name;

            if (athleteType == nameof(Boxer) && gym.GetType().Name != nameof(BoxingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }
            else if (athleteType == nameof(Weightlifter) && gym.GetType().Name != nameof(WeightliftingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

            gym.AddAthlete(athlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equip;

            if (equipmentType == nameof(BoxingGloves))
            {
                equip = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equip = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipment.Add(equip);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.First(x => x.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equip = equipment.FindByType(equipmentType);

            if (equip == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            var gym = gyms.First(x => x.Name == gymName);

            gym.AddEquipment(equip);
            equipment.Remove(equip);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.First(x => x.Name == gymName);
            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
