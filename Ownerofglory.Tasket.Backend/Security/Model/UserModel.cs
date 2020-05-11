using System;

namespace Ownerofglory.Tasket.Backend.Security.Model
{
    public class UserModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public UserModel()
        {
        }
    }
}
