using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<User?> GetUserByEmailorUsername(string identifier);
        Task<User?> IsExistingEmailorUsername(string username, string email);

        Task<bool> Logout(int id);

        Task<List<User>> GetAll();

        Task<List<User>> GetAllWithComments();

        Task<User?> GetById(int id);

        Task<User?> GetCompleteUserById(int id);

        Task Register(User user);

        Task<User> Update(int id);

        Task<bool> Delete(int id);
    }
}
