using BlogCommunityAssign.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface IPasswordService
    {
        bool VerifyPassword(string password1, string password2);

        string HashPassword(string password);
    }
}
