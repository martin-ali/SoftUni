namespace Chainblock
{
    using System;
    using global::Chainblock.Contracts;

    public class Transaction : ITransaction
    {
        private const TransactionStatus INITIAL_STATUS = TransactionStatus.Unauthorized;

        public Transaction(int id, string sender, string receiver, decimal amount)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else if (string.IsNullOrWhiteSpace(sender))
            {
                throw new ArgumentException(nameof(sender));
            }
            else if (string.IsNullOrWhiteSpace(receiver))
            {
                throw new ArgumentException(nameof(receiver));
            }
            else if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            this.Id = id;
            this.Status = INITIAL_STATUS;
            this.Sender = sender;
            this.Receiver = receiver;
            this.Amount = amount;
        }

        public int Id { get; }

        public TransactionStatus Status { get; set; }

        public string Sender { get; }

        public string Receiver { get; }

        public decimal Amount { get; }

        public int CompareTo(ITransaction other)
        {
            return this.Amount.CompareTo(other.Amount);
        }
    }
}