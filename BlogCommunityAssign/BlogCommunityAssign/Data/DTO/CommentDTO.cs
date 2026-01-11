using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = "";

        public CommentDTO(Comment comment)
        {
            Id = comment.Id;
            Content = comment.Content;
        }
    }
}
