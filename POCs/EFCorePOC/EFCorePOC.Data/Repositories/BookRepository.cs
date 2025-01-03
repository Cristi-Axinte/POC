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
    }
}
