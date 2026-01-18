using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<User?> GetUserByEmailorUsername(string identifier);

        Task<User?> IsExistingEmailorUsername(string username, string email);
        
        Task<User?> IsExistingEmail(string email);
        
        Task<User?> IsExistingUsername(string username);

        Task<List<User>> GetAll();

        Task<List<User>> GetAllWithComments();

        Task NullifyUserPosts(int userId);
        
        Task NullifyUserComments(int userId);

        Task<User?> GetById(int id);

        Task<User?> GetDetailedById(int id);

        Task Register(User user);

        Task Update();

        void Delete(User existingUser);
    }
}
