namespace CarManager.Tests
{
    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private const string Make = "BMW";
        private const string Model = "X3";
        private const double FuelConsumption = 2.3;
        private const double FuelCapacity = 50.5;
        private const double DefaultFuelAmount = 0;
        [SetUp]
        public void SetUp()
        {
            car = new Car(Make, Model, FuelConsumption, FuelCapacity);
        }
        [Test]
        public void ConstructorCreatesCarCorrectly()
        {
            Assert.IsTrue(car.Make == Make && car.Model == Model && car.FuelConsumption == FuelConsumption && car.FuelCapacity == car.FuelCapacity 
                && car.FuelAmount == DefaultFuelAmount,
                "Car was not created correctly.");
        }

        [TestCase("")]
        [TestCase(null)]
        public void ThrowsWhenGivingInvalidMake(string make)
        {
            TestDelegate action = () => new Car(make, Model, FuelConsumption, FuelCapacity);
            Assert.Throws<ArgumentException>(action, "Tried to create a car with invalid make.");
        }

        [TestCase("")]
        [TestCase(null)]
        public void ThrowsWhenGivingInvalidModel(string model)
        {
            TestDelegate action = () => new Car(Make, model, FuelConsumption, FuelCapacity);
            Assert.Throws<ArgumentException>(action, "Tried to create a car with invalid model.");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ThrowsWhenGivingInvalidFuelConsumption(double fuelConsumption)
        {
            TestDelegate action = () => new Car(Make, Model, fuelConsumption, FuelCapacity);
            Assert.Throws<ArgumentException>(action, "Tried to create a car with invalid fuel consumption.");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ThrowsWhenGivingInvalidFuelCapacity(double fuelCapacity)
        {
            TestDelegate action = () => new Car(Make, Model, FuelConsumption, fuelCapacity);
            Assert.Throws<ArgumentException>(action, "Tried to create a car with invalid fuel capacity.");
        }

        [Test]
        public void RefuelsCarCorrectlyWithoutReachingTheCapacity()
        {
            car.Refuel(30);
            Assert.That(car.FuelAmount, Is.EqualTo(30), "Car was not refueled correctly.");
        }

        [TestCase(50.5)]
        [TestCase(60)]
        public void RefuelsCarCorrectlyWithReachingTheCapacity(double fuelToRefuel)
        {
            car.Refuel(fuelToRefuel);
            Assert.That(car.FuelAmount, Is.EqualTo(FuelCapacity), "Car was not refueled correctly when reaching the capacity.");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ThrowsWhenTryingToRefuelWithZeroOrNegativeCapacity(double fuelToRefuel)
        {
            TestDelegate action = () => car.Refuel(fuelToRefuel);
            Assert.Throws<ArgumentException>(action, "Tried to refuel car with negative or zero fuel amount.");
        }

        [Test]
        public void CarDrivingCorrectly()
        {
            car.Refuel(10);
            car.Drive(200);
            Assert.That(car.FuelAmount, Is.EqualTo(5.4), "Car doesn't drive correctly.");
        }

        [Test]
        public void ThrowsWhenTryingToDriveBiggerDistanceThanTheCarCan()
        {
            car.Refuel(10);
            TestDelegate action = () => car.Drive(500);
            Assert.Throws<InvalidOperationException>(action, "Tried to drive car with insufficient fuel.");
        }
    }
}