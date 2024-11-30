using EFCorePOC.Common.Entities;
using EFCorePOC.Services.Books;
using Microsoft.EntityFrameworkCore;

namespace EFCorePOC.Data.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public PublisherRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<Publisher> GetByNameAsync(string name)
        {
            return await _bookStoreDbContext.Publisher.FirstOrDefaultAsync(a => a.Name == name);
        }
    }
}
