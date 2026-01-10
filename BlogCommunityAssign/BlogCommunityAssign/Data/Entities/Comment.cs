namespace BlogCommunityAssign.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; } // Navigation Property for user

        public int PostId { get; set; }
        public Post Post { get; set; } // Navigation Property for User

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
