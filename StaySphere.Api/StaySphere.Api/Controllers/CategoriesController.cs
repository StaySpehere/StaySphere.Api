using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.DTOs.Category;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Services;


namespace StaySphere.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get() 
        {
           var categories = _categoryService.GetCategories();
           
           return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<CategoryDto> Get(int id)
        {
           var category = _categoryService.GetCategoryById(id);
          
           return Ok(category);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CategoryForCreateDto category)
        {
            _categoryService.CreateCategory(category);
          
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CategoryForUpdateDto category)
        {
            if(id != category.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {category.Id}.");
            }
            _categoryService.UpdateCategory(category);
         
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
          
            return NoContent();
        }
    }
}
