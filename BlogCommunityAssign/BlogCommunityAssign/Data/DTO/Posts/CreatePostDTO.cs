using BlogCommunityAssign.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Posts
{
    public class CreatePostDTO
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = "";

        [Required]
        [MaxLength(6000)]
        public string Content { get; set; } = "";

        public ICollection<string>? Categories { get; set; }

    }
}
