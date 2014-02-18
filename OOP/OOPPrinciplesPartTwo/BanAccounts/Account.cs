namespace BanAccounts
{
    using System;
    using System.Linq;

    public abstract class Account : IDepositable
    {
        private float interestRate;

        public Account(Customer customer, decimal balance, float interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; private set; }

        public decimal Balance { get; protected set; }

        public float InterestRate
        {
            get
            {
                return this.interestRate;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest rate cannot be a negative number!");
                }

                this.interestRate = value;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("You cannot deposit a negative amount!");
            }
            this.Balance += amount;
        }

        public virtual decimal CalculateInterest(int months)
        {
            return (decimal)this.InterestRate * months * this.Balance / 100;
        }
    }
}