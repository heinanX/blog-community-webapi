using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult> RegisterUser(RegisterNewUserDTO newUserDTO)
        {
            UserDTO user = await _service.CreateUser(newUserDTO);

            return StatusCode(201, new
            {
                message = "User created successfully",
                user
            });
        }


        [HttpPut("/update-user/{id}")]
        [Authorize]
        public IActionResult UpdateUser(int id)
        {
            return Ok($"{id} updated");
        }

        //[HttpDelete]


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginCredentialsDTO credentials)
        {
            UserDTO? user = await _service.Login(credentials);

            if (user == null) return Unauthorized("Incorrect login");

            AuthResponseDTO tokenUser = new AuthResponseDTO(user.Id, user.Username, user.Email, "", user.IsAdmin);

            string token = _service.GenerateToken(tokenUser);

            tokenUser.Token = token;

            return Ok(tokenUser); // also where you add a token I guess?
        }


    }
}
