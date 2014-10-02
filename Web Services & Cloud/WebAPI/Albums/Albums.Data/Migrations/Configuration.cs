using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albums.Data;

namespace Albums.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<AlbumsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentsSystem.Data.StudentsSystemDbContext";
        }
    }
}