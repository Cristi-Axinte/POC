namespace EFCorePOC.Common.Entities
{
    public class BookCategory
    {
        public string BookId { get; set; }
        public virtual Book Book { get; set; }

        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
