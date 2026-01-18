using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Users
{
    public class LoginUserDTO
    {
        [Required]
        public string Identifier { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
