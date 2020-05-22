using System;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Controllers.Binding.Dto
{
    public class TaskDto
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string TaskListId { get; set; }

        public TaskDto()
        {
        }

        public Task ToTask()
        {
            return new Task
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Status = Status,
                TaskListId = long.Parse(TaskListId)
            };
        }
    }
}
