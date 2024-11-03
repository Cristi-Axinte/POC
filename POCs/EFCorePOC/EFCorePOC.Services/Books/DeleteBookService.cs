using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public class DeleteBookService : IDeleteBookService
    {
        public Task<bool> DeleteBookAsync(BookDTO bookDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookAsync(string bookId)
        {
            throw new NotImplementedException();
        }
    }
}
