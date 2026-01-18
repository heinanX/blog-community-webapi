using BlogCommunityAssign.Core.Extensions;
using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogCommunityAssign.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            List<UserDTO> users = await _service.GetAllUsers();
            return Ok(users);
        }
        //[HttpGet]
        //public async Task<ActionResult<List<UserDTO>>> GetUsersAndComments()
        //{
        //    List<UserDTO> users = await _service.GetAllUsersWithComments();
        //    return Ok(users);
        //}


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null) return Unauthorized();
                int userId = int.Parse(userIdClaim);
                bool isAdmin = User.IsAdmin();

                UserDTO? user = await _service.GetUserById(id, userId, isAdmin);
                if (user == null) return NotFound();

                return Ok(user);
            } catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }


        [HttpGet("details/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetDetailsById(int id)
        {
            UserWithPostsAndCommentsDTO? detailedUser = await _service.GetDetailedUserById(id);
            if (detailedUser == null) return NotFound();

            return Ok(detailedUser);
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterUserDTO newUserDTO)
        {
            try
            {
                UserDTO user = await _service.CreateUser(newUserDTO);

                return Created($"{user.Username} created", user);

            } catch (InvalidOperationException ex) {

                return BadRequest(ex.Message);
            }

        }


        [HttpPut("update/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateUser(int id, UpdateUserDTO userDto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null) return Unauthorized();

                int userId = int.Parse(userIdClaim);
                bool isAdmin = User.IsAdmin();

                await _service.UpdateUser(id, userId, isAdmin, userDto);

                return NoContent();
                //return NoContent($"User {id} updated!", user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim);
            bool isAdmin = User.IsAdmin();

            int? deleted = await _service.DeleteUser(id, userId, isAdmin);
            if (deleted == null) return NotFound();

            return Ok($"user {deleted} deleted!");

        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserDTO credentials)
        {
            UserDTO? user = await _service.Login(credentials);

            if (user == null) return Unauthorized("Incorrect login");

            AuthResponseDTO tokenUser = new AuthResponseDTO(user.Id, user.Username, user.Email, "", user.IsAdmin);

            string token = _service.GenerateToken(tokenUser);

            tokenUser.Token = token;

            return Ok(tokenUser);
        }

    }
}
