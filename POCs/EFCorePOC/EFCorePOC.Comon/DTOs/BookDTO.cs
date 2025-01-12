namespace EFCorePOC.Common.DTOs
{
    public class BookDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


        public string WebsiteURL { get; set; }

        public string AuthorName { get; set; }

        public string PublisherName { get; set; }

        public ICollection<string> CategoryNames { get; set; }
    }
}
