using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void SmartphoneCtorShouldWork()
        {
            Smartphone phone = new Smartphone("iPhone", 95);

            Assert.AreEqual("iPhone", phone.ModelName);
            Assert.AreEqual(95, phone.MaximumBatteryCharge);
            Assert.AreEqual(95, phone.CurrentBateryCharge);
        }

        [Test]
        public void ShopCtorShouldWork()
        {
            Shop phonesShop = new Shop(20);

            Assert.AreEqual(20, phonesShop.Capacity);
            Assert.AreEqual(0, phonesShop.Count);
        }

        [Test]
        public void CapacityWithNegativeNumShoulsThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop phonesShop = new Shop(-1);
            });
        }

        [Test]
        public void AddPhonesShouldWork()
        {
            Shop phonesShop = new Shop(20);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);

            Assert.AreEqual(2, phonesShop.Count);
        }

        [Test]
        public void AddPhoneThatExistShouldThrowException()
        {
            Shop phonesShop = new Shop(20);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                phonesShop.Add(new Smartphone("Nokia", 90));
            });
        }

        [Test]
        public void AddPhoneFullCapacityShouldThrowException()
        {
            Shop phonesShop = new Shop(2);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                phonesShop.Add(new Smartphone("iPhone", 98));
            });
        }

        [Test]
        public void RemovePhoneShouldWork()
        {
            Shop phonesShop = new Shop(20);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);

            phonesShop.Remove("Nokia");
            Assert.AreEqual(1, phonesShop.Count);
        }

        [Test]
        public void RemovePhoneNotExistShouldThrowException()
        {
            Shop phonesShop = new Shop(20);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                phonesShop.Remove("iPhone");
            });
        }

        [Test]
        public void TestPhoneShouldWork()
        {
            Shop phonesShop = new Shop(20);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);

            phonesShop.TestPhone("Nokia", 80);

            Assert.AreEqual(10, phone1.CurrentBateryCharge);
        }

        [Test]
        public void TestPhoneLowerBatteryShouldThrowException()
        {
            Shop phonesShop = new Shop(20);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                phonesShop.TestPhone("Nokia", 95);
            });
        }

        [Test]
        public void TestPhoneNotExistShouldThrowException()
        {
            Shop phonesShop = new Shop(20);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                phonesShop.TestPhone("iPhone", 95);
            });
        }

        [Test]
        public void ChargePhoneShouldWork()
        {
            Shop phonesShop = new Shop(20);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);
            phonesShop.TestPhone("Nokia", 20);

            phonesShop.ChargePhone("Nokia");

            Assert.AreEqual(90, phone1.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneNotExistShouldThrowException()
        {
            Shop phonesShop = new Shop(20);
            Smartphone phone1 = new Smartphone("Nokia", 90);
            Smartphone phone2 = new Smartphone("Alcatel", 88);

            phonesShop.Add(phone1);
            phonesShop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                phonesShop.ChargePhone("iPhone");
            });
        }
    }
}