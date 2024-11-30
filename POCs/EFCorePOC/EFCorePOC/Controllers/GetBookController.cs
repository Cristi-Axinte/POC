using EFCorePOC.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetBookController : ControllerBase
    {
        private readonly IGetBooksService _booksService;

        public GetBookController(IGetBooksService getBooksService)
        {
            _booksService = getBooksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooksById(string id)
        {
            var book = await _booksService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpGet("{pageIndex}/{pageSize}")]
        public async Task<IActionResult> GetBooksById(int pageIndex, int pageSize)
        {
            var book = await _booksService.GetPagedBooksAsync(pageIndex, pageSize);
            return Ok(book);
        }
    }
}
