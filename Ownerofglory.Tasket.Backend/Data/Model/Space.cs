using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ownerofglory.Tasket.Backend.Data.Model
{
    [Table("SPACE")]
    public class Space
    {
        [Key]
        public long? Id { get; set; }
        public string  Name { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }

        [JsonIgnore]
        public virtual Collection<TaskList> TaskLists { get; set; }

        public Space()
        {
        }
    }
}
