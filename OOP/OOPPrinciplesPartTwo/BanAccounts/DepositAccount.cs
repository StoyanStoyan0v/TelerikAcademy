namespace BanAccounts
{
    using System;
    using System.Linq;

    public class DepositAccount : Account, IWithdrawable
    {
        public DepositAccount(Customer customer, decimal balance, float interestRate) : base(customer, balance, interestRate)
        {
        }

        public  void Withdraw(decimal amount)
        {
            if(this.Balance<0 || amount<0 || this.Balance-amount<0)
            {
                throw new ArgumentException("Invalid amount or balance!");
            }
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterest(months);
            }
        }
    }
}