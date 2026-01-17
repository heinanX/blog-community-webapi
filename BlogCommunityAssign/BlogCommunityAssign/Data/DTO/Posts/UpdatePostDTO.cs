using BlogCommunityAssign.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Posts
{
    public class UpdatePostDTO
    {

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(6000)]
        public string? Content { get; set; }

        public ICollection<string>? Categories { get; set; }
    }
}
