using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HotelCtorShouldWorkProperly()
        {

            Hotel hotel = new Hotel("Astor", 5);

            Assert.AreEqual("Astor", hotel.FullName);
            Assert.AreEqual(5, hotel.Category);
            Assert.AreEqual(0, hotel.Rooms.Count);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [Test]
        public void NameNullShouldThrowException()
        {
            string name = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(name, 5);

            });
        }

        [Test]
        public void NameWhiteSpaceShouldThrowException()
        {
            string name = " ";

            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(name, 5);

            });
        }

        [Test]
        public void CategoryLessShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Astor", 0);
            });
        }

        [Test]
        public void CategoryMoreShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Astor", 6);
            });
        }

        [Test]
        public void AddRoomShouldWorkProperly()
        {
            Hotel hotel = new Hotel("Astor", 5);

            hotel.AddRoom(new Room(1, 200));
            hotel.AddRoom(new Room(2, 290));

            Assert.AreEqual(2, hotel.Rooms.Count);
        }

        [Test]
        public void BookingShouldWorkProperly()
        {
            Hotel hotel = new Hotel("Astor", 5);

            hotel.AddRoom(new Room(1, 200));
            hotel.AddRoom(new Room(2, 290));

            hotel.BookRoom(2, 0, 3, 1000);

            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void BookingRoomShouldWorkProperly()
        {
            Hotel hotel = new Hotel("Astor", 5);

            hotel.AddRoom(new Room(1, 200));
            hotel.AddRoom(new Room(2, 300));

            hotel.BookRoom(2, 0, 3, 1000);

            Assert.AreEqual(900, hotel.Turnover);
        }

        [Test]
        public void AdultsZeroShouldThrowException()
        {
            Hotel hotel = new Hotel("Astor", 5);

            hotel.AddRoom(new Room(1, 200));
            hotel.AddRoom(new Room(2, 300));

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(0, 0, 3, 1000);
            });
        }

        [Test]
        public void ChildrenNegativeNumShouldThrowException()
        {
            Hotel hotel = new Hotel("Astor", 5);

            hotel.AddRoom(new Room(1, 200));
            hotel.AddRoom(new Room(2, 300));

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, -1, 3, 1000);
            });
        }

        [Test]
        public void NightsZeroShouldThrowException()
        {
            Hotel hotel = new Hotel("Astor", 5);

            hotel.AddRoom(new Room(1, 200));
            hotel.AddRoom(new Room(2, 300));

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, 1, 0, 1000);
            });
        }
    }
}