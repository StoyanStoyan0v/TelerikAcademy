using Countries.Data.Models;
using Countries.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Data
{
    public interface ICountriesData
    {
        
        IGenericRepository<Country> Countries { get; }

        IGenericRepository<Continent> Continents { get; }

        IGenericRepository<Town> Towns { get; }

        void SaveChanges();
    }
}
