using System;
using System.ComponentModel.DataAnnotations;

namespace Ownerofglory.Tasket.Backend.Security.Model
{
    public class UserAuthenticateModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public UserAuthenticateModel()
        {
        }
    }
}
