using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAllComments();


        Task<Comment?> GetCommentById(int id);


        Task<Comment> CreateComment(Comment comment);


        Task<Comment> UpdateComment(int id);


        Task<bool> DeleteComment(int id);
    }
}
