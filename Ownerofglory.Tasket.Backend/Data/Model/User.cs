using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ownerofglory.Tasket.Backend.Data.Model
{
    [Table("USER")]
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }

        [NotMapped]
        public string Token { get; set; }

        public virtual ICollection<Space> Spaces { get; set; }
        [JsonIgnore]
        public virtual ICollection<Task> Tasks { get; set; }

        public User()
        {
            Spaces = new LinkedList<Space>();
        }
    }
}
