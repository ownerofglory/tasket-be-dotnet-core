using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }
    }
}
