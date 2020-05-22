namespace Tests
{
    using NUnit.Framework;
    using System;
    using Database;

    public class DatabaseTests
    {
        private Database database;

        private int[] data = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database(data);
        }

        [Test]
        public void Constructor_ShouldInitializeDatabase()
        {
            // Arrange
            var expectedCount = this.data.Length;

            // Act
            var actualCount = this.data.Length;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Add_ShouldWorkCorrectly()
        {
            // Arrange
            var expectedCount = this.data.Length + 1;

            // Act
            this.database.Add(1);

            // Assert
            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void Add_ShouldThrow_WhenDatabaseIsFull()
        {
            for (int i = this.data.Length + 1; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(54));
        }

        [Test]
        public void Remove_ShouldWorkCorrectly()
        {
            var expectedCount = this.data.Length - 1;

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void Remove_ShouldThrow_WhenDatabaseIsEmpty()
        {
            for (int i = this.data.Length; i > 0; i--)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void Fetch_ShouldWorkCorrectly()
        {
            var result = this.database.Fetch();

            CollectionAssert.AreEqual(this.data, result);
        }
    }
}