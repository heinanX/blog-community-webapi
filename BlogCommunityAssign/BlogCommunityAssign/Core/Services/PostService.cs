using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO.Posts;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using System.Security.Claims;

namespace BlogCommunityAssign.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepo _repo;

        public PostService(IPostRepo repo)
        {
            _repo = repo;
        }

        public async Task<Post> CreatePost(CreatePostDTO post, int id)
        {

            Post newPost = new Post
            {
                UserId = id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _repo.Create(newPost);
        }

        public async Task<bool> DeletePost(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _repo.GetAll();
        }

        public async Task<Post?> GetPostById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<Post?> UpdatePost(int id, bool isAdmin, int? userId, UpdatePostDTO post)
        {
            Post? isPost = await _repo.GetById(id);
            if (isPost == null) return null;

            if (isPost.UserId != userId && !isAdmin)
            {
                throw new UnauthorizedAccessException();
            }

            if (post.Title != null) isPost.Title = post.Title;
            if (post.Content != null) isPost.Content = post.Content;
            isPost.UpdatedAt = DateTime.UtcNow;

            return await _repo.Update(isPost);
            
        }
    }
}
