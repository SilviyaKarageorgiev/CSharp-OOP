using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {

            [Test]
            public void ConstructorShouldWorkProperly()
            {
                Garage garage = new Garage("SilverStar", 15);

                Assert.AreEqual("SilverStar", garage.Name);
                Assert.AreEqual(15, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void NameOfGarageIfEmptyShouldReturnException()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage("", 15);
                }, "Invalid garage name.");       

            }
            
            [Test]
            public void NameOfGarageIfNullShouldReturnException()
            {
                string name = null;

                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, 15);
                }, "Invalid garage name.");

            }

            [Test]
            public void MechanicsAvailableIfZeroShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("SilverStar", 0);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void MechanicsAvailableIfNegativeShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("SilverStar", -1);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void CarsInGarageCounterWithNoCarsShouldWorkProperly()
            {
                Garage garage = new Garage("SilverStar", 5);

                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void AddCarCarsInGarageCounterShouldWorkProperly()
            {
                Garage garage = new Garage("SilverStar", 5);

                garage.AddCar(new Car("Mercedes", 2));

                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void CarsInGarageIfIsEqualToNumberOfMechanicsShouldThrowException()
            {
                Garage garage = new Garage("SilverStar", 1);

                garage.AddCar(new Car("Mercedes", 2));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(new Car("BMW", 1));
                }, "No mechanic available.");
            }

            [Test]
            public void FixCarValidDataShouldWorkProperly()
            {
                Garage garage = new Garage("SilverStar", 2);

                Car car = new Car("Maybach", 1);
                garage.AddCar(car);
                garage.FixCar("Maybach");

                Assert.AreEqual(0, car.NumberOfIssues);
            }

            [Test]
            public void FixCarNotValidDataShouldThrowException()
            {
                Garage garage = new Garage("SilverStar", 2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Maybach");
                });
            }

            [Test]
            public void RemoveFixedCarValidDataShouldWorkProperly()
            {
                Garage garage = new Garage("SilverStar", 2);
                Car car = new Car("Maybach", 1);
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                garage.RemoveFixedCar();

                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void RemoveFixedCarIfThereIsNoCarsToRemoveShouldThrowException()
            {
                Garage garage = new Garage("SilverStar", 2);
                Car car = new Car("Maybach", 1);
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                garage.RemoveFixedCar();

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, "No fixed cars available.");
            }
        }
    }
}