using System;
using Ownerofglory.Tasket.Backend.Data.Model;
using Ownerofglory.Tasket.Backend.Data.Service;

namespace Ownerofglory.Tasket.Backend.Security.Helper
{
    public static class PermissionChecker
    {
        public static bool HasAdminPermission(User user)
        {
            return user.Role.Equals(Role.Admin);
        }
    }
}
