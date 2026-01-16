using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogCommunityAssign.Data.Repos
{
    public class PostRepo : IPostRepo
    {
        private readonly ApplicationDbContext _db;

        public PostRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Post> Create(Post post)
        {
            _db.Add(post);
            await _db.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Delete(int id)
        {
            Post? isPost = await GetById(id);
            if (isPost == null) return false;

            _db.Remove(isPost);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _db.Posts.ToListAsync();
        }

        public async Task<Post?> GetById(int id)
        {
            return await _db.Posts.FindAsync(id);
        }

        public async Task<Post> Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
