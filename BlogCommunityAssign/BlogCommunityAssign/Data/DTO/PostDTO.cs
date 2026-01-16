using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        public PostDTO(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Content = post.Content;
        }
    }
}
