
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UploadArchive.Database
{
    public class FilesContext : DbContext
    {
        public FilesContext() : base("Files")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilesContext, Configuration>());
           
        }

        public IDbSet<File> Files { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}