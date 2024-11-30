using AutoMapper;
using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Books
{
    public class GetBooksService : IGetBooksService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository; 
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            return _mapper.Map<IEnumerable<BookDTO>>(await _bookRepository.GetBooksAsync());
        }

        public async Task<BookDTO> GetBookByIdAsync(string id)
        {
            return _mapper.Map<BookDTO>(await _bookRepository.GetBookById(id));
        }

        public async Task<IEnumerable<BookDTO>> SearchBookByCategoryAsync(string categoryName)
        {
            return _mapper.Map<IEnumerable<BookDTO>>(await _bookRepository.SearchBookByCategoryAsync(categoryName));
        }


        public async Task<IEnumerable<BookDTO>> GetPagedBooksAsync(int pageIndex, int pageSize)
        {
            return _mapper.Map<IEnumerable<BookDTO>>(await _bookRepository.GetPagedBooksAsync(pageIndex, pageSize));
        }

        public async Task<IEnumerable<KeyValuePair<string, int>>> GetBookCountByCategoryAsync()
        {
            return await _bookRepository.GetBookCountByCategoryAsync();
        }
    }
}
