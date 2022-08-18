using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {

        [TestFixture]
        public class RepairsShopTests
        {

            [Test]
            public void CarCtorShouldWork()
            {
                Car car = new Car("ML", 3);

                Assert.AreEqual("ML", car.CarModel);
                Assert.AreEqual(3, car.NumberOfIssues);
            }

            [Test]
            public void CarIsFixedFalseShouldWork()
            {
                Car car = new Car("ML", 3);

                Assert.IsFalse(car.IsFixed);
            }

            [Test]
            public void CarIsFixedTrueShouldWork()
            {
                Car car = new Car("ML", 0);

                Assert.IsTrue(car.IsFixed);
            }

            [Test]
            public void GarageCtorShouldWork()
            {
                Garage garage = new Garage("CarService", 5);

                Assert.AreEqual("CarService", garage.Name);
                Assert.AreEqual(5, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void GarageNameEmptyShouldThrowException()
            {
                string name = string.Empty;

                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, 5);
                });
            }

            [Test]
            public void GarageNameNullShouldThrowException()
            {
                string name = null;

                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, 5);
                });
            }

            [Test]
            public void GarageMechanicsAvailableShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("CarService", 0);
                });
            }

            [Test]
            public void GarageCarsInGarageShouldWork()
            {
                Car car1 = new Car("Astra", 2);
                Car car2 = new Car("ML", 1);

                Garage garage = new Garage("Service", 5);
                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.AreEqual(2, garage.CarsInGarage);
            }

            [Test]
            public void GarageAddCarShouldThrowException()
            {
                Car car1 = new Car("Astra", 2);
                Car car2 = new Car("ML", 1);

                Garage garage = new Garage("Service", 2);
                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(new Car("GLS", 1));
                });
            }

            [Test]
            public void GarageFixCarShouldWork()
            {
                Car car1 = new Car("Astra", 2);
                Car car2 = new Car("ML", 1);

                Garage garage = new Garage("Service", 2);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.FixCar("ML");

                Assert.AreEqual(0, car2.NumberOfIssues);
            }

            [Test]
            public void GarageFixCarShouldThrowException()
            {
                Car car1 = new Car("Astra", 2);
                Car car2 = new Car("ML", 1);

                Garage garage = new Garage("Service", 2);
                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("GLS");
                });
            }

            [Test]
            public void GarageRemoveFixedCarShouldWork()
            {
                Car car1 = new Car("Astra", 2);
                Car car2 = new Car("ML", 1);

                Garage garage = new Garage("Service", 2);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.FixCar("ML");
                garage.RemoveFixedCar();

                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void GarageRemoveFixedCarShouldThrowException()
            {
                Car car1 = new Car("Astra", 2);
                Car car2 = new Car("ML", 1);

                Garage garage = new Garage("Service", 2);
                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }
        }
    }
}