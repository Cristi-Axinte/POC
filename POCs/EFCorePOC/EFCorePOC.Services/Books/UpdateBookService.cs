using AutoMapper;
using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public class UpdateBookService : IUpdateBookService
    {
        private readonly IBookRepository _bookRepository;
        
        private readonly IMapper _mapper;

        public async Task<BookDTO> UpdateBookAsync(BookDTO bookDTO)
        {
            var mappedBook = _mapper.Map<Book>(bookDTO);

            return _mapper.Map<BookDTO>(await _bookRepository.UpdateBook(mappedBook)); 
        }
    }
}
