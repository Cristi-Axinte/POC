using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public interface IGetBooksService
    {
        public Task<IEnumerable<BookDTO>> GetAllBooksAsync();

        public Task<BookDTO> GetBookByIdAsync(string id);

        public Task<IEnumerable<BookDTO>> GetPagedBooksAsync(int pageIndex, int pageSize);
    }
}
