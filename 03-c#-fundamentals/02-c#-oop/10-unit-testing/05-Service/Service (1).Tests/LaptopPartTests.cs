using System;
using NUnit.Framework;
using Service.Models.Contracts;
using Service.Models.Parts;

namespace Tests
{
    public class LaptopPartTests
    {
        private IPart part;

        private string partName;
        private decimal partCost;
        private decimal partMultipliedCost;
        private bool PartIsBroken;

        [SetUp]
        public void Setup()
        {
            this.partName = "SSD";
            this.partCost = 100;
            this.partMultipliedCost = this.partCost * 1.5m;
            this.PartIsBroken = true;
            this.part = new LaptopPart(this.partName, this.partCost, this.PartIsBroken);
        }

        [Test]
        public void Constructor_ShouldInitialize_WithTwoValidParameters()
        {
            var part = new LaptopPart(this.partName, this.partCost);

            Assert.AreEqual(this.partName, part.Name);
            Assert.AreEqual(this.partMultipliedCost, part.Cost);
            Assert.IsFalse(part.IsBroken);
        }

        [Test]
        public void Constructor_ShouldInitialize_WithThreeValidParameters()
        {
            var part = new LaptopPart(this.partName, this.partCost, this.PartIsBroken);

            Assert.AreEqual(this.partName, part.Name);
            Assert.AreEqual(this.partMultipliedCost, part.Cost);
            Assert.AreEqual(this.PartIsBroken, part.IsBroken);
        }

        [Test]
        public void Constructor_ShouldThrow_WithNullPartName()
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart(null, this.partCost));
        }

        [Test]
        public void Constructor_ShouldThrow_WithEmptyPartName()
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart(string.Empty, this.partCost));
        }

        [Test]
        [TestCase("")]
        public void Constructor_ShouldThrow_WithWhitespacePartName(string whitespace)
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart(whitespace, this.partCost));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-101)]
        public void Constructor_ShouldThrow_WithInvalidCost(decimal invalidCost)
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart(this.partName, invalidCost));
        }

        [Test]
        public void Name_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.partName, this.part.Name);
        }

        [Test]
        public void Cost_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.partMultipliedCost, this.part.Cost);
        }

        [Test]
        public void IsBroken_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.PartIsBroken, this.part.IsBroken);
        }

        [Test]
        public void Repair_ShouldSetIsBrokenToFalse()
        {
            var part = new LaptopPart(this.partName, this.partCost, this.PartIsBroken);

            this.part.Repair();

            Assert.IsFalse(this.part.IsBroken);
        }

        [Test]
        public void Report_ShouldWorkCorrectly()
        {
            var expectedReport = $"{this.partName} - {this.partMultipliedCost:f2}$" + Environment.NewLine + $"Broken: {this.PartIsBroken}";

            var actualReport = this.part.Report();

            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
