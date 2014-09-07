namespace BookmarkingSite.Models
{
    using System.Collections.Generic;
    
    public class Bookmark
    {
        public Bookmark()
        {
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Notes { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}