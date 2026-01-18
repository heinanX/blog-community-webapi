using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.DTO.Comments
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = "";

        public string? Username { get; set; }
        public int? PostId { get; set; }


        public CommentDTO(Comment comment)
        {
            Id = comment.Id;
            Content = comment.Content;
            Username = comment.User?.Username;
            PostId = comment.Post?.Id;
        }
    }
}
