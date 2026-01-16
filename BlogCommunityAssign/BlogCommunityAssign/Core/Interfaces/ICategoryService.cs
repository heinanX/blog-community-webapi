using BlogCommunityAssign.Data.DTO.Categories;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();


        Task<Category?> GetCategoryById(int id);


        Task<Category?> AddCategory(CreateCategoryDTO category);


        Task<Category?> UpdateCategory(int id, UpdateCategoryDTO category);


        Task<bool> DeleteCategory(int id);
    }
}
