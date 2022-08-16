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
            public void PlanetConstructorShouldWorkProperly()
            {
                Planet planet = new Planet("Name", 200);

                Assert.AreEqual("Name", planet.Name);
                Assert.AreEqual(200, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            public void PlanetNameNullShouldThrowException()
            {
                string name = null;

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 200);
                });
            }

            [Test]
            public void PlanetNameEmptyShouldThrowException()
            {
                string name = string.Empty;

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 200);
                });
            }

            [Test]
            public void PlanetNameShouldWorkProperly()
            {
                Planet planet = new Planet("Name", 200);

                Assert.AreEqual("Name", planet.Name);
            }

            [Test]
            public void PlanetBudgetShouldWorkProperly()
            {
                Planet planet = new Planet("Name", 200);

                Assert.AreEqual(200, planet.Budget);
            }

            [Test]
            public void PlanetBudgetNegativeNumberShouldThrowException()
            {
                
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Name", -1);
                });
            }

            [Test]
            public void WeaponCtorShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);

                Assert.AreEqual("Glok", weapon.Name);
                Assert.AreEqual(4500, weapon.Price);
                Assert.AreEqual(100, weapon.DestructionLevel);
            }

            [Test]
            public void AddWeaponShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(2, planet.Weapons.Count);
            }

            [Test]
            public void AddWeaponShouldThrowException()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(new Weapon("Glok", 5000, 100));
                });
            }

            [Test]
            public void MilitaryPowerRatioShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(250, planet.MilitaryPowerRatio);
            }

            [Test]
            public void ProfitShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.Profit(200);

                Assert.AreEqual(500, planet.Budget);
            }

            [Test]
            public void SpendFundsShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.SpendFunds(200);

                Assert.AreEqual(100, planet.Budget);
            }

            [Test]
            public void SpendFundsShouldThrowException()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(400);
                });
            }

            [Test]
            public void RemoveWeaponShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon("Glok");

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void RemoveWeaponNullShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon("AnotherGun");

                Assert.AreEqual(2, planet.Weapons.Count);
            }

            [Test]
            public void UpgradeWeaponShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.UpgradeWeapon("Glok");

                Assert.AreEqual(101, weapon.DestructionLevel);
            }

            [Test]
            public void UpgradeWeaponShouldThrowException()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("AnotherGun");
                });
            }

            [Test]
            public void DestructOpponentShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Weapon weapon3 = new Weapon("Glok1", 4500, 100);
                Weapon weapon4 = new Weapon("Kalashnikov1", 9000, 100);

                Planet planet2 = new Planet("Name2", 200);
                planet2.AddWeapon(weapon3);
                planet2.AddWeapon(weapon4);

                Assert.AreEqual($"Name2 is destructed!", planet.DestructOpponent(planet2));
            }

            [Test]
            public void DestructOpponentShouldThrowException()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);
                Weapon weapon2 = new Weapon("Kalashnikov", 9000, 150);

                Planet planet = new Planet("Name", 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Weapon weapon3 = new Weapon("Glok1", 4500, 200);
                Weapon weapon4 = new Weapon("Kalashnikov1", 9000, 200);

                Planet planet2 = new Planet("Name2", 400);
                planet2.AddWeapon(weapon3);
                planet2.AddWeapon(weapon4);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planet2);
                });
            }

            [Test]
            public void WeaponPriceShouldWorkProperly()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);

                Assert.AreEqual(4500, weapon.Price);
            }

            [Test]
            public void WeaponPriceShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Glok", -1, 100);
                });
            }

            [Test]
            public void IsNuclearWeaponTrue()
            {
                Weapon weapon = new Weapon("Glok", 4500, 100);

                Assert.IsTrue(weapon.IsNuclear);
            }

            [Test]
            public void IsNuclearWeaponFalse()
            {
                Weapon weapon = new Weapon("Glok", 4500, 5);

                Assert.IsFalse(weapon.IsNuclear);
            }

        }
    }
}
