using Azure.Identity;
using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using BlogCommunityAssign.Data.Repos;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BlogCommunityAssign.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IPasswordService _passwordService;

        public UserService(IUserRepo userRepo, IPasswordService passwordService)
        {
            _repo = userRepo;
            _passwordService = passwordService;
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
            //Console.WriteLine("Stored hash: " + user.Password);
            //Console.WriteLine("Provided password: '" + credentials.Password + "'");

            bool isValid = _passwordService.VerifyPassword(credentials.Password, user.Password);
            //Console.WriteLine($"this is from inside login method and isValid: {isValid}");
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
