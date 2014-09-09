namespace Cars.Data
{
    using Cars.Data.Repositories;
    using Cars.Models;
    
    public interface ICarsData
    {
        IGenericRepository<Car> Cars { get; }

        IGenericRepository<Manufacturer> Manufacturers { get; }

        IGenericRepository<City> Cities { get; }

        IGenericRepository<Dealer> Dealers { get; }
        
        void SaveChanges();
    }
}