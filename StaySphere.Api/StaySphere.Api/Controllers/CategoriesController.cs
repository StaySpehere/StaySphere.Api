
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Category;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesAsync(
               [FromQuery] CategoryResourceParameters parameters)
        {
            var categories = await _categoryService.GetCategoriesAsync(parameters);
            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryForCreateDto category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryForUpdateDto category)
        {
            if (id != category.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {category.Id}.");
            }
           await _categoryService.UpdateCategoryAsync(category);
           return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
