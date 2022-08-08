using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {

        [Test]
        public void ConstructorShouldAddValidData()
        {
            Gym gym = new Gym("The Matrix", 100);

            Assert.AreEqual("The Matrix", gym.Name);
            Assert.AreEqual(100, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void GymNameNullShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null, 150);
            });
        }

        [Test]
        public void GymNameEmptyShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym("", 150);
            });
        }

        [Test]
        public void SizeNegativeNumberShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("FitnessLine", -1);
            });
        }

        [Test]
        public void AddAthletesCounterShouldWorkProperly()
        {
            Gym gym = new Gym("The Matrix", 100);

            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            gym.AddAthlete(new Athlete("Maria Marinova"));
            gym.AddAthlete(new Athlete("Georgi Petkov"));

            Assert.AreEqual(3, gym.Count);
        }

        [Test]
        public void AddAthletesMoreThanCapacityShouldThrowException()
        {
            Gym gym = new Gym("The Matrix", 2);

            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            gym.AddAthlete(new Athlete("Maria Marinova"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("Georgi Petkov"));
            });
        }

        [Test]
        public void RemoveAthleteCounterShouldWorkProperly()
        {
            Gym gym = new Gym("The Matrix", 100);

            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            gym.AddAthlete(new Athlete("Maria Marinova"));
            gym.AddAthlete(new Athlete("Georgi Petkov"));
            gym.RemoveAthlete("Ivan Ivanov");

            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void RemoveAthleteNullShouldThrowException()
        {
            Gym gym = new Gym("The Matrix", 2);

            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            gym.AddAthlete(new Athlete("Maria Marinova"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Georgi Petkov");
            });
        }

        [Test]
        public void InjureAthleteNullShouldThrowException()
        {
            Gym gym = new Gym("The Matrix", 10);

            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            gym.AddAthlete(new Athlete("Maria Marinova"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Georgi Petkov");
            });
        }

        [Test]
        public void InjureAthleteShouldWorkProperly()
        {
            Gym gym = new Gym("The Matrix", 10);

            Athlete athlete = new Athlete("Georgi Dimitrov");
            Athlete athlete2 = new Athlete("Ivan Ivanov");
            Athlete athlete3 = new Athlete("Maria Marinova");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            gym.InjureAthlete("Maria Marinova");
            Assert.IsTrue(athlete3.IsInjured);
        }

        [Test]
        public void InjureAthleteTwoShouldWorkProperly()
        {
            Gym gym = new Gym("The Matrix", 10);

            Athlete athlete = new Athlete("Georgi Dimitrov");
            Athlete athlete2 = new Athlete("Ivan Ivanov");
            Athlete athlete3 = new Athlete("Maria Marinova");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            gym.InjureAthlete("Maria Marinova");
            Assert.IsFalse(athlete2.IsInjured);
        }

        [Test]
        public void InjureAthleteReturnShouldWorkProperly()
        {
            Gym gym = new Gym("The Matrix", 10);

            Athlete athlete = new Athlete("Georgi Dimitrov");
            Athlete athlete2 = new Athlete("Ivan Ivanov");
            Athlete athlete3 = new Athlete("Maria Marinova");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            Assert.AreEqual(athlete3, gym.InjureAthlete("Maria Marinova"));
        }

        [Test]
        public void ReportShouldWorkProperly()
        {
            Gym gym = new Gym("The Matrix", 10);

            Athlete athlete = new Athlete("Georgi Dimitrov");
            Athlete athlete2 = new Athlete("Ivan Ivanov");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.InjureAthlete("Ivan Ivanov");

            Assert.AreEqual("Active athletes at The Matrix: Georgi Dimitrov", gym.Report());
        }
    }
}
