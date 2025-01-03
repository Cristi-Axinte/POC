using AutoMapper;
using EFCorePOC.Common.DTOs;
using EFCorePOC.Services.Books;

namespace EFCorePOC.Services.Authors
{
    public class GetAuthorsService : IGetAuthorsService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorsService(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        // Fetch full book details
        public async Task<IEnumerable<AuthorDTO>> GetAuthorsWithBooksIncludeAsync()
        {
            return _mapper.Map<IEnumerable<AuthorDTO>> (await _authorRepository.GetAuthorsWithBooksIncludeAsync());
        }

        // Fetch directly titles author details
        public async Task<IEnumerable<AuthorDTO>> GetAuthorsWithSelectAsync()
        {
            return await _authorRepository.GetAuthorsWithSelectAsync();
        }
    }
}
