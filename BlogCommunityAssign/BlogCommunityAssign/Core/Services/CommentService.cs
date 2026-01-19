using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO.Comments;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;

namespace BlogCommunityAssign.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IPostRepo _postRepo;
        private readonly ICommentRepo _repo;
        public CommentService(IPostRepo postRepo, ICommentRepo repo)
        {
            _postRepo = postRepo;
            _repo = repo;
        }

        public async Task<int> CreateComment(CreateCommentDTO comment, int postId, int? userId)
        {
            Post? validPostId = await _postRepo.GetById(postId);
            if (validPostId == null) throw new KeyNotFoundException("Post not found.");

            if (validPostId.UserId == userId) throw new UnauthorizedAccessException("You cannot comment on your own post.");

            Comment newComment = new Comment
            {
                Content = comment.Content,
                UserId = userId,
                PostId = postId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _repo.Create(newComment);
            
        }

        public async Task DeleteComment(int id, int userId, bool isAdmin)
        {
            Comment? commentId = await _repo.GetById(id);
            if (commentId == null) throw new KeyNotFoundException($"Comment with {id} not found");

            if (commentId.UserId != userId && !isAdmin) throw new UnauthorizedAccessException();

            await _repo.Delete(commentId);
        }

        public async Task<List<CommentDTO>> GetAllComments()
        {
            List<Comment> comments = await _repo.GetAll();
            return comments.Select(c => new CommentDTO(c)).ToList();
        }

        public async Task<CommentDTO> GetCommentById(int id)
        {
            Comment? commentId = await _repo.GetById(id);
            if (commentId == null) throw new KeyNotFoundException($"Comment with {id} not found");

            return new CommentDTO(commentId);
        }

        public async Task<CommentDTO> UpdateComment(int id, UpdateCommentDTO dto, int userId, bool isAdmin)
        {
            Comment? commentId = await _repo.GetById(id);
            if (commentId == null) throw new KeyNotFoundException($"Comment with {id} not found");

            if (commentId.UserId != userId && !isAdmin) throw new UnauthorizedAccessException();

            commentId.Content = dto.Content;
            commentId.UpdatedAt = DateTime.UtcNow;

            await _repo.SaveDb();

            return new CommentDTO(commentId);

        }
    }
}
