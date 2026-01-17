using BlogCommunityAssign.Core.Extensions;
using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.DTO.Posts;
using BlogCommunityAssign.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogCommunityAssign.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {

        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {

            List<Post> posts = await _service.GetAllPosts();
            return Ok(posts);

        }

        [HttpGet("{id}")] //by ID
        public async Task<ActionResult> Get(int id)
        {

            Post? post = await _service.GetPostById(id);
            if (post == null) return NotFound("Post not found");

            return Ok(post);

        }


        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult> Post(CreatePostDTO category)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim);

            Post created = await _service.CreatePost(category, userId);

            if (created == null) return BadRequest();
            return Created();
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(int id, UpdatePostDTO postDto)
        {
            try
            {
                int? userId = User.GetUserId();
                if (userId == null) return Unauthorized();
                bool isAdmin = User.IsAdmin();

                Post? updated = await _service.UpdatePost(id, isAdmin, userId, postDto);
                if (updated == null) return NotFound();

                return Ok(updated.Title);

            } catch (UnauthorizedAccessException)
            {
                return Forbid();
            }

        }


        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();
            bool isAdmin = User.IsAdmin();

            int userId = int.Parse(userIdClaim);

            bool deleted = await _service.DeletePost(id, userId, isAdmin);
            if (!deleted) return BadRequest("Not a valid id");

            return Ok("Post deleted!");

        }


    }
}
