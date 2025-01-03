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
        
        //This will work even if the categories that you add don`t exist currently in DB 
        //THIS WONT WORK BECAUSE INMEMORY DB DOES NOT SUPPORT TRANSACTIONS, i will leave it here just because it was good practice
        [HttpPost("createWithTransaction")]
        public async Task<IActionResult> CreateBookWithTransaction([FromBody] BookDTO bookDTO)
        {
            BookDTO createdBookDto = await _createBookService.CreateBookWithTransactionAsync(bookDTO);

            return Ok(createdBookDto);
        }
    }
}
