using System;
using NUnit.Framework;
using Service.Models.Contracts;
using Service.Models.Devices;
using Service.Models.Parts;

namespace Tests
{
    public class LaptopTests
    {
        private const string Make = "Dell";
        private IRepairable device;
        private IPart part;

        [SetUp]
        public void Setup()
        {
            this.device = new Laptop(Make);
            this.part = new LaptopPart("Name", 100);
        }

        [Test]
        public void Constructor_ShouldInitialize_WithValidParameters()
        {
            var laptop = new Laptop(Make);

            Assert.AreEqual(Make, laptop.Make);
            Assert.NotNull(laptop.Parts);
        }

        [Test]
        public void Constructor_ShouldThrow_WithNullMake()
        {
            Assert.Throws<ArgumentException>(() => new Laptop(null));
        }

        [Test]
        public void Constructor_ShouldThrow_WithEmptyMake()
        {
            Assert.Throws<ArgumentException>(() => new Laptop(string.Empty));
        }

        [Test]
        [TestCase("")]
        public void Constructor_ShouldThrow_WithWhitespaceMake(string whitespace)
        {
            Assert.Throws<ArgumentException>(() => new Laptop(whitespace));
        }

        [Test]
        public void Make_ShouldGet_CorrectValue()
        {
            var laptop = new Laptop(Make);

            Assert.AreEqual(Make, laptop.Make);
        }

        [Test]
        public void Parts_ShouldGet_CorrectValue()
        {
            var oldCount = this.device.Parts.Count;

            var ram = new LaptopPart("RAM", 999);
            this.device.AddPart(this.part);
            this.device.AddPart(ram);

            Assert.AreEqual(2, this.device.Parts.Count);
            Assert.That(this.device.Parts, Has.Member(this.part));
            Assert.That(this.device.Parts, Has.Member(ram));
        }

        [Test]
        public void AddPart_ShouldIncreasePartCount()
        {
            var oldCount = this.device.Parts.Count;

            this.device.AddPart(this.part);

            Assert.AreEqual(oldCount + 1, this.device.Parts.Count);
        }

        [Test]
        public void AddPart_ShouldAddCorrectPart()
        {
            var oldCount = this.device.Parts.Count;

            this.device.AddPart(this.part);

            Assert.That(this.device.Parts, Has.Member(part));
        }

        [Test]
        public void AddPart_ShouldThrow_WhenAddingPreviouslyAddedPart()
        {
            this.device.AddPart(this.part);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(this.part));
        }

        [Test]
        public void AddPart_ShouldThrow_WhenAddingInvalidPart1()
        {
            var invalidPart = new PhonePart("Invalid", 100);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(invalidPart));
        }

        [Test]
        public void AddPart_ShouldThrow_WhenAddingInvalidPart2()
        {
            var invalidPart = new PCPart("Invalid", 100);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(invalidPart));
        }

        [Test]
        public void RemovePart_ShouldDecreasePartCount()
        {
            this.device.AddPart(this.part);

            this.device.RemovePart(this.part.Name);

            Assert.AreEqual(0, this.device.Parts.Count);
        }

        [Test]
        public void RemovePart_ShouldRemoveCorrectPart()
        {
            this.device.AddPart(this.part);

            this.device.RemovePart(this.part.Name);

            Assert.That(this.device.Parts, Does.Not.Contain(this.part));
        }

        [Test]
        public void RemovePart_ShouldThrow_WithNullPart()
        {
            Assert.Throws<ArgumentException>(() => this.device.RemovePart(null));
        }

        [Test]
        public void RemovePart_ShouldThrow_WithEmptyPart()
        {
            Assert.Throws<ArgumentException>(() => this.device.RemovePart(string.Empty));
        }

        [Test]
        public void RemovePart_ShouldThrow_WithWhitespacePart()
        {
            Assert.Throws<ArgumentException>(() => this.device.RemovePart(""));
        }

        [Test]
        public void RemovePart_ShouldThrow_WithNonexistantPart()
        {
            Assert.Throws<InvalidOperationException>(() => this.device.RemovePart("Non-existant-part"));
        }

        [Test]
        public void RepairPart_ShouldRepairCorrectPart()
        {
            var part = new LaptopPart("Broken", 300, true);
            this.device.AddPart(part);

            this.device.RepairPart(part.Name);

            Assert.IsFalse(part.IsBroken);
        }

        [Test]
        public void RepairPart_ShouldThrow_WithNullPart()
        {
            Assert.Throws<ArgumentException>(() => this.device.RepairPart(null));
        }

        [Test]
        public void RepairPart_ShouldThrow_WithEmptyPart()
        {
            Assert.Throws<ArgumentException>(() => this.device.RepairPart(string.Empty));
        }

        [Test]
        public void RepairPart_ShouldThrow_WithWhitespacePart()
        {
            Assert.Throws<ArgumentException>(() => this.device.RepairPart(""));
        }

        [Test]
        public void RepairPart_ShouldThrow_WithNonexistantPart()
        {
            Assert.Throws<InvalidOperationException>(() => this.device.RepairPart("Non-existant-part"));
        }

        [Test]
        public void RepairPart_ShouldThrow_WithNonBrokenPart()
        {
            var nonBrokenPart = new LaptopPart("Pristine", 100, false);
            this.device.AddPart(nonBrokenPart);

            Assert.Throws<InvalidOperationException>(() => this.device.RepairPart(nonBrokenPart.Name));
        }
    }
}