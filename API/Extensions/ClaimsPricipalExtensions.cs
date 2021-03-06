using System.Linq;
using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPricipalExtensions
    {
        public static string RetrieveEmailFromPricipal (this ClaimsPrincipal user)
        {
            return user?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}