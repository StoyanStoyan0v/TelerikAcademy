namespace BanAccounts
{
    using System;

    public static class Test
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.Accounts.Add(new LoanAccount(new Company("Coca Cola", "123123124"), 2500000, 0.04f));
            bank.Accounts.Add(new DepositAccount(new Individual("Ivan", "9003157129"), 4000, 0.035f));
            bank.Accounts.Add(new MortgageAccount(new Individual("Pesho", "7412431265"), 50000, 0.08f));

            foreach (var item in bank.Accounts)
            {
                Console.WriteLine("Customer name: {0,-10} | Balance: {1,-15:C2} | Interest: {2:C2}",item.Customer.Name,item.Balance,
                    item.CalculateInterest(3));
            }
        }
    }
}