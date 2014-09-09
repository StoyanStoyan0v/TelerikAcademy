namespace Cars.Data.Migrations
{
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using Cars.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<CarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "Cars.Data.CarsDbContext";
        }
    }
}