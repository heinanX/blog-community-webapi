using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Services
{
    public class CommentService : ICommentService
    {
        public Task<Comment> CreateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public Task<Comment?> GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> UpdateComment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
