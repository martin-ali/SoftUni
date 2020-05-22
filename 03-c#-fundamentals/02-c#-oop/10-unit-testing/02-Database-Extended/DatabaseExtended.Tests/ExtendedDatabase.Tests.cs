namespace Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    public class ExtendedDatabaseTests
    {
        private Person[] data;

        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.data = new Person[8];
            for (int i = 0; i < 8; i++)
            {
                this.data[i] = new Person(i, $"{i}ABC");
            }

            this.database = new ExtendedDatabase(data);
        }

        [Test]
        public void Constructor_ShouldInitializeExtendedDatabase()
        {
            // Arrange
            var expectedCount = this.data.Length;

            // Act
            var actualCount = this.data.Length;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(17)]
        [TestCase(19)]
        [TestCase(219)]
        public void Constructor_ShouldThrow_WithCollectionWithInvalidLength(int length)
        {
            var people = new Person[length];

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(people));
        }

        [Test]
        public void Add_ShouldWorkCorrectly()
        {
            // Arrange
            var expectedCount = this.data.Length + 1;

            // Act
            this.database.Add(new Person(this.data.Length + 1, "Add"));

            // Assert
            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        [TestCase("0ABC")]
        [TestCase("1ABC")]
        [TestCase("5ABC")]
        [TestCase("6ABC")]
        public void Add_ShouldThrow_WhenUsernameAlreadyExists(string username)
        {
            // Arrange
            var person = new Person(this.data.Length + 1, username);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(6)]
        public void Add_ShouldThrow_WhenIdAlreadyExists(long id)
        {
            // Arrange
            var person = new Person(id, "IdExists");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void Add_ShouldThrow_WhenExtendedDatabaseIsFull()
        {
            for (int i = this.data.Length + 1; i <= 16; i++)
            {
                this.database.Add(new Person(i, i.ToString()));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(192, "Overfill")));
        }

        [Test]
        public void Remove_ShouldWorkCorrectly()
        {
            var expectedCount = this.data.Length - 1;

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void Remove_ShouldThrow_WhenExtendedDatabaseIsEmpty()
        {
            for (int i = this.data.Length; i > 0; i--)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        [TestCase(11, "11")]
        [TestCase(12, "12")]
        [TestCase(13, "13")]
        [TestCase(16, "16")]
        public void FindByUsername_ShouldWorkCorrectly(int id, string username)
        {
            var person = new Person(id, username);

            this.database.Add(person);
            var queriedPerson = this.database.FindByUsername(username);

            Assert.AreSame(person, queriedPerson);
        }

        [Test]
        [TestCase("DoesNotExist")]
        [TestCase("45677")]
        [TestCase("239042309")]
        [TestCase("Robert")]
        public void FindByUsername_ShouldThrow_WhenUsernameDoesntExist(string username)
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(username));
        }

        [Test]
        [TestCase("1ABc")]
        [TestCase("1aBc")]
        [TestCase("1aBC")]
        [TestCase("1AbC")]
        [TestCase("1aBC")]
        [TestCase("1abC")]
        [TestCase("1abc")]
        public void FindByUsername_ShouldThrow_WhenUsernameIsWronglyCased(string username)
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ShouldThrow_WhenUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }

        [Test]
        public void FindByUsername_ShouldThrow_WhenUsernameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(string.Empty));
        }

        [Test]
        public void FindByUsername_ShouldThrow_WhenExtendedDatabaseIsEmpty()
        {
            for (int i = this.data.Length; i > 0; i--)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("0ABC"));
        }

        [Test]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(17)]
        public void FindById_ShouldWorkCorrectly(long id)
        {
            var person = new Person(id, id.ToString());

            this.database.Add(person);
            var queriedPerson = this.database.FindById(id);

            Assert.AreSame(person, queriedPerson);
        }

        [Test]
        [TestCase(8467)]
        [TestCase(842)]
        [TestCase(999999)]
        public void FindById_ShouldThrow_WhenIdDoesntExist(long missingId)
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(missingId));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-232)]
        [TestCase(-19292)]
        public void FindById_ShouldThrow_WhenIdIsNegative(long negativeId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(negativeId));
        }

        [Test]
        public void FindById_ShouldThrow_WhenExtendedDatabaseIsEmpty()
        {
            for (int i = this.data.Length; i > 0; i--)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.FindById(0));
        }
    }
}