namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {

        [Test]
        public void MakeOfCarShouldBeValid()
        {
            Car car = new Car("Mercedes", "GLS", 0.8, 70);
            Assert.AreEqual("Mercedes", car.Make);
        }

        [Test]
        public void MakeOfCarNullOrEmptyShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("", "GLS", 0.8, 70);
            }, "Make cannot be null or empty!");
        }

        [Test]
        public void ModelOfCarShouldBeValid()
        {
            Car car = new Car("Mercedes", "GLS", 0.8, 70);
            Assert.AreEqual("GLS", car.Model);
        }

        [Test]
        public void ModelOfCarNullOrEmptyShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mercedes", "", 0.8, 70);
            }, "Model cannot be null or empty!");
        }

        [Test]
        public void FuelConsumptionShouldBeValid()
        {
            Car car = new Car("Mercedes", "GLS", 0.8, 70);
            Assert.AreEqual(0.8, car.FuelConsumption);
        }

        [Test]
        public void FuelConsumptionZeroShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mercedes", "GLS", 0, 70);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void FuelConsumptionNegativeNumberShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mercedes", "", -1, 70);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void FuelCapacityShouldBeValid()
        {
            Car car = new Car("Mercedes", "GLS", 0.8, 70);
            Assert.AreEqual(70, car.FuelCapacity);
        }

        [Test]
        public void FuelCapacityZeroShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mercedes", "GLS", 0.8, 0);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void FuelCapacityNegativeNumberShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mercedes", "", 0.8, -1);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void FuelAmountShouldBeValid()
        {
            Car car = new Car("Mercedes", "GLS", 0.8, 70);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void RefuelShouldRefuelTheCarProperly()
        {
            Car car = new Car("Mercedes", "GLS", 0.8, 70);
            car.Refuel(50);

            Assert.AreEqual(50, car.FuelAmount);
        }

        [Test]
        public void RefuelWithZeroFuelShouldThrowException()
        {
            Car car = new Car("Mercedes", "GLS", 0.8, 70);
            
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void RefuelWithFuelNegativeNumberShouldThrowException()
        {
            Car car = new Car("Mercedes", "GLS", 0.8, 70);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-1);
            }, "Fuel amount cannot be zero or negative!");
        }


        [Test]
        public void RefuelWithMoreThanFuelCapacityShouldWorkProperly()
        {
            Car car = new Car("Mercedes", "GLS", 0.8, 70);

            car.Refuel(75);

            Assert.AreEqual(70, car.FuelAmount);
        }

        [Test]
        public void DriveMethodShouldWorkProperly()
        {
            Car car = new Car("Mercedes", "GLS", 8, 70);
            car.Refuel(50);
            car.Drive(100);

            Assert.AreEqual(42, car.FuelAmount);
        }

        [Test]
        public void DriveMethodWithLongDistanceShouldThrowException()
        {
            Car car = new Car("Mercedes", "GLS", 8, 70);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Refuel(10);
                car.Drive(1000);
            }, "You don't have enough fuel to drive!");
        }
    }
}