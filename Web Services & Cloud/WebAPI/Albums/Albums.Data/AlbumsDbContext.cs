using Albums.Data.Migrations;
using Albums.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Data
{
    public class AlbumsDbContext : DbContext, IAlbumsDbContext
    {
        public AlbumsDbContext() : base("Albums")
            
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlbumsDbContext, Configuration>());
        }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }
        
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}