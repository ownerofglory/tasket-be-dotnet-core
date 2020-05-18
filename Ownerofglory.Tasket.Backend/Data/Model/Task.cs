using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ownerofglory.Tasket.Backend.Data.Model
{
    [Table("T_TASK")]
    public class Task
    {
        [Key]
        public long? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public long TaskListId { get; set; }

        public TaskList TaskList { get; set; }

        public Task()
        {
        }
    }
}
