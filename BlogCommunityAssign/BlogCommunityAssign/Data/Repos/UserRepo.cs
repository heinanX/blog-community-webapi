using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public async Task<User?> GetCompleteUserById(int id)
        {
            throw new NotImplementedException();
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

        public async Task<User> Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
