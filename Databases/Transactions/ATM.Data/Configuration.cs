namespace ATM.Data
{
    using System.Data.Entity.Migrations;

    public class Configuration : DbMigrationsConfiguration<AtmDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "ATM.Data.AtmDbContext";
        }
    }
}