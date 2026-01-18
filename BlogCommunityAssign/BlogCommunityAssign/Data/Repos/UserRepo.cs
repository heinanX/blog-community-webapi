using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlogCommunityAssign.Data.Repos
{
    public class UserRepo : IUserRepo
    {

        private readonly ApplicationDbContext _db;

        public UserRepo(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task Register(User user)
        {
            _db.Add(user);
            await _db.SaveChangesAsync();
        }

        public void Delete(User user)
        {
            _db.Remove(user);
        }


        public async Task<List<User>> GetAll()
        {
            return await _db.Users
                .ToListAsync();
        }

        public async Task<List<User>> GetAllWithComments()
        {
            return await _db.Users
                .Include(u => u.Comments)
                .ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<User?> GetDetailedById(int id)
        {
            return await _db.Users
                .Include(u => u.Comments)
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByEmailorUsername(string identifier)
        {
            return await _db.Users
                .FirstOrDefaultAsync(u =>
                u.Username == identifier ||
                u.Email == identifier
                );

        }

        public async Task<User?> IsExistingEmailorUsername(string username, string email)
        {
            return await _db.Users
                 .FirstOrDefaultAsync(u =>
                 u.Username == username ||
                 u.Email == email
                 );
        }

        public async Task<bool> Logout(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<User?> IsExistingEmail(string email)
        {
            return await _db.Users
                 .FirstOrDefaultAsync(u =>
                 u.Email == email
                 );
        }

        public async Task<User?> IsExistingUsername(string username)
        {
            return await _db.Users
                .FirstOrDefaultAsync(u =>
                u.Username == username
                );
        }

        public async Task NullifyUserPosts(int userId)
        {
            await _db.Posts
                   .Where(p => p.UserId == userId)
                   .ForEachAsync(p => p.UserId = null);
        }

        public async Task NullifyUserComments(int userId)
        {
            await _db.Comments
                    .Where(c => c.UserId == userId)
                    .ForEachAsync(c => c.UserId = null);
        }
    }
}
