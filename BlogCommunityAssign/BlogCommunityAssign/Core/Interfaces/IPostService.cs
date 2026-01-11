using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();


        Task<Post?> GetPostById(int id);


        Task<Post> CreatePost(Post post);


        Task<Post> UpdatePost(int id);


        Task<bool> DeletePost(int id);
    }
}
