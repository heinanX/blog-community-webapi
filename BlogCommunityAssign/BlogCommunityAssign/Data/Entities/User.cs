using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Username { get; set; } = "";
        [Required]
        [MaxLength(200)]
        public string Password { get; set; } = "";

        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; } = "";
        public bool IsAdmin { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }

}
