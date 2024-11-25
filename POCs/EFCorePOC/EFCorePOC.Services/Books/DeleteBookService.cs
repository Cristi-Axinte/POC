using AutoMapper;
using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public class DeleteBookService : IDeleteBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public DeleteBookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public Task<bool> DeleteBookAsync(BookDTO bookDTO)
        {
            var mappedBook = _mapper.Map<Book>(bookDTO);

            return _bookRepository.DeleteBookAsync(mappedBook);
        }

        public Task<bool> DeleteBookAsync(string bookId)
        {
            return _bookRepository.DeleteBookAsync(bookId);
        }
    }
}
