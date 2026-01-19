using BlogCommunityAssign.Data.DTO.Comments;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Core.Interfaces
{
    public interface ICommentService
    {
        Task<List<CommentDTO>> GetAllComments();


        Task<CommentDTO> GetCommentById(int id);


        Task<int> CreateComment(CreateCommentDTO comment, int postId, int? userId);


        Task<CommentDTO> UpdateComment(int id, UpdateCommentDTO dto, int userId, bool isAdmin);


        Task DeleteComment(int id, int userId, bool isAdmin);
    }
}
