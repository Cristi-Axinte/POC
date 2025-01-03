using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;
using EFCorePOC.Services.Books;
using Microsoft.EntityFrameworkCore;

namespace EFCorePOC.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public BookRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            await _bookStoreDbContext.Books.AddAsync(book);
            await _bookStoreDbContext.SaveChangesAsync();

            Book? createdBook = await _bookStoreDbContext.Books
           .Include(b => b.Author)
           .Include(b => b.Website)
           .Include(b => b.Publisher)
           .Include(b => b.BookCategories)
           .ThenInclude(bc => bc.Category)
           .FirstOrDefaultAsync(b => b.Id == book.Id);

            return createdBook == null ? throw new Exception("Failed to create book") : createdBook;
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            var book = await _bookStoreDbContext.Books.FindAsync(id);
            if (book == null) throw new KeyNotFoundException("Book not found");

            _bookStoreDbContext.Books.Remove(book);
            await _bookStoreDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(Book book)
        {
            return await DeleteBookAsync(book.Id);
        }

        public async Task<Book> GetBookById(string id)
        {
             Book? retrievedBook =  await _bookStoreDbContext.Books
            .Include(b => b.Author)
            .Include(b => b.Website)
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(b => b.Id == id);

             return retrievedBook == null ? throw new Exception("Failed to retrieve book") : retrievedBook;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            List<Book>? retrievedBooks =  await _bookStoreDbContext.Books
            .Include(b => b.Author)
            .Include(b => b.Website)
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Category)
            .ToListAsync();

            return retrievedBooks == null ? throw new Exception("Failed to retrieve book") : retrievedBooks;
        }

        public async Task<IEnumerable<BookDTO>> GetBooksAsDtoDirectlyAsync()
        {
            return await _bookStoreDbContext.Books
               .Select(b => new BookDTO
               {
                   Id = b.Id,
                   Title = b.Title,
                   Description = b.Description,
                   PublisherName = b.Publisher.Name,
                   AuthorName = b.Author.Name,
                   WebsiteURL = b.Website.AddressUrl,
                   CategoryNames = b.BookCategories.Select(bc => bc.Category.Name).ToList()
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetPagedBooksAsync(int pageIndex, int pageSize)
        {
            List<Book>? retrievedBooks = await _bookStoreDbContext.Books.
                 Include(b => b.Author)
                .Include(b => b.Website)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return retrievedBooks;
        }

        public async Task<IEnumerable<Book>> SearchBookByCategoryAsync(string categoryName)
        {
            return await _bookStoreDbContext.Books
             .Include(b => b.Author)
             .Include(b => b.Website)
             .Include(b => b.Publisher)
             .Include(b => b.BookCategories)
             .ThenInclude(bc => bc.Category)
             .Where(b => b.BookCategories.Any(bc => bc.Category.Name.Contains(categoryName)))
             .OrderBy(b => b.Title) 
             .ToListAsync();
        }

        public async Task<IEnumerable<KeyValuePair<string, int>>> GetBookCountByCategoryAsync()
        {
            return await _bookStoreDbContext.Books
                .SelectMany(b => b.BookCategories) 
                .GroupBy(bc => bc.Category.Name)  
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .ToListAsync();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _bookStoreDbContext.Books.Update(book);
            await _bookStoreDbContext.SaveChangesAsync();

            return book;
        }

        public async Task<Book> CreateBookWithTransactionAsync(Book book, string authorName, string websiteUrl, string publisherName, IEnumerable<string> categoryNames)
        {
            using (var transaction = await _bookStoreDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var author = await GetOrCreateAuthorAsync(authorName);
                    var website = await GetOrCreateWebsiteAsync(websiteUrl);
                    var publisher = await GetOrCreatePublisherAsync(publisherName);
                    var categories = await GetOrCreateCategoriesAsync(categoryNames);

                    book.AuthorId = author.Id;
                    book.WebsiteId = website.Id;
                    book.PublisherId = publisher.Id;

                    book.BookCategories = categories.Select(c => new BookCategory
                    {
                        CategoryId = c.Id
                    }).ToList();

                    await _bookStoreDbContext.Books.AddAsync(book);
                    await _bookStoreDbContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return book;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Failed to create the book and its related entities", ex);
                }
            }
        }

        private async Task<Author> GetOrCreateAuthorAsync(string authorName)
        {
            var author = await _bookStoreDbContext.Authors.FirstOrDefaultAsync(a => a.Name == authorName);
            if (author == null)
            {
                author = new Author { Name = authorName };
                await _bookStoreDbContext.Authors.AddAsync(author);
                await _bookStoreDbContext.SaveChangesAsync();
            }
            return author;
        }

        private async Task<Website> GetOrCreateWebsiteAsync(string websiteUrl)
        {
            var website = await _bookStoreDbContext.Websites.FirstOrDefaultAsync(w => w.AddressUrl == websiteUrl);
            if (website == null)
            {
                website = new Website { AddressUrl = websiteUrl, Name = websiteUrl };
                await _bookStoreDbContext.Websites.AddAsync(website);
                await _bookStoreDbContext.SaveChangesAsync();
            }
            return website;
        }

        private async Task<Publisher> GetOrCreatePublisherAsync(string publisherName)
        {
            var publisher = await _bookStoreDbContext.Publisher.FirstOrDefaultAsync(p => p.Name == publisherName);
            if (publisher == null)
            {
                publisher = new Publisher { Name = publisherName };
                await _bookStoreDbContext.Publisher.AddAsync(publisher);
                await _bookStoreDbContext.SaveChangesAsync();
            }
            return publisher;
        }

        private async Task<IEnumerable<Category>> GetOrCreateCategoriesAsync(IEnumerable<string> categoryNames)
        {
            var existingCategories = await _bookStoreDbContext.Categories
                .Where(c => categoryNames.Contains(c.Name))
                .ToListAsync();

            var categoriesToCreate = categoryNames
                .Where(name => !existingCategories.Any(c => c.Name == name))
                .Select(name => new Category { Name = name })
                .ToList();

            if (categoriesToCreate.Any())
            {
                await _bookStoreDbContext.Categories.AddRangeAsync(categoriesToCreate);
                await _bookStoreDbContext.SaveChangesAsync();
                existingCategories.AddRange(categoriesToCreate);
            }

            return existingCategories;
        }
    }
}