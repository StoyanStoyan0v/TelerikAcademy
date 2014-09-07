namespace BookmarkingSite.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string TagName { get; set; }
        
        public int BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }
    }
}