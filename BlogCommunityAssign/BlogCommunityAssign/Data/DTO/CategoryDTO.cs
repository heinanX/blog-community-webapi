
using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = "";
    }
}
