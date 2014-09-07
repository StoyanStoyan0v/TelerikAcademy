namespace BookmarkingSite.Data.Migrations
{
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using BookmarkingSite.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<BookmarkingSiteDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "BookmarkingSite.Data.BookmarkingSiteDbContext";
        }
    }
}