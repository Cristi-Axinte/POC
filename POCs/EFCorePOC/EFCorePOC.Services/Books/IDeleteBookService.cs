using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public interface IDeleteBookService
    {
        public Task<bool> DeleteBookAsync(BookDTO bookDTO);

        public Task<bool> DeleteBookAsync(string bookId);

    }
}
