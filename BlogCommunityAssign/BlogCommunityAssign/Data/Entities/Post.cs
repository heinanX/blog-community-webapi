namespace BlogCommunityAssign.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
