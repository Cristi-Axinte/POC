namespace EFCorePOC.Common.Entities
{
    public class Website
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AddressUrl { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
