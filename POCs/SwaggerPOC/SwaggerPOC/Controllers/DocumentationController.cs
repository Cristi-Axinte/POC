using Microsoft.AspNetCore.Mvc;
using SwaggerPOC.Models;
using System.Text.Json;

namespace SwaggerPOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentationController : ControllerBase
    {
        /// <summary>
        /// This is just a random documentation for Post Request
        /// </summary>
        /// <returns> Should return OkResult </returns>
        [HttpPost]
        public async Task<IActionResult> TestPostDocumentation()
        {
            return Ok();
        }


        /// <summary>
        /// Post request with object
        /// </summary>
        /// <param name="model"> The model that has to be sent <see cref="Model"/> </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Model
        ///     {
        ///        "ModelName": "test",
        ///        "ModelValue": 1,
        ///     }
        /// </remarks>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("postWithValue")]
        public async Task<IActionResult> TestPostDocumentation(Model model)
        {
            if (model == null) 
            {
                return BadRequest();
            }
            return Ok();
        }

        /// <summary>
        /// This endpoint should support a response content type of application/json:
        /// </summary>
        /// <returns> Should return OkResult </returns>
        [HttpPost("responseContentTypeJson")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]  
        public async Task<IActionResult> TestDocumentationWithReponseSupport()
        {
            Model model = new Model
            {
                ModelName = "Test",
                ModelStringRequired = "Test2",
                ModelValue = 1,
            };

            string jsonString = JsonSerializer.Serialize(model);

            return Ok(jsonString);
        }

        /// <summary>
        /// This is just a random documentation for Get Request
        /// </summary>
        /// <returns> Should return OkResult </returns>
        [HttpGet]
        public async Task<IActionResult> TestGetDocumentation()
        {
            return Ok();
        }
    }
}
