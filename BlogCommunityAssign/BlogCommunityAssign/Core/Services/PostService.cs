using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Services
{
    public class PostService : IPostService
    {
        public Task<Post> CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post?> GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
