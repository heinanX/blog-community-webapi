using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogCommunityAssign.Core.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<User> _hasher;

        public PasswordService(IPasswordHasher<User> hasher)
        {
            _hasher = hasher;
        }

        public string HashPassword(User user, string password)
        {
            return _hasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string hashedPassword, string password)
        {
            // Because these two are enums, and they're basically a namned integer type (aka integers under the hood),
            // they can be compared using the == comparison (Ie. this results in 1 == 1)
            return _hasher.VerifyHashedPassword(user, hashedPassword, password) == PasswordVerificationResult.Success;
        }
    }
}
