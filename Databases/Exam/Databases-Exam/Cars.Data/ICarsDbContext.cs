namespace Cars.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Cars.Models;
    
    public interface ICarsDbContext
    {
        IDbSet<Car> Cars { get; set; }
        
        IDbSet<City> Cities { get; set; }

        IDbSet<Dealer> Dealers { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}