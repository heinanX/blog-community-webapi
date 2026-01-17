using BlogCommunityAssign.Data.Entities;
using System.Security.Claims;

namespace BlogCommunityAssign.Core.Extensions
{
    public static class UserClaimsVerifier
    {
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return null;

            int userId = int.Parse(userIdClaim);
            return userId;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            var role = user.FindFirst(ClaimTypes.Role)?.Value;
            return role == "Admin";

        }
    }
}
