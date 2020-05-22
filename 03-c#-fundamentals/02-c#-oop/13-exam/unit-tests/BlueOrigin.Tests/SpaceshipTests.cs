namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        private string name;
        private int capacity;

        private Spaceship spaceship;

        private Astronaut astronaut;

        [SetUp]
        public void Setup()
        {
            this.name = "SomeName";
            this.capacity = 100;

            this.spaceship = new Spaceship(this.name, this.capacity);

            this.astronaut = new Astronaut("Astro", 99);
        }

        [Test]
        public void Constructor_ShouldInitialize_WithValidArguments()
        {
            var spaceship = new Spaceship(this.name, this.capacity);

            Assert.AreEqual(this.name, spaceship.Name);
            Assert.AreEqual(this.capacity, spaceship.Capacity);
        }

        [Test]
        public void Constructor_ShouldThrow_WithNullName()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, this.capacity));
        }

        [Test]
        public void Constructor_ShouldThrow_WithEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(string.Empty, this.capacity));
        }

        [Test]
        public void Constructor_ShouldThrow_WithInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship(this.name, -1));
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            this.spaceship.Add(this.astronaut);

            Assert.AreEqual(1, this.spaceship.Count);
        }

        [Test]
        public void Add_ShouldThrow_WhenAddingAstronautExceedingCapacity()
        {
            for (int i = 0; i < 100; i++)
            {
                this.spaceship.Add(new Astronaut(i.ToString(), i));
            }

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(this.astronaut));
        }

        [Test]
        public void Add_ShouldThrow_WhenAddingPreviouslyAddedAstronaut()
        {
            this.spaceship.Add(this.astronaut);

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(this.astronaut));
        }


        [Test]
        public void Remove_ShouldDecreaseCount()
        {
            this.spaceship.Add(this.astronaut);

            Assert.AreEqual(1, this.spaceship.Count);

            this.spaceship.Remove(this.astronaut.Name);

            Assert.AreEqual(0, this.spaceship.Count);
        }
    }
}