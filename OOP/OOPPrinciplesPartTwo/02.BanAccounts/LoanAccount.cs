namespace BanAccounts
{
    using System;
    using System.Linq;

    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, float interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            if(this.Customer.GetType()==typeof(Individual))
            {
                if(months<=3)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterest(months);
                }
            }
            else
            {
                if(months<=2)
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
}
