namespace Tests
{
    using System;
    using Chainblock;
    using Chainblock.Contracts;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionTests
    {
        private int id;
        private TransactionStatus status;
        private string sender;
        private string receiver;
        private decimal amount;

        private ITransaction transaction;

        [SetUp]
        public void Setup()
        {
            this.id = 0;
            this.status = TransactionStatus.Unauthorized;
            this.sender = "Me";
            this.receiver = "You";
            this.amount = 1000m;

            this.transaction = new Transaction(this.id, this.sender, this.receiver, this.amount);
        }

        [Test]
        public void Constructor_ShouldInitialize_WithValidArguments()
        {
            var transaction = new Transaction(this.id, this.sender, this.receiver, this.amount);

            Assert.AreEqual(this.id, transaction.Id);
            Assert.AreEqual(this.sender, transaction.Sender);
            Assert.AreEqual(this.receiver, transaction.Receiver);
            Assert.AreEqual(this.amount, transaction.Amount);
            Assert.AreEqual(this.status, transaction.Status);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        public void Constructor_ShouldThrow_WithInvalidId(int invalidId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Transaction(invalidId, this.sender, this.receiver, this.amount));
        }

        [Test]
        public void Constructor_ShouldThrow_WithNullSender()
        {
            Assert.Throws<ArgumentException>(() => new Transaction(this.id, null, this.receiver, this.amount));
        }

        [Test]
        public void Constructor_ShouldThrow_WithEmptySender()
        {
            Assert.Throws<ArgumentException>(() => new Transaction(this.id, string.Empty, this.receiver, this.amount));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("            ")]
        public void Constructor_ShouldThrow_WithWhitespaceSender(string whitespace)
        {
            Assert.Throws<ArgumentException>(() => new Transaction(this.id, whitespace, this.receiver, this.amount));
        }

        [Test]
        public void Constructor_ShouldThrow_WithNullReceiver()
        {
            Assert.Throws<ArgumentException>(() => new Transaction(this.id, this.sender, null, this.amount));
        }

        [Test]
        public void Constructor_ShouldThrow_WithEmptyReceiver()
        {
            Assert.Throws<ArgumentException>(() => new Transaction(this.id, this.sender, string.Empty, this.amount));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("            ")]
        public void Constructor_ShouldThrow_WithWhitespaceReceiver(string whitespace)
        {
            Assert.Throws<ArgumentException>(() => new Transaction(this.id, this.sender, whitespace, this.amount));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        [TestCase(int.MinValue)]
        public void Constructor_ShouldThrow_WithInvalidAmount(decimal invalidAmount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Transaction(this.id, this.sender, this.receiver, invalidAmount));
        }

        [Test]
        public void CompareTo_ShouldReturnNegativeNumber_WhenFirstTransactionAmountIsSmaller()
        {
            var smallerTransaction = new Transaction(0, "s", "r", 10);
            var biggerTransaction = new Transaction(1, "s", "r", 100);

            var comparisonResult = smallerTransaction.CompareTo(biggerTransaction);

            Assert.IsTrue(comparisonResult < 0);
        }

        [Test]
        public void CompareTo_ShouldReturnZero_WhenTransactionsAreEqual()
        {
            var transaction1 = new Transaction(0, "s", "r", 10);
            var transaction2 = new Transaction(1, "s", "r", 10);

            var comparisonResult = transaction1.CompareTo(transaction2);

            Assert.IsTrue(comparisonResult == 0);
        }

        [Test]
        public void CompareTo_ShouldReturnPositiveNumber_WhenSecondTransactionAmountIsSmaller()
        {
            var smallerTransaction = new Transaction(0, "s", "r", 10);
            var biggerTransaction = new Transaction(1, "s", "r", 100);

            var comparisonResult = biggerTransaction.CompareTo(smallerTransaction);

            Assert.IsTrue(comparisonResult > 0);
        }
    }
}