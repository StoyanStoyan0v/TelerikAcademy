using Countries.Data.Models;
using Countries.Data.Repositories;
using Countries.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Countries.Data
{
    public class CountriesData :ICountriesData
    {
        private readonly ICountriesContext context;

        private readonly IDictionary<Type, object> repositories;

        public CountriesData() : this(new CountriesContext())
        {
        }

        public CountriesData(ICountriesContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Continent> Continents
        {
            get
            {
                return this.GetRepository<Continent>();
            }
        }

        public IGenericRepository<Town> Towns
        {
            get
            {
                return this.GetRepository<Town>();
            }
        }

        public IGenericRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}