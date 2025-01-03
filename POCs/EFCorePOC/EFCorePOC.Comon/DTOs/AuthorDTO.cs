namespace EFCorePOC.Common.DTOs
{
    public class AuthorDTO
    {
        public string AuthorName { get; set; }

        public IEnumerable<string> BooksTitles { get; set; }
    }
}
