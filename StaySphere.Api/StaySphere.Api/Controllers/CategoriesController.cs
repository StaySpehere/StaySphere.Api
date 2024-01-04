using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.DTOs.Category;
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

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
