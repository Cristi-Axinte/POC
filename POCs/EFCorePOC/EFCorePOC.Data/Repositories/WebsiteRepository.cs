using EFCorePOC.Common.Entities;
using EFCorePOC.Services.Books;
using Microsoft.EntityFrameworkCore;

namespace EFCorePOC.Data.Repositories
{
    public class WebsiteRepository : IWebsiteRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public WebsiteRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<Website> GetByUrlAsync(string url)
        {
            return await _bookStoreDbContext.Websites.FirstOrDefaultAsync(w => w.AddressUrl == url);
        }
    }
}
