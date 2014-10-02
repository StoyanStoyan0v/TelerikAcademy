using Albums.Data.Repositories;
using Albums.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Albums.Data
{
    public class AlbumsData : IAlbumsData
    {
        private readonly IAlbumsDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public AlbumsData()
            : this(new AlbumsDbContext())
        {
        }



        public IGenericRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public IGenericRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IGenericRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public AlbumsData(IAlbumsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
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