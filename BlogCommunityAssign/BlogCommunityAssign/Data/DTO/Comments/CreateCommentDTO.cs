using BlogCommunityAssign.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Comments
{
    public class CreateCommentDTO
    {
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } = "";
        
        public int UserId { get; set; }

        public int PostId { get; set; }

    }
}
