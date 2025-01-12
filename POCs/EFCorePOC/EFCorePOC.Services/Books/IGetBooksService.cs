using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public interface IGetBooksService
    {
        public Task<IEnumerable<BookDTO>> GetAllBooksAsync();

        public Task<BookDTO> GetBookByIdAsync(string id);

        public Task<IEnumerable<BookDTO>> GetPagedBooksAsync(int pageIndex, int pageSize);

        public Task<IEnumerable<BookDTO>> SearchBookByCategoryAsync(string categoryName);

        public Task<IEnumerable<KeyValuePair<string, int>>> GetBookCountByCategoryAsync();

        public Task<IEnumerable<BookDTO>> GetBooksDirectlyAsDTOAsync();

        public Task<BookDTO> GetBookByIdWithLazyLoadingAsync(string id);

    }
}
