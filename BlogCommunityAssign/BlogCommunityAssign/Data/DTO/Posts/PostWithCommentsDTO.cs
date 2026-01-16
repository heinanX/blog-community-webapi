using BlogCommunityAssign.Data.DTO.Categories;
using BlogCommunityAssign.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Posts
{
    public class PostWithCommentsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public ICollection<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
        public ICollection<CommentDTO> Comments { get; set; } = new List<CommentDTO>();

        public PostWithCommentsDTO(Post post)
        {
            Id = post.Id;
            UserId = post.UserId;
            Title = post.Title;
            Content = post.Content;
            CreatedAt = post.CreatedAt;
            UpdatedAt = post.UpdatedAt;

            Categories = post.Categories.Select(c => new CategoryDTO(c)).ToList();
            Comments = post.Comments.Select(c => new CommentDTO(c)).ToList();
        }
    }
}
