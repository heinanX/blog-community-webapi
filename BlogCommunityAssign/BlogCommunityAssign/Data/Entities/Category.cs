using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = "";

        public ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}
