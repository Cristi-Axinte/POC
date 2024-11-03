using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public class GetBooksService : IGetBooksService
    {
        public Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }
    }
}
