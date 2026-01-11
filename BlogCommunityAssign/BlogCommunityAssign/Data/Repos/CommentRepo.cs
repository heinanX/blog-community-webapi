using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;

namespace BlogCommunityAssign.Data.Repos
{
    public class CommentRepo : ICommentRepo
    {
        public async Task<Comment> Create(Comment comment)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Comment?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
