using Entity.API.Dto.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.API.Service.Abstract;

namespace MovieAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IWebHostEnvironment _environment;

        public CategoryController(ICategoryService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }
        
        [HttpGet]
        [Route("categorylist")]
        public async Task<IActionResult> CategoryList()
        {
            return Ok(await _service.CategoryList());
        }

        [HttpPost]
        [Route("categorycreate")]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryDto categoryDto)
        { 
            var categoryimage = _environment.WebRootPath;
            return Ok(await _service.CreateCategory(categoryDto,categoryimage));
        }

        [HttpGet]
        [Route("findmovie")]
        public async Task<IActionResult> FindMovie(int id)
        {
            return Ok( await _service.FindMovie(id));
        }
    }
}
