using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using BlogCommunityAssign.Data.Repos;
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

        public Task<UserDTO> CreateUser(RegisterNewUserDTO user)
        {
            throw new NotImplementedException();
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
            User? user = await _repo.Login(credentials);

            if (user == null) return null;

            bool isValid = _passwordService.VerifyPassword(user, user.Password, credentials.Password);
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
