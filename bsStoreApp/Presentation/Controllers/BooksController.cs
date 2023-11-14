using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public BooksController(IServicesManager manager)
        {
            _manager = manager;
        }

        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        [HttpGet]
        public async Task<IActionResult> GetAllbooksAsync([FromQuery] BookParameters bookParameters)
        {
            var linkedParameters = new LinkParameters() 
            {
                BookParameters = bookParameters,
                HttpContext = HttpContext
            };
            var result = await _manager.BookService.GetAllBooksAsync(linkedParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));

            return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) :
                Ok(result.linkResponse.ShapedEntities);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
            var book = await _manager.BookService.GetOneBookByIdAsync(id, false);

            return Ok(book);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            var book = await _manager.BookService.CreateOneBookAsync(bookDto);

            return StatusCode(201, book); // CreatedAtRoute()
        }

        [ServiceFilter(typeof (ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id,
            [FromBody] BookDtoForUpdate bookDto)
        {
            await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);

            return NoContent(); // 204
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.BookService.DeleteOneBookAsync(id, false);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneBookAsync([FromRoute(Name = "id")] int id,
           [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
            if(bookPatch is null)
                return BadRequest(); // 400

            var result = await _manager.BookService.GetOneBookForPatchAsync(id, false);

            bookPatch.ApplyTo(result.bookDtoForUpdate, ModelState);

            TryValidateModel(result.bookDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity();

            await _manager.BookService.SaveChangesForPatchAsync(result.bookDtoForUpdate, result.book);

            return NoContent();
        }
    }
}
