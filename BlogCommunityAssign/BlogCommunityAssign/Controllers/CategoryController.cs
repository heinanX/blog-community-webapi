using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace BlogCommunityAssign.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            //List<Category> categories = CategoryRepo.GetAllCategories(); // <- Links to method found in repo
            //return Ok(categories)
            return Ok("was successful");
        }

        [HttpGet("{id}")] //by ID
        public ActionResult Get(int id)
        {
            //Category category = CategoryRepo.GetCategoryById(id);
            // return Ok(categories)
            return Ok("categories are here");
        }


        [HttpPost]
        public ActionResult Post(Category category)
        {
            //CategoryRepo.CreateProduct(category);

            return Ok(category);
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
        public ActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("Not a valid id");
            //CategoryRepo.DeleteCategory(id);
            return Ok();
        }
    
    
    }
}
