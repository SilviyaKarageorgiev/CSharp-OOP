namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {

        [Test]
        public void RobotConstructorShouldWorkProperly()
        {
            Robot robot = new Robot("Rob", 100);

            Assert.AreEqual("Rob", robot.Name);
            Assert.AreEqual(100, robot.MaximumBattery);
            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void RobotManagerConstructorShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(30);

            Assert.AreEqual(0, robotManager.Count);
            Assert.AreEqual(30, robotManager.Capacity);
        }

        [Test]
        public void RobotManagerNegativeCapacityShouldThrowException()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-1);
            });
        }

        [Test]
        public void RobotManagerCounterShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(30);
            robotManager.Add(new Robot("Bob", 99));
            robotManager.Add(new Robot("Rob", 98));

            Assert.AreEqual(2, robotManager.Count);
        }

        [Test]
        public void RobotManagerAddExistingRobotShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(30);
            robotManager.Add(new Robot("Bob", 99));
            robotManager.Add(new Robot("Rob", 98));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Rob", 98));
            });
        }

        [Test]
        public void RobotManagerAddRobotFullCapacityShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(new Robot("Bob", 99));
            robotManager.Add(new Robot("Rob", 98));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Mob", 97));
            });
        }

        [Test]
        public void RobotManagerRemoveCounterShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(30);
            robotManager.Add(new Robot("Bob", 99));
            robotManager.Add(new Robot("Rob", 98));
            robotManager.Add(new Robot("Mob", 97));

            robotManager.Remove("Bob");
            Assert.AreEqual(2, robotManager.Count);
        }

        [Test]
        public void RobotManagerRemoveNullShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(30);
            robotManager.Add(new Robot("Bob", 99));
            robotManager.Add(new Robot("Rob", 98));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Mob");
            });
        }

        [Test]
        public void RobotManagerWorkNullShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(30);

            Robot robot1 = new Robot("Bob", 99);
            Robot robot2 = new Robot("Rob", 98);
            Robot robot3 = new Robot("Mob", 97);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Mob", "reading", 90);
            });
        }

        [Test]
        public void RobotManagerWorkLowBatteryShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(30);

            Robot robot1 = new Robot("Bob", 99);
            Robot robot2 = new Robot("Rob", 98);
            Robot robot3 = new Robot("Mob", 80);

            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Add(robot3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Mob", "reading", 90);
            });
        }

        [Test]
        public void RobotManagerWorkBatteryShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(30);

            Robot robot1 = new Robot("Bob", 99);
            Robot robot2 = new Robot("Rob", 98);
            Robot robot3 = new Robot("Mob", 97);

            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Add(robot3);
            robotManager.Work("Mob", "reading", 90);

            Assert.AreEqual(7, robot3.Battery);
        }

        [Test]
        public void RobotManagerChargeBatteryShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(30);

            Robot robot1 = new Robot("Bob", 99);
            Robot robot2 = new Robot("Rob", 98);
            Robot robot3 = new Robot("Mob", 97);

            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Add(robot3);
            robotManager.Work("Mob", "reading", 90);
            robotManager.Charge("Mob");

            Assert.AreEqual(97, robot3.Battery);
        }

        [Test]
        public void RobotManagerChargeNullShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(30);

            Robot robot1 = new Robot("Bob", 99);
            Robot robot2 = new Robot("Rob", 98);

            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Mob");
            });
        }
    }
}
