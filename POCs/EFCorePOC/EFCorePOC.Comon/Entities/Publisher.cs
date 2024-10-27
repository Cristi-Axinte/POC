namespace EFCorePOC.Common.Entities
{
    public class Publisher
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
