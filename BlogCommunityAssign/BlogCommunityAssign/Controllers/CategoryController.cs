using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO.Categories;
using BlogCommunityAssign.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> GetAll()
        {
            List<Category> categories = await _service.GetAllCategories();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Category? category = await _service.GetCategoryById(id);
            if (category == null) return NotFound("Category not found");

            return Ok(category);
        }


        [HttpPost("create")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Post(CreateCategoryDTO category)
        {

            Category? created = await _service.AddCategory(category);
            if (created == null) return BadRequest();

            return Created();
        }


        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put(int id, UpdateCategoryDTO category)
        {

            Category? updated = await _service.UpdateCategory(id, category);
            if (category == null) return NotFound();

            return NoContent();
            
        }


        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteCategory(id);
                return NoContent();
            } catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    
    
    }
}
