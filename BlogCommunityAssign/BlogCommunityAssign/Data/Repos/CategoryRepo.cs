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
            _db.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int id)
        {
            Category? isCategory = await _db.Categories.FindAsync(id);
            if (isCategory == null) return false;

            _db.Remove(isCategory);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public Task<List<Category>> GetByNames(IEnumerable<string> names)
        {
            var normalized = names.Select(n => n.Trim().ToLower());

            return _db.Categories
                .Where(c => normalized.Contains(c.CategoryName.ToLower()))
                .ToListAsync();
        }

        public async Task<Category> Update(Category category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return category;
        }
    }
}
