using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.Interfaces
{
    public interface IPostRepo
    {
        Task<List<Post>> GetAll();

        Task<Post?> GetById(int id);

        Task<Post> Create(Post post);

        Task<Post> Update(Post post);

        Task<bool> Delete(int id);
    }
}
