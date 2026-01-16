using BlogCommunityAssign.Data.DTO.Posts;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.DTO
{
    public class FullUserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
        public List<PostDTO> Posts { get; set; } = new List<PostDTO>();

        public FullUserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
            IsAdmin = user.IsAdmin;
            Comments = user.Comments.Select(c => new CommentDTO(c)).ToList();
            Posts = user.Posts.Select(c => new PostDTO(c)).ToList();
        }
    }
}
