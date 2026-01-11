using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;

namespace BlogCommunityAssign.Data.Repos
{
    public class PostRepo : IPostRepo
    {
        public async Task<Post> Create(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Post?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
