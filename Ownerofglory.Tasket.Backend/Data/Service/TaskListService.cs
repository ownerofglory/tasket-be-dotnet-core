using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ownerofglory.Tasket.Backend.Data.Context;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Data.Service
{
    public class TaskListService : ITaskListService
    {
        private readonly TasketMysqlDbContext _dbContext;

        public TaskListService(TasketMysqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(TaskList taskList)
        {
            _dbContext.TaskLists.Add(taskList);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TaskList> GetAllBySpaceId(long spaceId)
        {
            var taskLists = _dbContext.TaskLists.Where(tl => tl.SpaceId == spaceId);
            return taskLists.ToList();
        }

        public void Update(TaskList taskList)
        {
            throw new NotImplementedException();
        }

        public bool UserHasPermission(long id, long userId)
        {
            var taskList = _dbContext.TaskLists
                .Include(t => t.Space)
                .FirstOrDefault(tl => tl.Id == id);
            return taskList.Space.UserId == userId;
        }
    }
}
