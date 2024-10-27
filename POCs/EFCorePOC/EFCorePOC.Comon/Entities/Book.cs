﻿namespace EFCorePOC.Common.Entities
{
    public class Book
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }  
        public Author Author { get; set; }

        public string PublisherId { get; set; } 
        public Publisher Publisher { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }

        public string WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
