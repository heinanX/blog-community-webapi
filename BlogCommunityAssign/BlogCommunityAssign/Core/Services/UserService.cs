using BlogCommunityAssign.Core.Configuration;
using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.DTO.Users;
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

        public async Task<UserDTO> CreateUser(RegisterUserDTO newUserDTO)
        {
            User? existingUser = await _repo.IsExistingEmailorUsername(newUserDTO.Username, newUserDTO.Email);
            if (existingUser != null) throw new InvalidOperationException("username or email is already taken");

            User newUser = new User
            {
                Username = newUserDTO.Username,
                Email = newUserDTO.Email
            };

            newUser.Password = _passwordService.HashPassword(newUserDTO.Password);

            await _repo.Register(newUser);

            return new UserDTO(newUser);

        }

        public async Task<int?> DeleteUser(int id, int userId, bool isAdmin)
        {
            User? existingUser = await _repo.GetById(id);
            if (existingUser == null) return null;

            if (existingUser.Id != userId && !isAdmin)
            {
                throw new UnauthorizedAccessException();
            }

            await _repo.Delete(id);
            return id;
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

        public async Task<List<UserDTO>> GetAllUsers()
        {
            List<User> users = await _repo.GetAll();
            return users.Select(u => new UserDTO(u)).ToList();
        }

        public async Task<List<UserDTO>> GetAllUsersWithComments()
        {
            List<User> users = await _repo.GetAllWithComments();

            return  users.Select(u => new UserDTO(u)).ToList();

        }

        public async Task<UserWithPostsAndCommentsDTO?> GetDetailedUserById(int id)
        {
            User? user = await _repo.GetDetailedById(id);
            if (user == null) return null;

            UserWithPostsAndCommentsDTO detailedUser = new UserWithPostsAndCommentsDTO(user);
            return detailedUser;

        }

        public async Task<UserDTO?> GetUserById(int id, int userId, bool isAdmin)
        {
            User? user = await _repo.GetById(id);
            if (user == null) return null;

            if (user.Id == userId) throw new UnauthorizedAccessException();

            
            UserDTO userDto = new UserDTO (user);

            return userDto;

        }

        public async Task<UserDTO?> Login(LoginUserDTO credentials)
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

        public async Task UpdateUser(int id, int userId, bool isAdmin, UpdateUserDTO userDto)
        {
            User? existingUser = await _repo.GetById(id);
            if (existingUser == null) throw new KeyNotFoundException($"Username with {id} not found");

            if (existingUser.Id != userId && !isAdmin)
            {
                throw new UnauthorizedAccessException();
            }

            
            if (userDto.Username != null && userDto.Username != existingUser.Username)
            {
                User? usernameTaken = await _repo.IsExistingUsername(userDto.Username!);
                if (usernameTaken != null) throw new InvalidOperationException("Username already taken");

                existingUser.Username = userDto.Username;
            }

            if (userDto.Email != null && userDto.Email != existingUser.Email) 
            {
                User? emailTaken = await _repo.IsExistingEmail(userDto.Email!);
                if (emailTaken != null) throw new InvalidOperationException("Email already taken");
                existingUser.Email = userDto.Email;
            }
                
            
            if (userDto.Password != null)
            {
                existingUser.Password = _passwordService.HashPassword(userDto.Password);
            }

            await _repo.Update();
        }
    }
}
