using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ownerofglory.Tasket.Backend.Data.Model;
using Ownerofglory.Tasket.Backend.Data.Service;

namespace Ownerofglory.Tasket.Backend.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskListService _taskListService;

        public TaskController(ITaskService taskService, ITaskListService taskListService)
        {
            _taskService = taskService;
            _taskListService = taskListService;
        }

        public IActionResult GetAllByTaskList(long taskListId)
        {
            var userIdStr = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var userId = long.Parse(userIdStr);

            if (!_taskListService.UserHasPermission(taskListId, userId))
                return BadRequest(new { message = "Not permitted" });

            var tasks = _taskService.GetAllByTaskListId(taskListId);

            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Task task)
        {
            var userIdStr = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var userId = long.Parse(userIdStr);

            if (!_taskListService.UserHasPermission(task.TaskListId, userId))
                return BadRequest(new { message = "Not permitted" });

            _taskService.Create(task);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Task task)
        {
            var userIdStr = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var userId = long.Parse(userIdStr);

            if (!_taskListService.UserHasPermission(task.TaskListId, userId))
                return BadRequest(new { message = "Not permitted" });

            _taskService.Update(task);

            return Ok();
        }
    }
}
