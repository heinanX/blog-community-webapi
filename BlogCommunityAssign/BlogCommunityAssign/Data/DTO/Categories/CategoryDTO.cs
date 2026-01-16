using BlogCommunityAssign.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Categories
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? CategoryName { get; set; }

        public CategoryDTO(Category category)
        {
            Id = category.Id;
            CategoryName = category.CategoryName;
        }
    }
}
