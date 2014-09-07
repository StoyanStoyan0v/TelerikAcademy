namespace BookmarkingSite.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using BookmarkingSite.Models;

    public interface IBookmarkingSiteDbContext
    {
        IDbSet<Bookmark> Bookmarks { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}