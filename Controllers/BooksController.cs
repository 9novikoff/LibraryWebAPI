using System.Formats.Asn1;
using LibraryWebAPI.BLL;
using LibraryWebAPI.DTOModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryService _service;

        public BooksController(LibraryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? order)
        {
            return order switch
            {
                null => Ok(await _service.GetAllBooksAsync()),
                "author" => Ok(await _service.GetBooksOrderedByAuthorAsync()),
                "title" => Ok(await _service.GetBooksOrderedByTitleAsync()),
                _ => BadRequest(),
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var book = await _service.GetDetailedBookByIdAsync(id);

            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(PutBook book)
        {
            if (book == null)
                return NotFound();
            return Ok(new {Id = await _service.AddBookAsync(book)});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] string? secret)
        {
            var isDeleted = await _service.TryToDeleteAsync(id, secret);

            if(isDeleted)
                return Ok();
            return NotFound();
        }

        [HttpPut("{id}/review")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id == 0)
                return NotFound();
            return Ok(new { Id = await _service.AddReviewAsync(id, review)});
        }

        [HttpPut("{id}/rate")]
        public async Task<IActionResult> PutRate(int id, Rating rating)
        {
            if (id == 0)
                return NotFound();
            return Ok(new { Id = await _service.AddRatingAsync(id, rating) });
        }
    }
}
