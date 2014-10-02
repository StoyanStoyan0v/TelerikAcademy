using Albums.Data.Repositories;
using Albums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Data
{
    public interface IAlbumsData
    {
        IGenericRepository<Album> Albums { get; }

        IGenericRepository<Song> Songs { get; }

        IGenericRepository<Artist> Artists { get; }

        void SaveChanges();
    }
}