using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = "";

        [Required]
        [MaxLength(6000)]
        public string Content { get; set; } = "";

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
