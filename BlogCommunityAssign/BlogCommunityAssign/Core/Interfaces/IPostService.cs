using BlogCommunityAssign.Data.DTO.Posts;
using BlogCommunityAssign.Data.Entities;
using System.Security.Claims;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();


        Task<Post?> GetPostById(int id);


        Task<Post> CreatePost(CreatePostDTO post, int id);


        Task<Post?> UpdatePost(int id, bool isAdmin, int? userId, UpdatePostDTO post);


        Task<bool> DeletePost(int id);
    }
}
