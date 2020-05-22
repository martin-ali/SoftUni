namespace Chainblock.Contracts
{
    using System.Collections.Generic;

    public interface IChainblock : IEnumerable<ITransaction>
    {
        int Count { get; }

        void Add(ITransaction transaction);

        bool Contains(ITransaction transaction);

        bool Contains(int id);

        void ChangeTransactionStatus(int id, TransactionStatus status);

        void RemoveTransactionById(int id);

        ITransaction GetById(int id);

        IReadOnlyCollection<ITransaction> GetByTransactionStatus(TransactionStatus status);

        IReadOnlyCollection<string> GetAllSendersWithTransactionStatus(TransactionStatus status);

        IReadOnlyCollection<string> GetAllReceiversWithTransactionStatus(TransactionStatus status);

        IReadOnlyCollection<ITransaction> GetAllOrderedByAmountDescendingThenById();

        IReadOnlyCollection<ITransaction> GetBySenderOrderedByAmountDescending(string sender);

        IReadOnlyCollection<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver);

        IReadOnlyCollection<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, decimal amountInclusive);

        IReadOnlyCollection<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, decimal amountExclusive);

        IReadOnlyCollection<ITransaction> GetByReceiverAndAmountRange(string receiver, decimal startInclusive, decimal endExclusive);

        IReadOnlyCollection<ITransaction> GetAllInAmountRange(decimal startInclusive, decimal endInclusive);
    }
}
