using BlogCommunityAssign.Core.Extensions;
using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogCommunityAssign.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<CommentDTO> comments = await _service.GetAllComments();
            return Ok(comments);
        }


        [HttpPost("/api/posts/{postId}/comments")]
        public async Task<ActionResult> Create(int postId, CreateCommentDTO dto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null) return Unauthorized();
                int userId = int.Parse(userIdClaim);

                int? commentId = await _service.CreateComment(dto, postId, userId);

                return Created();

            } catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);

            } catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                CommentDTO comment = await _service.GetCommentById(id);
                return Ok(comment);

            } catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Update(int id, UpdateCommentDTO dto)
        {
            try { 
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();
            int userId = int.Parse(userIdClaim);
            bool isAdmin = User.IsAdmin();

            CommentDTO comment = await _service.UpdateComment(id, dto, userId, isAdmin);
            return Ok(comment);
        
            } catch (UnauthorizedAccessException)
            {
                return Unauthorized();

            } catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null) return Unauthorized();
                int userId = int.Parse(userIdClaim);
                bool isAdmin = User.IsAdmin();

                await _service.DeleteComment(id, userId, isAdmin);

                return Ok($"Comment: {id}, deleted!");
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
