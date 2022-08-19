using NUnit.Framework;
using System;

namespace Gyms.Tests
{

    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void AthleteCtorShouldWork()
        {
            Athlete athlete = new Athlete("Ivan Ivanov");

            Assert.AreEqual("Ivan Ivanov", athlete.FullName);
            Assert.IsFalse(athlete.IsInjured);
        }

        [Test]
        public void GymCtorShouldWork()
        {
            Gym gym = new Gym("Gym", 100);

            Assert.AreEqual("Gym", gym.Name);
            Assert.AreEqual(100, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void NameNullShouldThrowException()
        {
            string name = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 100);
            });
        }

        [Test]
        public void NameEmptyShouldThrowException()
        {
            string name = string.Empty;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 100);
            });
        }

        [Test]
        public void CapacityNegativeNumberShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Gym", -1);
            });
        }

        [Test]
        public void CounterShouldWork()
        {
            Gym gym = new Gym("Gym", 100);
            Athlete athlete1 = new Athlete("Ivan Ivanov");
            Athlete athlete2 = new Athlete("Ivan Petrov");
            Athlete athlete3 = new Athlete("Pesho Todorov");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            Assert.AreEqual(3, gym.Count);
        }


        [Test]
        public void AddAthleteShouldThrowException()
        {
            Gym gym = new Gym("Gym", 2);
            Athlete athlete1 = new Athlete("Ivan Ivanov");
            Athlete athlete2 = new Athlete("Ivan Petrov");
            Athlete athlete3 = new Athlete("Pesho Todorov");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete3);
            });
        }

        [Test]
        public void RemoveAthleteShouldWork()
        {
            Gym gym = new Gym("Gym", 20);
            Athlete athlete1 = new Athlete("Ivan Ivanov");
            Athlete athlete2 = new Athlete("Ivan Petrov");
            Athlete athlete3 = new Athlete("Pesho Todorov");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.RemoveAthlete("Ivan Ivanov");

            Assert.AreEqual(2, gym.Count);
        }


        [Test]
        public void RemoveAthleteShouldThrowException()
        {
            Gym gym = new Gym("Gym", 20);
            Athlete athlete1 = new Athlete("Ivan Ivanov");
            Athlete athlete2 = new Athlete("Ivan Petrov");
            Athlete athlete3 = new Athlete("Pesho Todorov");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Maria Ivanova");
            });
        }

        [Test]
        public void InjureAthleteShouldWork()
        {
            Gym gym = new Gym("Gym", 20);
            Athlete athlete1 = new Athlete("Ivan Ivanov");
            Athlete athlete2 = new Athlete("Ivan Petrov");
            Athlete athlete3 = new Athlete("Pesho Todorov");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.InjureAthlete("Ivan Ivanov");

            Assert.IsTrue(athlete1.IsInjured);
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
        public void InjureAthleteShouldThrowException()
        {
            Gym gym = new Gym("Gym", 20);
            Athlete athlete1 = new Athlete("Ivan Ivanov");
            Athlete athlete2 = new Athlete("Ivan Petrov");
            Athlete athlete3 = new Athlete("Pesho Todorov");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Maria Ivanova");
            });
        }

        [Test]
        public void ReportShouldWork()
        {
            Gym gym = new Gym("Gym", 20);
            Athlete athlete1 = new Athlete("Ivan Ivanov");
            Athlete athlete2 = new Athlete("Ivan Petrov");
            Athlete athlete3 = new Athlete("Pesho Todorov");

            gym.AddAthlete(athlete1);

            Assert.AreEqual("Active athletes at Gym: Ivan Ivanov", gym.Report());
        }
    }
}
