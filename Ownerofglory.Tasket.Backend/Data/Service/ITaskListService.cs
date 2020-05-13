using System;
using System.Collections.Generic;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Data.Service
{
    public interface ITaskListService
    {
        void Create(TaskList taskList);
        void Update(TaskList taskList);
        IEnumerable<TaskList> GetAllBySpaceId(long spaceId);
        bool UserHasPermission(long id, long userId);
    }
}
