using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetByNameAsync(IEnumerable<string> categoryNames);
    }
}
