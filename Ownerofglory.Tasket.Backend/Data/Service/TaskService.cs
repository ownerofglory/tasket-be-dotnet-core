using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ownerofglory.Tasket.Backend.Data.Context;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Data.Service
{
    public class TaskService : ITaskService
    {
        private readonly TasketMysqlDbContext _dbContext;

        public TaskService(TasketMysqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Task task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Task> GetAllByTaskListId(long taskListId)
        {
            var tasks = _dbContext.Tasks.Where(t => t.TaskListId == taskListId);
            return tasks.ToList();
        }

        public void Update(Task task)
        {
            var presentTask = _dbContext.Tasks.FirstOrDefault(t => t.Id == task.Id);

            if (presentTask == null)
                throw new Exception("Task doesn't exist");

            presentTask.TaskListId = task.TaskListId;
            presentTask.Title = task.Title;
            presentTask.Status = task.Status;

            _dbContext.Update(presentTask);
            _dbContext.SaveChanges();
        }
    }
}
