using EFCorePOC.Data.Repositories;
using EFCorePOC.Services.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePOC.Controllers.AuthorControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAuthorController : ControllerBase
    {
        private readonly IGetAuthorsService _getAuthorsService;

        public GetAuthorController(IGetAuthorsService getAuthorService)
        {
            _getAuthorsService = getAuthorService;
        }

        [HttpGet("getWithIncludeOnBooks")]
        public async Task<IActionResult> GetAuthorsWithBooksInclude()
        {
            var authors = await _getAuthorsService.GetAuthorsWithBooksIncludeAsync();
            return Ok(authors);
        }

        [HttpGet("getWithSelectOnBooks")]
        public async Task<IActionResult> GetAuthorsWithSelect()
        {
            var authors = await _getAuthorsService.GetAuthorsWithSelectAsync();
            return Ok(authors);
        }
    }
}
