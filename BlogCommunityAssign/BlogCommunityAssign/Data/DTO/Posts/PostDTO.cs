using BlogCommunityAssign.Data.DTO.Categories;
using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.DTO.Posts
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public ICollection<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

        public PostDTO(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Content = post.Content;
            Categories = post.Categories.Select(c => new CategoryDTO(c)).ToList();
        }
    }
}
