using Countries.Data.Models;
using Countries.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Countries.Data
{
    public class CountriesContext : DbContext, ICountriesContext
    {
        public CountriesContext() : base("Countries")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CountriesContext, Configuration>());
        }

        public IDbSet<Continent> Continets { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Town> Towns { get; set; }

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