using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.DTO.Comments
{
    public class CommentSummaryDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = "";

        public CommentSummaryDTO(Comment comment)
        {
            Id = comment.Id;
            Content = comment.Content;
        }
    }
}
