namespace ATM.Data
{
    using System.Data.Entity;

    using ATM.Models;

    public class AtmDbContext : DbContext
    {
        public AtmDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDbContext, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionHistory> Transactions { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}