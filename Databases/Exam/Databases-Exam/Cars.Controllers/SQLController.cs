using System;
using System.Linq;
using Cars.Data;
using Cars.Models;

namespace Cars.Controllers
{
    internal class SQLController
    {
        private readonly ICarsData data;

        public SQLController() : this(new CarsData())
        {
        }

        public SQLController(ICarsData data)
        {
            this.data = data;
        }

        internal int GetManufacturerId(string manufacturerName)
        {
            var manufacturer = this.data.Manufacturers.All().FirstOrDefault(m => m.Name == manufacturerName);
            if (manufacturer == null)
            {
                manufacturer = new Manufacturer()
                {
                    Name = manufacturerName
                };
                this.data.Manufacturers.Add(manufacturer);
                this.data.SaveChanges();
            }
            return manufacturer.Id;
        }

        internal void InsertCar(string model, decimal price, int year, TransmissionType transmissionType, int manufacturerId, int dealerId)
        {
            var car = new Car()
            {
                Model = model,
                Price = price,
                TransmissionType = transmissionType,
                Year = year,
                ManufacturerId = manufacturerId,
                DealerId = dealerId
            };
            this.data.Cars.Add(car);
            this.data.SaveChanges();
        }

        internal int GetDealerId(string name, string cityName)
        {
            var dealer = this.data.Dealers.All().FirstOrDefault(m => m.City.Name == cityName && m.Name == name);
            if (dealer == null)
            {
                var cityId = this.GetCityId(cityName);
                dealer = new Dealer()
                {
                    Name = name,
                    CityId = cityId
                };

                this.data.Dealers.Add(dealer);
                this.data.SaveChanges();
            }
            return dealer.Id;
        }

        internal IQueryable<Car> GetCars()
        {
            return this.data.Cars.All().AsQueryable();
        }

        internal IQueryable<City> GetCities()
        {
            return this.data.Cities.All().AsQueryable();
        }

        private int GetCityId(string cityName)
        {
            var city = this.data.Cities.All().FirstOrDefault(c => c.Name == cityName);

            if (city == null)
            {
                city = new City()
                {
                    Name = cityName
                };
                this.data.Cities.Add(city);
                this.data.SaveChanges();
            }
            return city.Id;
        }
    }
}