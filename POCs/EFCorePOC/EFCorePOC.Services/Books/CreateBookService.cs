﻿using AutoMapper;
using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public class CreateBookService : ICreateBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public CreateBookService(IBookRepository bookRepository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository,
            IWebsiteRepository websiteRepository, IPublisherRepository publisherRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _websiteRepository = websiteRepository;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> CreateBookAsync(BookDTO bookDTO)
        {
            //just a test push
            var (author, website, publisher, categories) = await GetBookRelatedEntitiesAsync(
                bookDTO.AuthorName,
                bookDTO.WebsiteURL,
                bookDTO.PublisherName,
                bookDTO.CategoryNames
            );

            var mappedBook = _mapper.Map<Book>(bookDTO);

            mappedBook.AuthorId = author.Id;
            mappedBook.WebsiteId = website.Id;
            mappedBook.PublisherId = publisher.Id;
            mappedBook.BookCategories = categories.Select(c => new BookCategory
            {
                CategoryId = c.Id
            }).ToList();

            var createdBook = await _bookRepository.CreateBookAsync(mappedBook);

            return _mapper.Map<BookDTO>(createdBook);
        }


        public async Task<(Author, Website, Publisher, IEnumerable<Category>)> GetBookRelatedEntitiesAsync(string authorName, string websiteUrl, string publisherName, IEnumerable<string> categoryNames)
        {
            var authorTask = _authorRepository.GetByNameAsync(authorName);
            var websiteTask = _websiteRepository.GetByUrlAsync(websiteUrl);
            var categoriesTask = _categoryRepository.GetByNameAsync(categoryNames);
            var publisher = _publisherRepository.GetByNameAsync(publisherName);

            await Task.WhenAll(authorTask, websiteTask, categoriesTask);

            return (authorTask.Result, websiteTask.Result, publisher.Result, categoriesTask.Result);
        }
    }
}
