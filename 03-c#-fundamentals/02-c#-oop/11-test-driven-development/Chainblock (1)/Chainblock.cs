namespace Chainblock
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using global::Chainblock.Contracts;

    public class Chainblock : IChainblock, IEnumerable<ITransaction>
    {
        private List<ITransaction> transactions = new List<ITransaction>();

        private SortedSet<ITransaction> SortedTransactions = new SortedSet<ITransaction>();

        private Dictionary<int, ITransaction> transactionById = new Dictionary<int, ITransaction>();

        private Dictionary<string, ITransaction> transactionsBySender = new Dictionary<string, ITransaction>();

        private Dictionary<string, ITransaction> transactionsByReceiver = new Dictionary<string, ITransaction>();

        private Dictionary<TransactionStatus, ITransaction> transactionsByStatus = new Dictionary<TransactionStatus, ITransaction>();

        public int Count => this.transactions.Count;

        public void Add(ITransaction transaction)
        {
            if (this.Contains(transaction))
            {
                throw new InvalidOperationException("Transaction already exists!");
            }

            this.transactions.Add(transaction);
        }

        public bool Contains(ITransaction transaction)
        {
            // return this.transactions.Contains(transaction);
            return this.Contains(transaction.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Exists(t => t.Id == id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus status)
        {
            if (this.Contains(id) == false)
            {
                throw new ArgumentException(nameof(id));
            }

            var transaction = this.GetById(id);
            transaction.Status = status;
        }

        public void RemoveTransactionById(int id)
        {
            if (this.Contains(id) == false)
            {
                throw new InvalidOperationException();
            }

            this.transactions.RemoveAll(t => t.Id == id);
        }

        public ITransaction GetById(int id)
        {
            if (this.Contains(id) == false)
            {
                throw new InvalidOperationException();
            }

            var transaction = this.transactions.Find(t => t.Id == id);
            return transaction;
        }

        public IReadOnlyCollection<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var orderedTransactionsByType = this.transactions
                                            .FindAll(t => t.Status == status)
                                            .OrderByDescending(t => t.Amount)
                                            .ToList();

            if (orderedTransactionsByType.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return orderedTransactionsByType;
        }

        public IReadOnlyCollection<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var orderedSenders = this.transactions
                                            .FindAll(t => t.Status == status)
                                            .OrderByDescending(t => t.Amount)
                                            .Select(t => t.Sender)
                                            .ToList();

            if (orderedSenders.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return orderedSenders;
        }

        public IReadOnlyCollection<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var orderedReceivers = this.transactions
                                            .FindAll(t => t.Status == status)
                                            .OrderByDescending(t => t.Amount)
                                            .Select(t => t.Receiver)
                                            .ToList();

            if (orderedReceivers.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return orderedReceivers;
        }

        public IReadOnlyCollection<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            var transactions = this.transactions
                                .OrderByDescending(t => t.Amount)
                                .ThenBy(t => t.Id)
                                .ToList();

            return transactions;
        }

        public IReadOnlyCollection<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var orderedTransactionsByType = this.transactions
                                            .FindAll(t => t.Sender == sender)
                                            .OrderByDescending(t => t.Amount)
                                            .ToList();

            if (orderedTransactionsByType.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return orderedTransactionsByType;
        }

        public IReadOnlyCollection<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var orderedTransactionsByType = this.transactions
                                            .FindAll(t => t.Receiver == receiver)
                                            .OrderByDescending(t => t.Amount)
                                            .ThenBy(t => t.Id)
                                            .ToList();

            if (orderedTransactionsByType.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return orderedTransactionsByType;
        }

        public IReadOnlyCollection<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, decimal amountInclusive)
        {
            var orderedTransactionsByType = this.transactions
                                            .FindAll(t => t.Status == status)
                                            .FindAll(t => t.Amount <= amountInclusive)
                                            .OrderByDescending(t => t.Amount)
                                            .ToList();

            return orderedTransactionsByType;
        }

        public IReadOnlyCollection<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, decimal amountExclusive)
        {
            var orderedTransactionsByType = this.transactions
                                            .FindAll(t => t.Sender == sender)
                                            .FindAll(t => t.Amount > amountExclusive)
                                            .OrderByDescending(t => t.Amount)
                                            .ToList();

            if (orderedTransactionsByType.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return orderedTransactionsByType;
        }

        public IReadOnlyCollection<ITransaction> GetByReceiverAndAmountRange(string receiver, decimal startInclusive, decimal endExclusive)
        {
            var orderedTransactionsByType = this.transactions
                                            .FindAll(t => t.Receiver == receiver)
                                            .FindAll(t => startInclusive <= t.Amount && t.Amount < endExclusive)
                                            .OrderByDescending(t => t.Amount)
                                            .ThenBy(t => t.Id)
                                            .ToList();

            if (orderedTransactionsByType.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return orderedTransactionsByType;
        }

        public IReadOnlyCollection<ITransaction> GetAllInAmountRange(decimal startInclusive, decimal endInclusive)
        {
            var orderedTransactionsByType = this.transactions
                                            .FindAll(t => startInclusive <= t.Amount && t.Amount <= endInclusive)
                                            .ToList();

            return orderedTransactionsByType;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactions)
            {
                yield return transaction;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}