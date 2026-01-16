using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO
{
    public class CreateCategoryDTO
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = "";
    }
}
