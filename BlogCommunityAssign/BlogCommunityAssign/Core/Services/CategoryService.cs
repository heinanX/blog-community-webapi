using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<Category> CreateCategory(Category Category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
