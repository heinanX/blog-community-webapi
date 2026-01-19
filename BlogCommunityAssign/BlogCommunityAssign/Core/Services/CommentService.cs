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

        public async Task<int?> CreateComment(CreateCommentDTO comment, int postId, int? userId)
        {
            Post? validPostId = await _postRepo.GetById(postId);
            if (validPostId == null) throw new KeyNotFoundException("Post not found.");

            if (validPostId.User?.Id == userId) throw new UnauthorizedAccessException("You cannot comment on your own post.");

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
