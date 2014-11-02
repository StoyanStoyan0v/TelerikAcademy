using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace UploadArchive.Database
{
    internal sealed class Configuration : DbMigrationsConfiguration<FilesContext>
    {
        public Configuration() 
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}