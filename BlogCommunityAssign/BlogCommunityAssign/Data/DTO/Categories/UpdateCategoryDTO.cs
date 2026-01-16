using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Categories
{
    public class UpdateCategoryDTO
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = "";
    }
}
