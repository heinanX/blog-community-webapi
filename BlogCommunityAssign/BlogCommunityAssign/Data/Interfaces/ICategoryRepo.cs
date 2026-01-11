using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.Interfaces
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAll();


        Task<Category?> GetById(int id);


        Task<Category> Create(Category Category);


        Task<Category> Update(int id);


        Task<bool> Delete(int id);
    }
}
