using BlogCommunityAssign.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Comments
{
    public class UpdateCommentDTO
    {
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } = "";
        public DateTime UpdatedAt { get; set; }
    }
}
