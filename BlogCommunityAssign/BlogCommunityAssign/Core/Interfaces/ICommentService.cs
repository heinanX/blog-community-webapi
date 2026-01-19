using BlogCommunityAssign.Data.DTO.Comments;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAllComments();


        Task<Comment?> GetCommentById(int id);


        Task<int?> CreateComment(CreateCommentDTO comment, int postId, int? userId);


        Task<Comment> UpdateComment(int id);


        Task<bool> DeleteComment(int id);
    }
}
