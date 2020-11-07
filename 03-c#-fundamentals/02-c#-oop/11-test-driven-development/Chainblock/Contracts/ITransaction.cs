namespace Chainblock.Contracts
{
    using System;

    public interface ITransaction : IComparable<ITransaction>
    {
        int Id { get; }

        TransactionStatus Status { get; set; }

        string Sender { get; }

        string Receiver { get; }

        decimal Amount { get; }
    }
}