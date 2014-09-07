using BookmarkingSite.Data.Repositories;
using BookmarkingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkingSite.Data
{
    public class BookmarkingSiteData : IBookmarkingSiteData
    {
        private readonly IBookmarkingSiteDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public BookmarkingSiteData() : this(new BookmarkingSiteDbContext())
        {
        }

        public BookmarkingSiteData(IBookmarkingSiteDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IGenericRepository<Bookmark> Bookmarks
        {
            get
            {
                return this.GetRepository<Bookmark>();
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