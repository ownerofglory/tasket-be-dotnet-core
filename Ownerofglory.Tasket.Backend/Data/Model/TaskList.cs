using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Ownerofglory.Tasket.Backend.Data.Model
{
    [Table("T_TASKLIST")]
    public class TaskList
    {
        [Key]
        public long? Id { get; set; }
        public string Name { get; set; }
        [FromBody]
        public long SpaceId { get; set; }

        [JsonIgnore]
        public Space Space { get; set; }

        [NotMapped]
        public string Space_id { get; set; }

        [JsonIgnore]
        public virtual Collection<Task> Tasks { get; set; }

        public TaskList()
        {
        }
    }
}
