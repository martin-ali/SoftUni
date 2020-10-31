namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Chainblock;
    using Chainblock.Contracts;
    using NUnit.Framework;

    [TestFixture]
    public class ChainblockTests
    {
        private int id;
        private TransactionStatus status;
        private string sender;
        private string receiver;
        private decimal amount;

        private ITransaction transaction;

        private List<ITransaction> transactions;

        private IChainblock chainblock;

        private void PopulateChainblock()
        {
            foreach (var transaction in this.transactions)
            {
                this.chainblock.Add(transaction);
            }
        }

        [SetUp]
        public void Setup()
        {
            this.id = 0;
            this.status = TransactionStatus.Unauthorized;
            this.sender = "Me";
            this.receiver = "You";
            this.amount = 1000m;

            this.transaction = new Transaction(this.id, this.sender, this.receiver, this.amount);

            this.transactions = new List<ITransaction>();
            for (int i = 1; i <= 10; i++)
            {
                this.transactions.Add(new Transaction(i, $"S{i % 3}", $"R{i % 4}", i * 15));
            }

            this.chainblock = new Chainblock();
        }

        [Test]
        public void Count_ShouldWorkCorrectly()
        {
            this.PopulateChainblock();

            Assert.AreEqual(this.transactions.Count, this.chainblock.Count);
        }

        [Test]
        public void Add_ShouldIncreaseTransactionCount()
        {
            var expectedCount = this.chainblock.Count + 1;

            this.chainblock.Add(this.transaction);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void Add_ShouldAppendCorrectTransaction()
        {
            this.chainblock.Add(this.transaction);

            Assert.That(this.chainblock.ToArray(), Has.Member(this.transaction));
        }

        [Test]
        public void Add_ShouldThrow_WithPreviouslyAddedTransaction()
        {
            this.chainblock.Add(this.transaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.Add(this.transaction));
        }

        [Test]
        public void ContainsTransaction_ShouldReturnTrue_WithExistingTransaction()
        {
            this.chainblock.Add(this.transaction);

            Assert.IsTrue(this.chainblock.Contains(this.transaction));
        }

        [Test]
        public void ContainsTransaction_ShouldReturnFalse_WithNonexistantTransaction()
        {
            Assert.IsFalse(this.chainblock.Contains(this.transaction));
        }

        [Test]
        public void ContainsId_ShouldReturnTrue_WithExistingTransaction()
        {
            this.chainblock.Add(this.transaction);

            Assert.IsTrue(this.chainblock.Contains(this.transaction.Id));
        }

        [Test]
        public void ContainsId_ShouldReturnFalse_WithNonexistantTransaction()
        {
            Assert.IsFalse(this.chainblock.Contains(this.transaction.Id));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Unauthorized)]
        public void ChangeTransactionStatus_ShouldChangeStatusOfTransaction(TransactionStatus status)
        {
            var transaction = new Transaction(1, "Me", "You", 100);

            this.chainblock.Add(transaction);
            this.chainblock.ChangeTransactionStatus(transaction.Id, status);

            Assert.AreEqual(status, transaction.Status);
        }

        [Test]
        public void ChangeTransactionStatus_ShouldThrow_WithNonexistantTransaction()
        {
            Assert.Throws<ArgumentException>(() => this.chainblock.ChangeTransactionStatus(10, status));
        }

        [Test]
        public void GetById_ShouldReturnCorrectTransaction()
        {
            this.chainblock.Add(this.transaction);

            Assert.AreSame(this.transaction, this.chainblock.GetById(this.transaction.Id));
        }

        [Test]
        public void GetById_ShouldThrow_WithNonexistantTransaction()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(this.transaction.Id));
        }

        [Test]
        public void RemoveTransactionById_ShouldDecreaseCount()
        {
            this.chainblock.Add(this.transaction);

            this.chainblock.RemoveTransactionById(this.transaction.Id);

            Assert.AreEqual(0, this.chainblock.Count);
        }

        [Test]
        public void RemoveTransactionById_ShouldRemoveCorrectTransaction()
        {
            this.chainblock.Add(this.transaction);

            this.chainblock.RemoveTransactionById(this.transaction.Id);

            Assert.That(this.chainblock.ToArray(), Has.No.Member(this.transaction));
        }

        [Test]
        public void RemoveTransactionById_ShouldThrow_WithNonexistantId()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(123));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetByTransactionStatus_ShouldReturnCorrectCollection(TransactionStatus status)
        {
            this.PopulateChainblock();

            var firstTransaction = this.chainblock.GetById(1);
            var secondTransaction = this.chainblock.GetById(2);
            var thirdTransaction = this.chainblock.GetById(3);

            for (int i = 1; i <= 3; i++)
            {
                this.chainblock.ChangeTransactionStatus(i, status);
            }

            var transactionsOfState = new[] { firstTransaction, secondTransaction, thirdTransaction }
                                        .OrderByDescending(t => t.Amount);

            CollectionAssert.AreEqual(transactionsOfState, this.chainblock.GetByTransactionStatus(status));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetByTransactionStatus_ShouldThrow_WhenThereAreNoTransactionsWithGivenStatus(TransactionStatus status)
        {
            this.PopulateChainblock();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByTransactionStatus(status));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetAllSendersWithTransactionStatus_ShouldReturnCorrectSenders(TransactionStatus status)
        {
            PopulateChainblock();

            var expectedTransactions = new List<ITransaction>();

            for (int i = 1; i <= 5; i++)
            {
                this.chainblock.ChangeTransactionStatus(i, status);

                expectedTransactions.Add(this.chainblock.GetById(i));
            }

            var expectedSenders = expectedTransactions
                                    .OrderByDescending(t => t.Amount)
                                    .Select(t => t.Sender);

            CollectionAssert.AreEqual(expectedSenders, this.chainblock.GetAllSendersWithTransactionStatus(status));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetAllSendersWithTransactionStatus_ShouldThrow_WhenNoSuchTransactionsArePresent(TransactionStatus status)
        {
            PopulateChainblock();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllSendersWithTransactionStatus(status));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetAllReceiversWithTransactionStatus_ShouldReturnCorrectSenders(TransactionStatus status)
        {
            PopulateChainblock();

            var expectedTransactions = new List<ITransaction>();

            for (int i = 1; i <= 5; i++)
            {
                this.chainblock.ChangeTransactionStatus(i, status);

                expectedTransactions.Add(this.chainblock.GetById(i));
            }

            var expectedSenders = expectedTransactions
                                    .OrderByDescending(t => t.Amount)
                                    .Select(t => t.Receiver);

            CollectionAssert.AreEqual(expectedSenders, this.chainblock.GetAllReceiversWithTransactionStatus(status));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetAllReceiversWithTransactionStatus_ShouldThrow_WhenNoSuchTransactionsArePresent(TransactionStatus status)
        {
            PopulateChainblock();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllReceiversWithTransactionStatus(status));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnCorrectTransactions(TransactionStatus status)
        {
            PopulateChainblock();

            var expectedTransactions = this.transactions
                                        .OrderByDescending(t => t.Amount)
                                        .ThenBy(t => t.Id);

            CollectionAssert.AreEqual(expectedTransactions, this.chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnEmptyCollection_WhenNoTransactionsArePresent(TransactionStatus status)
        {
            CollectionAssert.IsEmpty(this.chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        [TestCase("S0")]
        [TestCase("S1")]
        [TestCase("S2")]
        public void GetBySenderOrderedByAmountDescending_ShouldReturnCorrectTransactions(string sender)
        {
            PopulateChainblock();

            var expectedSenders = this.transactions
                                    .FindAll(t => t.Sender == sender)
                                    .OrderByDescending(t => t.Amount);

            CollectionAssert.AreEqual(expectedSenders, this.chainblock.GetBySenderOrderedByAmountDescending(sender));
        }

        [Test]
        [TestCase("S10")]
        [TestCase("S11")]
        [TestCase("S12")]
        public void GetBySenderOrderedByAmountDescending_ShouldThrow_WhenThereAreNoTransactionsWithSenderPresent(string sender)
        {
            PopulateChainblock();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderOrderedByAmountDescending(sender));
        }

        [Test]
        [TestCase("R0")]
        [TestCase("R1")]
        [TestCase("R2")]
        [TestCase("R3")]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturnCorrectTransactions(string receiver)
        {
            PopulateChainblock();

            var expectedReceivers = this.transactions
                                    .FindAll(t => t.Receiver == receiver)
                                    .OrderByDescending(t => t.Amount)
                                    .ThenBy(t => t.Id);

            CollectionAssert.AreEqual(expectedReceivers, this.chainblock.GetByReceiverOrderedByAmountThenById(receiver));
        }

        [Test]
        [TestCase("R10")]
        [TestCase("R11")]
        [TestCase("R12")]
        public void GetByReceiverOrderedByAmountThenById_ShouldThrow_WhenThereAreNoTransactionsWithReceiverPresent(string receiver)
        {
            PopulateChainblock();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverOrderedByAmountThenById(receiver));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnCorrectTransactions(TransactionStatus status)
        {
            PopulateChainblock();
            var maxAmount = 50;

            this.chainblock.ChangeTransactionStatus(1, TransactionStatus.Aborted);
            this.chainblock.ChangeTransactionStatus(2, TransactionStatus.Aborted);
            this.chainblock.ChangeTransactionStatus(3, TransactionStatus.Failed);
            this.chainblock.ChangeTransactionStatus(4, TransactionStatus.Failed);
            this.chainblock.ChangeTransactionStatus(5, TransactionStatus.Successfull);
            this.chainblock.ChangeTransactionStatus(6, TransactionStatus.Successfull);

            var expectedTransactions = this.transactions
                                            .FindAll(t => t.Status == status)
                                            .FindAll(t => t.Amount <= maxAmount)
                                            .OrderByDescending(t => t.Amount);

            CollectionAssert.AreEqual(expectedTransactions, this.chainblock.GetByTransactionStatusAndMaximumAmount(status, maxAmount));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetByTransactionStatusAndMaximumAmount_EmptyCollections_WhenNoSuchTransactionsArePresent(TransactionStatus status)
        {
            PopulateChainblock();

            CollectionAssert.IsEmpty(this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, -1));
        }

        [Test]
        [TestCase("S0")]
        [TestCase("S1")]
        [TestCase("S2")]
        public void GetBySenderAndMinimumAmountDescending_ShouldReturnCorrectTransactions(string sender)
        {
            PopulateChainblock();
            var AmountExclusive = 50;
            var expectedSenders = this.transactions
                                    .FindAll(t => t.Sender == sender)
                                    .FindAll(t => t.Amount > AmountExclusive)
                                    .OrderByDescending(t => t.Amount);

            CollectionAssert.AreEqual(expectedSenders, this.chainblock.GetBySenderAndMinimumAmountDescending(sender, AmountExclusive));
        }

        [Test]
        [TestCase("S0")]
        [TestCase("S1")]
        [TestCase("S2")]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrow_WhenNoSuchTransactionsArePresent(string sender)
        {
            PopulateChainblock();
            var AmountExclusive = 5000;

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending(sender, AmountExclusive));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldReturnCorrectTransactions()
        {
            PopulateChainblock();
            var receiver = "R1";
            var start = 10;
            var end = 1000;

            var expectedTransactions = this.transactions
                                        .FindAll(t => t.Receiver == receiver)
                                        .FindAll(t => start <= t.Amount && t.Amount < end)
                                        .OrderByDescending(t => t.Amount)
                                        .ThenBy(t => t.Id);

            CollectionAssert.AreEqual(expectedTransactions, this.chainblock.GetByReceiverAndAmountRange(receiver, start, end));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrow_WhenNoSuchTransactionsArePresent()
        {
            var sender = "S1";
            var start = 1000;
            var end = 1000000;

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverAndAmountRange(sender, start, end));
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnCorrectTransactions()
        {
            PopulateChainblock();
            var start = 10;
            var end = 100;

            var expectedTransactions = this.transactions
                                        .FindAll(t => start <= t.Amount && t.Amount <= end);

            CollectionAssert.AreEqual(expectedTransactions, this.chainblock.GetAllInAmountRange(start, end));
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnEmptyCollections_WhenNoSuchTransactionsArePresent()
        {
            PopulateChainblock();
            var start = 10000;
            var end = 1000000;

            var expectedTransactions = this.transactions
                                        .FindAll(t => start <= t.Amount && t.Amount <= end);

            CollectionAssert.AreEqual(expectedTransactions, this.chainblock.GetAllInAmountRange(start, end));
        }
    }
}