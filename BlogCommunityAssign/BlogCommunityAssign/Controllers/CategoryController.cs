using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogCommunityAssign.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Category> categories = await _service.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")] //by ID
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                Category? category = await _service.GetCategoryById(id);
                if (category == null) return NotFound("Category not found");

                return Ok(category);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateCategoryDTO category)
        {
            try
            {
                CategoryDTO created = await _service.AddCategory(category);

                return Ok(created);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut]
        public ActionResult Put(Category category)
        {
            if (category == null)
            {
                return NotFound();
            }

            //CategoryRepo.UpdateCategory(category);
            return Ok(category);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool success = await _service.DeleteCategory(id);
                if (!success) return BadRequest("Not a valid id");
                return Ok("Category deleted!");

            } catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    
    
    }
}
