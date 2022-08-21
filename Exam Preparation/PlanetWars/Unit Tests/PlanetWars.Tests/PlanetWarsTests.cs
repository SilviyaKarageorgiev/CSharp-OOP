using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponCtorShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 3600, 50);

                Assert.AreEqual("Glok", weapon.Name);
                Assert.AreEqual(3600, weapon.Price);
                Assert.AreEqual(50, weapon.DestructionLevel);
            }

            [Test]
            public void WeaponPriceShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Glok", -50, 50);
                });
            }

            [Test]
            public void IncreaseDistructionLevelShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 3600, 50);
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(52, weapon.DestructionLevel);
            }

            [Test]
            public void IsNuclearTrueShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 3600, 50);

                Assert.IsTrue(weapon.IsNuclear);
            }

            [Test]
            public void IsNuclearFalseShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 3600, 5);

                Assert.IsFalse(weapon.IsNuclear);
            }

            [Test]
            public void PlanetCtorShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 5000);

                Assert.AreEqual("Mars", planet.Name);
                Assert.AreEqual(5000, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            public void PlanetNameNullShouldThrowException()
            {
                string name = null;

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 5000);
                });
            }

            [Test]
            public void BudgetNegativeNumberShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Mars", -1);
                });
            }

            [Test]
            public void PlanetWeaponCounterShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 5000);
                Weapon weapon1 = new Weapon("Glok", 3600, 50);
                Weapon weapon2 = new Weapon("Kalashnikov", 8000, 68);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(2, planet.Weapons.Count);
            }

            [Test]
            public void MilitaryPowerRatioShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 5000);
                Weapon weapon1 = new Weapon("Glok", 3600, 50);
                Weapon weapon2 = new Weapon("Kalashnikov", 8000, 68);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(118, planet.MilitaryPowerRatio);
            }

            [Test]
            public void ProfitShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 5000);
                planet.Profit(1000);

                Assert.AreEqual(6000, planet.Budget);
            }

            [Test]
            public void SpendFundsShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 5000);
                planet.SpendFunds(1000);

                Assert.AreEqual(4000, planet.Budget);
            }

            [Test]
            public void SpendFundsShouldThrowException()
            {
                Planet planet = new Planet("Mars", 5000);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(5500);
                });
            }

            [Test]
            public void AddWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 5000);
                Weapon weapon1 = new Weapon("Glok", 3600, 50);
                Weapon weapon2 = new Weapon("Kalashnikov", 8000, 68);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(2, planet.Weapons.Count);
            }

            [Test]
            public void AddWeaponShouldThrowException()
            {
                Planet planet = new Planet("Mars", 5000);
                Weapon weapon1 = new Weapon("Glok", 3600, 50);
                Weapon weapon2 = new Weapon("Kalashnikov", 8000, 68);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(new Weapon("Glok", 5000, 60));
                });
            }

            [Test]
            public void RemoveWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 5000);
                Weapon weapon1 = new Weapon("Glok", 3600, 50);
                Weapon weapon2 = new Weapon("Kalashnikov", 8000, 68);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon("Glok");

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void UpgradeWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 5000);
                Weapon weapon1 = new Weapon("Glok", 3600, 50);
                Weapon weapon2 = new Weapon("Kalashnikov", 8000, 68);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.UpgradeWeapon("Glok");

                Assert.AreEqual(51, weapon1.DestructionLevel);
            }

            [Test]
            public void UpgradeWeaponShouldThrowException()
            {
                Planet planet = new Planet("Mars", 5000);
                Weapon weapon1 = new Weapon("Glok", 3600, 50);
                Weapon weapon2 = new Weapon("Kalashnikov", 8000, 68);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Some weapon");
                });
            }

            [Test]
            public void DestructOpponentShouldWorkProperly()
            {
                Planet planet1 = new Planet("Mars", 5000);
                Planet planet2 = new Planet("Saturn", 6000);

                Weapon weapon1 = new Weapon("Glok", 3600, 50);
                Weapon weapon2 = new Weapon("Kalashnikov", 8000, 68);

                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                Assert.AreEqual("Mars is destructed!", planet2.DestructOpponent(planet1));
            }

            [Test]
            public void DestructOpponentShouldThrowException()
            {
                Planet planet1 = new Planet("Mars", 5000);
                Planet planet2 = new Planet("Saturn", 6000);

                Weapon weapon1 = new Weapon("Glok", 3600, 50);
                Weapon weapon2 = new Weapon("Kalashnikov", 8000, 68);

                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet1.DestructOpponent(planet2);
                });
            }
        }
    }
}
