using System;
using System.ComponentModel.DataAnnotations;

namespace Ownerofglory.Tasket.Backend.Security.Model
{
    public class UserRegisterModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public UserRegisterModel()
        {
        }
    }
}
