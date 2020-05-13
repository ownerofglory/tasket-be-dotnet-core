using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Ownerofglory.Tasket.Backend.Controllers.Extension
{
    public static class UserClaimControllerExtension
    {
        public static long GetUserIdClaim(this ControllerBase controller)
        {
            var userIdStr = controller.User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var userId = long.Parse(userIdStr);

            return userId;
        }
    }
}
