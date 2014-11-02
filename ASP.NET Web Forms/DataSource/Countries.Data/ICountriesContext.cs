using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Countries.Data.Models;

namespace Countries.Data
{
    public interface ICountriesContext
    {
        IDbSet<Country> Countries { get; set; }

        IDbSet<Continent> Continets { get; set; }

        IDbSet<Town> Towns { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}