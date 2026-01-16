namespace BlogCommunityAssign.Data.DTO
{
    public class AuthResponseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";

        public string Token { get; set; } = "";
        public bool IsAdmin { get; set; }

        public AuthResponseDTO(int id, string username, string email, string token, bool isAdmin)
        {
            Id = id;
            Username = username;
            Email = email;
            Token = token;
            IsAdmin = isAdmin;
        }
    }
}
