namespace EFCorePOC.Common.Entities
{
    public class Book
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }

        public string AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public string PublisherId { get; set; } 
        public virtual Publisher Publisher { get; set; }

        public string WebsiteId { get; set; }
        public virtual Website Website { get; set; }
    }
}
