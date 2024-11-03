using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public interface IUpdateBookService
    {
        public Task<BookDTO> UpdateBookAsync(BookDTO bookDTO);
    }
}
