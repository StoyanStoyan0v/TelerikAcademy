namespace Cars.Data
{
    using System.Data.Entity;
    using Cars.Models;
    using Cars.Data.Migrations;

    public class CarsDbContext : DbContext, ICarsDbContext
    {
        public CarsDbContext() : base("CarsConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}