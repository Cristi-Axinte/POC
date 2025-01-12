using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public interface IPublisherRepository
    {
        public Task<Publisher> GetByNameAsync(string name);
    }
}
