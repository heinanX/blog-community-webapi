using BlogCommunityAssign.Data.DTO.Comments;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.DTO.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
            IsAdmin = user.IsAdmin;
        }
    }
}
