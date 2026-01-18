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

    }
}
