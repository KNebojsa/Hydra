using System.Security.Claims;

namespace Hydra.WebApi.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            var username = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return username ?? throw new Exception("Cannot get username from token");
        }
    }
}
