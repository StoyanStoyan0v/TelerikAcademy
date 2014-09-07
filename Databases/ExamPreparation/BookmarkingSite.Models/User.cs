namespace BookmarkingSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class User
    {
        private ICollection <Bookmark> bookmarks;

        public User()
        {
            this.bookmarks = new HashSet<Bookmark>();
        }

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Bookmark> Bookmarks
        {
            get
            {
                return this.bookmarks;
            }
            set
            {
                this.bookmarks = value;
            }
        }
    }
}