using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Users
{
    public class RegisterUserDTO
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; } = "";

        [Required]
        [MaxLength(200)]
        public string Password { get; set; } = "";

        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; } = "";
    }
}
