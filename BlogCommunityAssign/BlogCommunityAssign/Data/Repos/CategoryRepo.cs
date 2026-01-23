using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogCommunityAssign.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category> Create(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task Delete(Category category)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<Category> Update(Category category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return category;
        }
    }
}
