using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;
using EFCorePOC.Services.Books;
using Microsoft.EntityFrameworkCore;

namespace EFCorePOC.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public AuthorRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<Author> GetByNameAsync(string name)
        {
            return await _bookStoreDbContext.Authors.FirstOrDefaultAsync(a => a.Name == name);
        }

        // Using Include
        public async Task<IEnumerable<Author>> GetAuthorsWithBooksIncludeAsync()
        {
            return await _bookStoreDbContext.Authors
                .Include(a => a.Books)
                .ToListAsync();
        }

        // Using Select ( this can be faster. For example, in case we only need book title, there is no point in including the whole Book object )
        public async Task<IEnumerable<AuthorDTO>> GetAuthorsWithSelectAsync()
        {
            return await _bookStoreDbContext.Authors
                .Select(a => new AuthorDTO
                {
                    AuthorName = a.Name,
                    BooksTitles = a.Books.Select(b => b.Title).ToList()
                })
                .ToListAsync();
        }
    }
}
