using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();


        Task<Category?> GetCategoryById(int id);


        Task<CategoryDTO> AddCategory(CreateCategoryDTO category);


        Task<CategoryDTO> UpdateCategory(int id);


        Task<bool> DeleteCategory(int id);
    }
}
