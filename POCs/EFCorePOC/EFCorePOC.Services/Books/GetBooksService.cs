using AutoMapper;
using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public class GetBooksService : IGetBooksService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            return _mapper.Map<IEnumerable<BookDTO>>(await _bookRepository.GetBooksAsync());
        }
    }
}
