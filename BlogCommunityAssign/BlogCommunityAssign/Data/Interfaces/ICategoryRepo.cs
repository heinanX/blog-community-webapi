using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.Interfaces
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAll();


        Task<Category?> GetById(int id);

        Task<List<Category>> GetByNames(IEnumerable<string> names);


        Task<Category> Create(Category category);


        Task<Category> Update(Category category);


        Task<bool> Delete(int id);
    }
}
