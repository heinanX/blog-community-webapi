using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO
{
    public class LoginCredentialsDTO
    {
        [Required]
        public string Identifier { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }
}
