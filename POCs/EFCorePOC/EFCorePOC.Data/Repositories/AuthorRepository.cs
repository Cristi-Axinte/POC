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
    }
}
