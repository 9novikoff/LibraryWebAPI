using LibraryWebAPI.BLL;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Route("api/recommended")]
    public class RecommendationController : ControllerBase
    {
        private LibraryService _service;

        public RecommendationController(LibraryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? genre)
        {
            return genre == null ? Ok(await _service.GetTopBooksAsync())
                : Ok(await _service.GetTopBooksByGenreAsync(genre));
        }

    }
}
