using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public interface ICreateBookService
    {
        public Task<BookDTO> CreateBookAsync(BookDTO bookDTO);
    }
}
