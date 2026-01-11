using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();


        Task<Category?> GetCategoryById(int id);


        Task<Category> CreateCategory(Category category);


        Task<Category> UpdateCategory(int id);


        Task<bool> DeleteCategory(int id);
    }
}
