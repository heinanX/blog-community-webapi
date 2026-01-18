using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.DTO.Users;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> Login(LoginUserDTO credentials);

        Task<bool> Logout(int id);

        string GenerateToken(AuthResponseDTO user);

        Task<List<UserDTO>> GetAllUsers();

        Task<List<UserDTO>> GetAllUsersWithComments();

        Task<UserDTO?> GetUserById(int id, int userId, bool isAdmin);

        Task<UserWithPostsAndCommentsDTO?> GetDetailedUserById(int id);

        Task<UserDTO> CreateUser(RegisterUserDTO user);

        Task UpdateUser(int id, int userId, bool isAdmin, UpdateUserDTO UserDto);

        Task<int?> DeleteUser(int id, int userId, bool isAdmin);

    }
}
