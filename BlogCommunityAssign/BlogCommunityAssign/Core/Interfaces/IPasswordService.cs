using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface IPasswordService
    {

        public string HashPassword(User user, string password);
        public bool VerifyPassword(User user, string hashedPassword, string password);
    }
}
