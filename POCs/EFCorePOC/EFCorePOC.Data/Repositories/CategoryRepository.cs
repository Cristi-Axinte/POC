using EFCorePOC.Common.Entities;
using EFCorePOC.Services.Books;
using Microsoft.EntityFrameworkCore;

namespace EFCorePOC.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public CategoryRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<IEnumerable<Category>> GetByNameAsync(IEnumerable<string> categoryNames)
        {
            return await _bookStoreDbContext.Categories
                   .Where(c => categoryNames.Contains(c.Name))
                   .ToListAsync();
        }
    }
}
