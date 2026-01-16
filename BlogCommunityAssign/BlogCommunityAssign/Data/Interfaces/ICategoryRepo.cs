using BlogCommunityAssign.Data.DTO;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.Interfaces
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAll();


        Task<Category?> GetById(int id);


        Task<Category> Create(Category category);


        Task<CategoryDTO> Update(int id);


        Task<bool> Delete(int id);
    }
}
