using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public interface IBookRepository
    {
        public Task<Book> CreateBookAsync(Book book);

        public Task<IEnumerable<Book>> GetBooksAsync();

        public Task<Book> GetBookById(string id);

        public Task<IEnumerable<Book>> GetPagedBooksAsync(int pageIndex, int pageSize);

        public Task<Book> UpdateBook(Book book);

        public Task<bool> DeleteBookAsync(string id);

        public Task<bool> DeleteBookAsync(Book book);
    }
}
