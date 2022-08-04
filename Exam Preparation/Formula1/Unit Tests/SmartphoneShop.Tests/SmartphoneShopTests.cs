using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {

        [Test]
        public void CapacityWithValidValueShouldWorkProperly()
        {
            Shop shop = new Shop(200);

            Assert.AreEqual(200, shop.Capacity);
        }

        [Test]
        public void CapacityWithNotvalidValueShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-1);
            }, "Invalid capacity.");
        }

        [Test]
        public void CounterWithValidValueShouldWorkProperly()
        {
            Shop shop = new Shop(200);
            shop.Add(new Smartphone("iPhone", 95));
            shop.Add(new Smartphone("Nokia", 97));

            Assert.AreEqual(2, shop.Count);
        }

        [Test]
        public void AddPhoneWithSameNameShouldThrowException()
        {
            Shop shop = new Shop(200);
            shop.Add(new Smartphone("iPhone", 95));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("iPhone", 96));
            });
        }

        [Test]
        public void AddPhoneToShopWithFullCapacityShouldThrowException()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("iPhone", 95));
            shop.Add(new Smartphone("Nokia", 97));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Alcatel", 93));
            });
        }

        [Test]
        public void RemovePhoneWithValidDataCounterShouldWorkProperly()
        {
            Shop shop = new Shop(200);
            shop.Add(new Smartphone("iPhone", 95));
            shop.Add(new Smartphone("Nokia", 97));
            shop.Add(new Smartphone("Alcatel", 93));
            shop.Remove("Nokia");

            Assert.AreEqual(2, shop.Count);
        }

        [Test]
        public void RemovePhoneWhichDoesntExistShouldThrowException()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("iPhone", 95));
            shop.Add(new Smartphone("Nokia", 97));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Alcatel");
            });
        }

        [Test]
        public void TestPhoneWhichDoesntExistShouldThrowException()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("iPhone", 95));
            shop.Add(new Smartphone("Nokia", 97));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Alcatel", 50);
            });
        }

        [Test]
        public void TestPhoneLowerBatteryChargeShouldThrowException()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("iPhone", 85));
            shop.Add(new Smartphone("Nokia", 90));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Nokia", 95);
            });
        }

        [Test]
        public void TestPhoneShouldReduceBatteryChargeProperly()
        {
            Shop shop = new Shop(2);
            Smartphone phone = new Smartphone("iPhone", 85);
            shop.Add(phone);

            shop.TestPhone("iPhone", 15);

            Assert.AreEqual(70, phone.CurrentBateryCharge);
        }

        [Test]
        public void TestPhoneShouldReduceChargeOfTestedPhone()
        {
            var shop = new Shop(2);

            shop.Add(new Smartphone("Nokia", 78));
            shop.Add(new Smartphone("Iphone", 38));

            shop.TestPhone("Iphone", 31);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Iphone", 8);
            });
        }

        [Test]
        public void ChargePhoneWhichDoesntExistShouldThrowException()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("iPhone", 95));
            shop.Add(new Smartphone("Nokia", 97));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Alcatel");
            });
        }

        [Test]
        public void ChargePhoneShouldChangeBatteryChargeProperly()
        {
            Shop shop = new Shop(2);
            Smartphone phone = new Smartphone("iPhone", 99);
            shop.Add(phone);

            shop.ChargePhone("iPhone");

            Assert.AreEqual(99, phone.MaximumBatteryCharge);
        }


        [Test]
        public void ChargePhoneShouldReturnBatteryProperly()
        {
            Shop shop = new Shop(2);
            Smartphone phone = new Smartphone("iPhone", 99);
            shop.Add(phone);

            shop.TestPhone("iPhone", 46);

            shop.ChargePhone("iPhone");

            shop.TestPhone("iPhone", 96);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("iPhone", 4));
        }

    }
}