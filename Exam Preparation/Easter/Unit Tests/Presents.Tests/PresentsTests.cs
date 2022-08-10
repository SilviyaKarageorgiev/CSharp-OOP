namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {

        [Test]
        public void PresentConstructorShouldWorkProperly()
        {
            Present present = new Present("Gift", 10.5);

            Assert.AreEqual("Gift", present.Name);
            Assert.AreEqual(10.5, present.Magic);
        }

        [Test]
        public void BagConstructorShouldWorkProperly()
        {
            Bag bag = new Bag();

            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void CreateBagValidDataShouldWorkProperly()
        {
            Bag bag = new Bag();
            bag.Create(new Present("Gift1", 20.6));
            bag.Create(new Present("Gift2", 15.3));

            Assert.AreEqual(2, bag.GetPresents().Count);
        }

        [Test]
        public void CreateBagNullPresentShouldThrowException()
        {
            Bag bag = new Bag();
            Present present = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void CreateBagExistingPresentShouldThrowException()
        {
            Bag bag = new Bag();
            Present present = new Present("Gift", 20.9);
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void RemovePresentFromBagShouldReturnTrue()
        {
            Bag bag = new Bag();
            Present present1 = new Present("Gift1", 25.9);
            Present present2 = new Present("Gift2", 19.6);
            bag.Create(present1);
            bag.Create(present2);

            Assert.IsTrue(bag.Remove(present1));
            Assert.AreEqual(1, bag.GetPresents().Count);
        }

        [Test]
        public void RemovePresentFromBagShouldReturnFalse()
        {
            Bag bag = new Bag();
            Present present1 = new Present("Gift1", 25.9);
            Present present2 = new Present("Gift2", 19.6);
            bag.Create(present1);

            Assert.IsFalse(bag.Remove(present2));
            Assert.AreEqual(1, bag.GetPresents().Count);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldWorkProperly()
        {
            Bag bag = new Bag();
            Present present1 = new Present("Gift1", 25.9);
            Present present2 = new Present("Gift2", 19.6);
            Present present3 = new Present("Gift3", 33.5);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            Assert.AreEqual(present2, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresentShouldWorkProperly()
        {
            Bag bag = new Bag();
            Present present1 = new Present("Gift1", 25.9);
            Present present2 = new Present("Gift2", 19.6);
            Present present3 = new Present("Gift3", 33.5);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            Assert.AreEqual(present1, bag.GetPresent("Gift1"));
        }
    }
}
