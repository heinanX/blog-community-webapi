namespace BlogCommunityAssign.Core.Configuration
{
    public class JwtSettings
    {
        public string Secret { get; set; } = "";
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public int Duration { get; set; }
     
    }
}
