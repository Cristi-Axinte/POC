using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public interface IWebsiteRepository
    {
        public Task<Website> GetByUrlAsync(string url);
    }
}
