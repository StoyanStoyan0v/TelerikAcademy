namespace TeleriAcademyForum
{
    public class ForumItem
    {
        public ForumItem()
        {
            this.Id = ++LastUserId;
        }

        static ForumItem()
        {
            LastUserId = 0;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        private static int LastUserId { get; set; }
    }
}