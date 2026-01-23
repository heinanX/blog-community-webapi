using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.Interfaces
{
    public interface IPostRepo
    {
        Task<List<Post>> GetAll();

        Task<Post?> GetById(int id);

        Task<Post> Create(Post post);

        Task<Post> Update(Post post);

        Task Delete(Post post);

        Task<List<Post>> SearchByTitle(string searchTerm);
        Task<List<Post>> SearchByCategory(string searchTerm);
        Task<List<Category>> GetCategoriesByNames(IEnumerable<string> names);
    }
}
