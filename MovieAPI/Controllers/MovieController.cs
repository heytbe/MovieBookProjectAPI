using Entity.API.Dto.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.API.Service.Abstract;

namespace MovieAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IWebHostEnvironment _environment;
        

        public MovieController(IMovieService movieService,IWebHostEnvironment environment)
        {
            _movieService = movieService;
            _environment = environment;
        }

        [HttpGet]
        [Route("movieList")]
        public async Task<IActionResult> MovieAll()
        {

            var response = await _movieService.GetAll();
            return Ok(response);
        }


        [HttpGet]
        [Route("movieid")]
        public async Task<IActionResult> GetIdMovieList([FromQuery]int id)
        {
            var response = await _movieService.GetIdMovieList(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("moviecreate")]
        public async Task<IActionResult> CreateMovie([FromForm]MovieCreateDto movieCreateDto)
        {
            var fileDir = _environment.WebRootPath; 
            var result = await _movieService.CreateMovie(movieCreateDto, fileDir);

            return Ok(result);
        }

        [HttpDelete]
        [Route("deletemovie")]
        public async Task<IActionResult> MovieDelete([FromQuery]int id)
        {
            return Ok(await _movieService.DeleteMovie(id));
        }
    }
}
