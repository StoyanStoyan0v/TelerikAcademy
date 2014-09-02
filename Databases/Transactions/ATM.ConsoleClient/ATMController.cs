namespace ATM.ConsoleClient
{
    using System;
    using System.Linq;
    using ATM.Data;
    using ATM.Models;
    
    public class ATMController
    {
        private readonly AtmDbContext context;

        public ATMController()
        {
            this.context = new AtmDbContext();
        }

        public void TransactMoney(string fromCardNumber, string fromCardPin, string toCardNumber, decimal moneyAmount)
        {
            using (this.context)
            {
                var fromAccount = this.context.CardAccounts.FirstOrDefault(acc => acc.CardNumber == fromCardNumber && acc.CardPIN == fromCardPin && acc.Balance >= moneyAmount);
                var toAccount = this.context.CardAccounts.FirstOrDefault(acc => acc.CardNumber == toCardNumber);
                using (var tran = this.context.Database.BeginTransaction())
                {
                    try
                    {
                        fromAccount.Balance -= moneyAmount;
                        this.context.SaveChanges();
                        toAccount.Balance += moneyAmount;
                        this.context.SaveChanges();
                        tran.Commit();
                        Console.WriteLine("Transaction succesfull!");
                        this.AddToHistory(fromAccount.Id, (-1) * moneyAmount, context);
                        this.AddToHistory(toAccount.Id, moneyAmount, context);
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        Console.WriteLine("Transaction failed!");
                    }
                }
            }
        }

        private void AddToHistory(int id, decimal moneyAmmount, AtmDbContext context)
        {
            context.Transactions.Add(new TransactionHistory()
            {
                TransactionDate = DateTime.Now,
                Amount = moneyAmmount,
                CardAccountId = id
            });
            context.SaveChanges();
        }
    }
}