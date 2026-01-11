using BlogCommunityAssign.Core.Interfaces;


namespace BlogCommunityAssign.Core.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            // Generate a salt internally, hash password
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Compare plaintext password with stored hash
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
