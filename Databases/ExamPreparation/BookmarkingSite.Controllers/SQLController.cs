namespace BookmarkingSite.Controllers
{
    
    using System.Collections.Generic;
    using System.Linq;

    using BookmarkingSite.Data;
    using BookmarkingSite.Models;

    public class SQLController
    {
        private readonly IBookmarkingSiteData data;

        public SQLController() : this(new BookmarkingSiteData())
        {
        }

        public SQLController(IBookmarkingSiteData data)
        {
            this.data = data;
        }

        public void InsertUser(string username, string name=null, string password=null)
        {
            this.data.Users.Add(new User()
            {
                Username = username,
                Name = name,
                Password = password
            });
            this.data.SaveChanges();
        }

        public void InsertBookmark(string title, string url, int userId, string notes=null)
        {
            this.data.Bookmarks.Add(new Bookmark()
            {
                Title = title,
                Url = url,
                Notes = notes,
                UserId = userId
            });
            this.data.SaveChanges();
        }

        public void InsertTags(ICollection<string> tagNames, int bookmarkId)
        {
            foreach (var tagName in tagNames)
            {
                this.data.Tags.Add(new Tag()
                {
                    TagName = tagName,
                    BookmarkId = bookmarkId
                });
            }
            
            this.data.SaveChanges();
        }

        public int GetUserIdByName(string username)
        {
            return this.data.Users.All().FirstOrDefault(u => u.Username == username).Id;
        }

        public int GetBookmarkIdByTitle(string bookmarkTitle)
        {
            return this.data.Bookmarks.All().FirstOrDefault(b => b.Title == bookmarkTitle).Id;
        }
    }
}