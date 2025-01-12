namespace EFCorePOC.Common.Entities
{
    public class Category
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
