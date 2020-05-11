using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Security.Helper
{
    public static class UserListExtension
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            if (users == null)
                return null;

            return users.Select(u => u.WithoutPassword());
        }
    }
}
