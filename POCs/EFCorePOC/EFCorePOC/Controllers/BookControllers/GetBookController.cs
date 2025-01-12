using EFCorePOC.Common.DTOs;
using EFCorePOC.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePOC.Controllers.BookControllers
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
            var books = await _booksService.GetPagedBooksAsync(pageIndex, pageSize);
            return Ok(books);
        }

        [HttpGet("searchByCategory")]
        public async Task<IActionResult> SearchBookByCategory([FromQuery] string categoryName)
        {
            var books = await _booksService.SearchBookByCategoryAsync(categoryName);
            return Ok(books);
        }

        [HttpGet("bookCountByCategory")]
        public async Task<IActionResult> GetBookCountByCategory()
        {
            var books = await _booksService.GetBookCountByCategoryAsync();
            return Ok(books);
        }


        [HttpGet("booksDirectlyAsDTO")]
        public async Task<IActionResult> GetBooksDirectlyAsDTO()
        {
            var books = await _booksService.GetBooksDirectlyAsDTOAsync();
            return Ok(books);
        }

        [HttpGet("bookWithLazyLoading")]
        public async Task<IActionResult> GetBookByIdWithLazyLoading([FromQuery] string id)
        { 
            var book = await _booksService.GetBookByIdWithLazyLoadingAsync(id);

            return Ok(book);
        }

    }
}
