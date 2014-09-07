namespace BookmarkingSite.Controllers
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using BookmarkingSite.Data;
    using BookmarkingSite.Models;
    using System.Collections.Generic;

    public class XMLController
    {
        public void ImportDataFromXml(string filePath)
        {
            var sqlController = new SQLController();
            var document = XDocument.Load(filePath);
            var bookmarks = document.Descendants("bookmark");
            
            foreach (var bookmark in bookmarks)
            {
                string username = (string)bookmark.Element("username");
                sqlController.InsertUser(username);

                string title = (string)bookmark.Element("title");
                string url = (string)bookmark.Element("url");
                string notes = (string)bookmark.Element("notes");
                int userId = sqlController.GetUserIdByName(username);
                sqlController.InsertBookmark(title, url, userId, notes);

                int bookmarkId = sqlController.GetBookmarkIdByTitle(title);
                var tags = (string)bookmark.Element("tags");
                if (tags != null)
                {
                    var allTagsAsString = tags.ToString();
                    var allTags = allTagsAsString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                   
                    sqlController.InsertTags(allTags, bookmarkId);
                }
                var allTagsFromTitle = title.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                sqlController.InsertTags(allTagsFromTitle, bookmarkId);
            }
        }

        public void ExecuteSimpleQueryFromXml(string filePath, ILogger logger)
        {
            var data = new BookmarkingSiteData();

            var document = XDocument.Load(filePath);
            var queries = document.Descendants("query");
            foreach (var query in queries)
            {
                string username = (string)query.Element("username");
                string tag = (string)query.Element("tag");
                var bookmarks = data.Bookmarks.All().Where(b => b.Tags.Any(t => t.TagName == tag));

                if (!string.IsNullOrEmpty(username))
                {
                    bookmarks = bookmarks.Where(b => b.User.Username == username);
                }
                bookmarks = bookmarks.OrderBy(x => x.Url);

                var listOfBookmarks = bookmarks.ToList();

                if (listOfBookmarks.Count == 0)
                {
                    logger.LogLine("Nothing found");
                }
                else
                {
                    foreach (var bookmark in listOfBookmarks)
                    {
                        logger.LogLine(bookmark.Url);
                    }
                }
            }
        }

        public void ExecuteComplexQueryFromXml(string filePath)
        {
            throw new NotImplementedException();
        }

        public void ExportQueryResultsToXml(ICollection<Bookmark> bookmarks)
        {
            throw new NotImplementedException();
        }
    }
}