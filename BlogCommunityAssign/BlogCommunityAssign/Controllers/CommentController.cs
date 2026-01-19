using BlogCommunityAssign.Core.Extensions;
using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.DTO.Comments;
using BlogCommunityAssign.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogCommunityAssign.Controllers
{
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
        public async Task<ActionResult> Get()
        {
            var comments = await _service.GetAllComments();
            return Ok(comments);
        }

        [HttpPost("/api/posts/{postId}/comments")]
        [Authorize]
        public async Task<ActionResult> Post(int postId, CreateCommentDTO dto)
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
                return Forbid(ex.Message);
            }
        }


    }
}
