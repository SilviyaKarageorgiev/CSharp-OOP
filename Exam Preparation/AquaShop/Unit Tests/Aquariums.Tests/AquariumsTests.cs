namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    [TestFixture]
    public class AquariumsTests
    {

        [Test]
        public void FishConstructorWithValidShouldWorkProperly()
        {
            Fish fish = new Fish("Nemo");

            Assert.AreEqual("Nemo", fish.Name);
            Assert.IsTrue(fish.Available);
        }

        [Test]
        public void AquariumConstructorWithValidShouldWorkProperly()
        {
            Aquarium aqua = new Aquarium("Florya", 350);

            Assert.AreEqual("Florya", aqua.Name);
            Assert.AreEqual(350, aqua.Capacity);
            Assert.AreEqual(0, aqua.Count);
        }

        [Test]
        public void AquariumValidNameShouldWorkProperly()
        {
            Aquarium aqua = new Aquarium("Florya", 350);

            Assert.AreEqual("Florya", aqua.Name);
        }

        [Test]
        public void AquariumNullNameShouldThrowException()
        {
            string name = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aqua = new Aquarium(name, 350);
            });
        }

        [Test]
        public void AquariumEmptyNameShouldThrowException()
        {
            string name = string.Empty;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aqua = new Aquarium(name, 350);
            });
        }

        [Test]
        public void AquariumValidDataCapacityShouldWorkProperly()
        {
            Aquarium aqua = new Aquarium("Florya", 350);

            Assert.AreEqual(350, aqua.Capacity);
        }

        [Test]
        public void AquariumNegativeNumCapacityShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aqua = new Aquarium("Florya", -1);
            });
        }

        [Test]
        public void AquariumCounterShouldWorkProperty()
        {
            Aquarium aqua = new Aquarium("Florya", 350);
            
            aqua.Add(new Fish("Nemo"));
            aqua.Add(new Fish("Alfemo"));

            Assert.AreEqual(2, aqua.Count);
        }

        [Test]
        public void AddFishToAquariumWithFullCapacityShouldThrowException()
        {
            Aquarium aqua = new Aquarium("Florya", 2);

            aqua.Add(new Fish("Nemo"));
            aqua.Add(new Fish("Alfemo"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aqua.Add(new Fish("Kaya"));
            });
        }

        [Test]
        public void RemoveFishShouldWorkProperly()
        {
            Aquarium aqua = new Aquarium("Florya", 2);

            aqua.Add(new Fish("Nemo"));
            aqua.Add(new Fish("Alfemo"));
            Fish fish = new Fish("Kaya");

            aqua.RemoveFish("Nemo");

            Assert.AreEqual(1, aqua.Count);
            Assert.True(fish.Available);
        }

        [Test]
        public void RemoveFishDoNotExistShouldThrowException()
        {
            Aquarium aqua = new Aquarium("Florya", 200);

            aqua.Add(new Fish("Nemo"));
            aqua.Add(new Fish("Alfemo"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aqua.RemoveFish("Kaya");
            });
        }

        [Test]
        public void SellFishAvailableShouldWorkProperly()
        {
            Aquarium aqua = new Aquarium("Florya", 200);

            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Alfemo");

            aqua.Add(fish1);
            aqua.Add(fish2);

            aqua.SellFish("Nemo");

            Assert.IsFalse(fish1.Available);
            Assert.IsTrue(fish2.Available);
        }

        [Test]
        public void SellFishShouldReturnProperly()
        {
            Aquarium aqua = new Aquarium("Florya", 200);

            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Alfemo");

            aqua.Add(fish1);
            aqua.Add(fish2);

            Fish wantedFish = aqua.SellFish("Nemo");

            Assert.AreEqual("Nemo", wantedFish.Name);
        }

        [Test]
        public void SellFishDoNotExistShouldThrowException()
        {
            Aquarium aqua = new Aquarium("Florya", 200);

            aqua.Add(new Fish("Nemo"));
            aqua.Add(new Fish("Alfemo"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aqua.SellFish("Kaya");
            });
        }

        [Test]
        public void AquariumReportShouldWorkProperly()
        {
            Aquarium aqua = new Aquarium("Florya", 200);

            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Alfemo");
            Fish fish3 = new Fish("Kaya");

            aqua.Add(fish1);
            aqua.Add(fish2);
            aqua.Add(fish3);

            Assert.AreEqual("Fish available at Florya: Nemo, Alfemo, Kaya", aqua.Report());
        }
    }
}
