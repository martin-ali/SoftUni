using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private readonly string make = "Make";
        private readonly string model = "Model";
        private readonly double fuelConsumption = 1;
        private readonly double fuelCapacity = 100;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);
        }

        [Test]
        public void Constructor_ShouldInitialize_WithValidParameters()
        {
            var car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.AreEqual(this.make, car.Make);
            Assert.AreEqual(this.model, car.Model);
            Assert.AreEqual(this.fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(this.fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void Constructor_ShouldThrow_WithEmptyMake()
        {
            Assert.Throws<ArgumentException>(() => new Car(string.Empty, this.model, this.fuelConsumption, this.fuelCapacity));
        }

        [Test]
        public void Constructor_ShouldThrow_WithNullMake()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, this.model, this.fuelConsumption, this.fuelCapacity));
        }

        [Test]
        public void Constructor_ShouldThrow_WithEmptyModel()
        {
            Assert.Throws<ArgumentException>(() => new Car(this.make, string.Empty, this.fuelConsumption, this.fuelCapacity));
        }

        [Test]
        public void Constructor_ShouldThrow_WithNullModel()
        {
            Assert.Throws<ArgumentException>(() => new Car(this.make, null, this.fuelConsumption, this.fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void Constructor_ShouldThrow_WithInvalidFuelConsumption(double consumption)
        {
            Assert.Throws<ArgumentException>(() => new Car(this.make, this.model, consumption, this.fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void Constructor_ShouldThrow_WithInvalidFuelCapacity(double capacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(this.make, this.model, this.fuelConsumption, capacity));
        }

        [Test]
        public void Make_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.make, this.car.Make);
        }

        [Test]
        public void Model_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.model, this.car.Model);
        }

        [Test]
        public void FuelConsumption_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.fuelConsumption, this.car.FuelConsumption);
        }

        [Test]
        public void FuelCapacity_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.fuelCapacity, this.car.FuelCapacity);
        }

        [Test]
        public void FuelAmount_ShouldGetCorrectValue()
        {
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void Refuel_ShouldIncreaseFuelAmount()
        {
            var amount = 90d;

            this.car.Refuel(amount);

            Assert.AreEqual(amount, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void Refuel_ShouldThrow_WithInvalidFuelToRefuel(double amount)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(amount));
        }

        [Test]
        [TestCase(1000)]
        [TestCase(999)]
        [TestCase(101)]
        public void Refuel_ShouldFillToCapacity_WithOverflowingAmount(double amount)
        {
            var capacity = this.car.FuelCapacity;

            car.Refuel(amount);

            Assert.AreEqual(capacity, this.car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(450)]
        public void Drive_ShouldDecreaseFuelAmount(double distance)
        {
            var amount = 90d;
            this.car.Refuel(amount);
            var expectedFuelConsumed = this.car.FuelConsumption * (distance / 100);
            var expectedFuelAmount = this.car.FuelAmount - expectedFuelConsumed;

            this.car.Drive(distance);

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        [TestCase(0.000000000001, 1)]
        [TestCase(0.003, 15)]
        [TestCase(1, 450)]
        [TestCase(90, 23450)]
        public void Drive_ShouldThrow_WhenNotEnoughFuel(double fuelAmount, double distance)
        {
            this.car.Refuel(fuelAmount);
            var expectedFuelConsumed = this.car.FuelConsumption * (distance / 100);
            var expectedFuelAmount = this.car.FuelAmount - expectedFuelConsumed;

            Assert.Throws<InvalidOperationException>(() => this.car.Drive(distance));
        }
    }
}