using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public interface IGetBooksService
    {
        public Task<IEnumerable<BookDTO>> GetAllBooksAsync();
    }
}
