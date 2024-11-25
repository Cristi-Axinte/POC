using EFCorePOC.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteBookController : ControllerBase
    {
        private readonly IDeleteBookService _deleteBookService;

        public DeleteBookController(IDeleteBookService deleteBookService)
        {
            _deleteBookService = deleteBookService;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var result = await _deleteBookService.DeleteBookAsync(id);

            return Ok(result);
        }
    }
}
