using BlogCommunityAssign.Data.DTO.Categories;
using BlogCommunityAssign.Data.DTO.Comments;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.DTO.Posts
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string? Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public ICollection<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
        public ICollection<CommentDTO> Comments { get; set; } = new List<CommentDTO>();

        public PostDTO(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Content = post.Content;
            Username = post.User?.Username != null ? Username = post.User?.Username : null;
            CreatedAt = post.CreatedAt;
            UpdatedAt = post.UpdatedAt;

            Categories = post.Categories.Select(c => new CategoryDTO(c)).ToList();
            Comments = post.Comments.Select(c => new CommentDTO(c)).ToList();

        }
    }
}
