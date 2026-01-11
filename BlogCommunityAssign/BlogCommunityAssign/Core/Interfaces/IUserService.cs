using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> Login(LoginCredentialsDTO credentials);

        Task<bool> Logout(int id);

        Task<List<User>> GetAllUsers();

        Task<List<UserDTO>> GetAllUsersWithComments();

        Task<User?> GetUserById(int id);

        Task<User?> GetFullUserById(int id);

        Task<UserDTO> CreateUser(RegisterNewUserDTO user);

        Task<User> UpdateUser(int id);

        Task<bool> DeleteUser(int id);

    }
}
