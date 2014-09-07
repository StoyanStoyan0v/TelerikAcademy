namespace BookmarkingSite.Data
{
    using System.Data.Entity;

    using BookmarkingSite.Data.Migrations;
    using BookmarkingSite.Models;

    internal class BookmarkingSiteDbContext : DbContext, IBookmarkingSiteDbContext
    {
        public BookmarkingSiteDbContext() : base("BookmarksConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarkingSiteDbContext, Configuration>());
        }
        
        public IDbSet<Bookmark> Bookmarks { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}