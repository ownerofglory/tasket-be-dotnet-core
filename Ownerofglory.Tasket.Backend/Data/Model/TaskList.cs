using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ownerofglory.Tasket.Backend.Data.Model
{
    [Table("T_TASKLIST")]
    public class TaskList
    {
        [Key]
        public long? Id { get; set; }
        public string Name { get; set; }
        public long SpaceId { get; set; }

        public Space Space { get; set; }

        [JsonIgnore]
        public virtual Collection<Task> Tasks { get; set; }

        public TaskList()
        {
        }
    }
}
