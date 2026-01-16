using BlogCommunityAssign.Core.Configuration;
using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogCommunityAssign.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IPasswordService _passwordService;
        private readonly JwtSettings _jwt;

        public UserService(IUserRepo userRepo, IPasswordService passwordService, IOptions<JwtSettings> jwt)
        {
            _repo = userRepo;
            _passwordService = passwordService;
            _jwt = jwt.Value;
        }

        public async Task<UserDTO> CreateUser(RegisterNewUserDTO newUserDTO)
        {
            User? existingUser = await _repo.IsExistingEmailorUsername(newUserDTO.Username, newUserDTO.Email);
            if (existingUser != null) throw new Exception("username or email is already taken");

            User newUser = new User
            {
                Username = newUserDTO.Username,
                Email = newUserDTO.Email
            };

            newUser.Password = _passwordService.HashPassword(newUserDTO.Password);

            await _repo.Register(newUser);

            return new UserDTO(newUser);

        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public string GenerateToken(AuthResponseDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken
            (
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
            claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.Duration),
                signingCredentials: signinCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDTO>> GetAllUsersWithComments()
        {
            List<User> users = await _repo.GetAllWithComments();

            return  users.Select(u => new UserDTO(u)).ToList();

        }

        public Task<User?> GetFullUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO?> Login(LoginCredentialsDTO credentials)
        {
            User? user = await _repo.GetUserByEmailorUsername(credentials.Identifier);

            if (user == null) return null;
       
            bool isValid = _passwordService.VerifyPassword(credentials.Password, user.Password);
            if (!isValid) return null;

            UserDTO userDTO = new UserDTO(user);

            return userDTO;
        }


        public Task<bool> Logout(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
