using EFCorePOC.Common.DTOs;
using EFCorePOC.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePOC.Controllers.BookControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateBookController : ControllerBase
    {
        private readonly ICreateBookService _createBookService;

        public CreateBookController(ICreateBookService createBookService)
        {
            _createBookService = createBookService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookDTO bookDTO)
        {
            BookDTO createdBookDto = await _createBookService.CreateBookAsync(bookDTO);

            return Ok(createdBookDto);
        }
    }
}
