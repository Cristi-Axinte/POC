using EFCorePOC.Common.DTOs;
using EFCorePOC.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateBookController : ControllerBase
    {
        private readonly IUpdateBookService _updateBookService;

        public UpdateBookController(IUpdateBookService updateBookService)
        {
            _updateBookService = updateBookService;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(BookDTO bookDTO)
        {
            var result = await _updateBookService.UpdateBookAsync(bookDTO);
            return Ok(result);
        }
    }
}
