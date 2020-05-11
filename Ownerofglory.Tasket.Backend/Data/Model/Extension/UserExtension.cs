using System;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Security.Helper
{
    public static class UserExtension
    {
        public static User WithoutPassword(this User user)
        {
            if (user == null)
                return null;

            user.PasswordHash = null;
            user.PasswordSalt = null;

            return user;
        }
    }
}
