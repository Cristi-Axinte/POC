using AutoMapper;
using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public class UpdateBookService : IUpdateBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateBookService(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IWebsiteRepository websiteRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _websiteRepository = websiteRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> UpdateBookAsync(BookDTO bookDTO)
        {
            var (author, website, categories) = await GetRelatedEntitiesAsync(bookDTO.AuthorName, bookDTO.WebsiteURL, bookDTO.CategoryNames);

            var existingBook = await _bookRepository.GetBookById(bookDTO.Id);

            if (existingBook == null)
            {
                throw new KeyNotFoundException($"Book with ID {bookDTO.Id} not found.");
            }

            var mappedExistingBook = _mapper.Map(bookDTO, existingBook);

            existingBook.AuthorId = author.Id;
            existingBook.WebsiteId = website.Id;
            existingBook.BookCategories = categories
                .Select(category => new BookCategory { BookId = bookDTO.Id, CategoryId = category.Id })
                .ToList();

            return _mapper.Map<BookDTO>(await _bookRepository.UpdateBook(mappedExistingBook));
        }

        private async Task<(Author, Website, IEnumerable<Category>)> GetRelatedEntitiesAsync(string authorName, string websiteUrl, IEnumerable<string> categoryNames)
        {
            var authorTask = _authorRepository.GetByNameAsync(authorName);
            var websiteTask = _websiteRepository.GetByUrlAsync(websiteUrl);
            var categoriesTask = _categoryRepository.GetByNameAsync(categoryNames);

            await Task.WhenAll(authorTask, websiteTask, categoriesTask);

            return (authorTask.Result, websiteTask.Result, categoriesTask.Result);
        }
    }
}
