using AutoMapper;
using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public class CreateBookService : ICreateBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> CreateBookAsync(BookDTO bookDTO)
        {
           var mappedBook = _mapper.Map<Book>(bookDTO);
           var createdBook =  _mapper.Map<BookDTO>(await _bookRepository.CreateBookAsync(mappedBook));

           return createdBook;
        }
    }
}
