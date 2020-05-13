using System;
using System.Collections;
using System.Collections.Generic;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Data.Service
{
    public interface ITaskService
    {
        void Create(Task task);
        IEnumerable<Task> GetAllByTaskListId(long taskListId);
        void Update(Task task);    }
}
