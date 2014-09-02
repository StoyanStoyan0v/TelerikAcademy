namespace ATM.Models
{
    using System;

    public class TransactionHistory
    {
        public int Id { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public int CardAccountId { get; set; }

        public virtual CardAccount CardAccount { get; set; }
    }
}