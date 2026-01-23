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

        public async Task Delete(Post post)
        {
            _db.Remove(post);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAll()
        {
            return await _db.Posts.ToListAsync();
        }

        public async Task<Post?> GetById(int id)
        {
            return await _db.Posts.FindAsync(id);
        }

        public async Task<List<Post>> SearchByTitle(string searchTerm)
        {
            return await _db.Posts
                .Where(p => p.Title.Contains(searchTerm))
                .ToListAsync();
        }
        public async Task<List<Post>> SearchByCategory(string searchTerm)
        {
            return await _db.Posts
                    .Include(p => p.Categories)
                    .Where(p => p.Categories.Any(c => c.CategoryName == searchTerm))
                    .ToListAsync();
        }

        public async Task<Post> Update(Post post)
        {
            await _db.SaveChangesAsync();
            return post;
        }

        public Task<List<Category>> GetCategoriesByNames(IEnumerable<string> names)
        {
            return _db.Categories
                .Where(c => names.Contains(c.CategoryName.ToLower()))
                .ToListAsync();
        }
    }
}
