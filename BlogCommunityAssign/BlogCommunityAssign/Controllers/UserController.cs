using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Core.Services;
using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Repos;
using Microsoft.AspNetCore.Mvc;

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


        //private readonly UserRepo _userRepo;

        //public UserController(UserRepo userRepo)
        //{
        //    _userRepo = userRepo;
        //}

        //[HttpGet]
        //public IActionResult GetUsers()
        //{
        //    List<User> users = _userRepo.GetAllUsers();
        //    return Ok(users);
        //}

        //[HttpGet]
        //public IActionResult GetUsersAndComments()
        //{
        //    List<UserDTO> users = _userRepo.GetAllUsersWithComments();
        //    return Ok(users);
        //}
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsersAndComments()
        {
            List<UserDTO> users = await _service.GetAllUsersWithComments();
            return Ok(users);
        }


        //[HttpGet("{id}")] //by ID
        //public IActionResult GetUserById(int id)
        //{
        //    return Ok();
        //}


        [HttpPost("register")]
        public IActionResult RegisterUser(User user)
        {
            return Created();
        }


        //[HttpPut]


        //[HttpDelete]


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginCredentialsDTO credentials)
        {
            UserDTO? user = await _service.Login(credentials);

            if (user == null) return Unauthorized("Incorrect login");

            return Ok($"User {user.Username} is logged in"); // also where you add a token I guess?
        }


    }
}
