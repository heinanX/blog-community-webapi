using BlogCommunityAssign.Data.DTO.Comments;
using BlogCommunityAssign.Data.DTO.Posts;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.DTO.Users
{
    public class UserWithPostsAndCommentsDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CommentSummaryDTO> Comments { get; set; } = new List<CommentSummaryDTO>();
        public List<PostDTO> Posts { get; set; } = new List<PostDTO>();

        public UserWithPostsAndCommentsDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
            IsAdmin = user.IsAdmin;
            Comments = user.Comments.Select(c => new CommentSummaryDTO(c)).ToList();
            Posts = user.Posts.Select(c => new PostDTO(c)).ToList();
        }
    }
}
