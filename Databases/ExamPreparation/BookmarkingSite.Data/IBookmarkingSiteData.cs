using System;

namespace BookmarkingSite.Data
{
    using System.Linq;
    using BookmarkingSite.Data.Repositories;
    using BookmarkingSite.Models;

    public interface IBookmarkingSiteData
    {
        IGenericRepository<Tag> Tags { get; }

        IGenericRepository<Bookmark> Bookmarks { get; }

        IGenericRepository<User> Users { get; }
        
        void SaveChanges();
    }
}