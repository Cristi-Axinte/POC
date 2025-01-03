using EFCorePOC.Common.DTOs;

namespace EFCorePOC.Services.Authors
{
    public interface IGetAuthorsService
    {
        public Task<IEnumerable<AuthorDTO>> GetAuthorsWithBooksIncludeAsync();

        public Task<IEnumerable<AuthorDTO>> GetAuthorsWithSelectAsync();
    }
}
