namespace BanAccounts
{
    using System;
    using System.Linq;

    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, float interestRate):base(customer,balance,interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            if(this.Customer.GetType()==typeof(Individual))
            {
                if(months<=6)
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
                if(months<=12)
                {
                    return CalculateInterest(months) / 2;;
                }
                else
                {
                    return CalculateInterest(12) / 2 + CalculateInterest(months - 12);
                }
            }
        }
    }
}
