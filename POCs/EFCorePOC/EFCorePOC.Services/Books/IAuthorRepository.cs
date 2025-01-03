using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public interface IAuthorRepository
    {
        public Task<Author> GetByNameAsync(string name);

        public Task<IEnumerable<Author>> GetAuthorsWithBooksIncludeAsync();

        public Task<IEnumerable<AuthorDTO>> GetAuthorsWithSelectAsync();
    }
}
