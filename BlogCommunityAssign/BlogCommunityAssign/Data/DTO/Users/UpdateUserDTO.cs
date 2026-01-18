using System.ComponentModel.DataAnnotations;

namespace BlogCommunityAssign.Data.DTO.Users
{
    public class UpdateUserDTO
    {
        [MaxLength(30)]
        public string? Username { get; set; }
        
        [MaxLength(200)]
        public string? Password { get; set; }

        [EmailAddress]
        [MaxLength(320)]
        public string? Email { get; set; }
    }
}
