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
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _taskListService;
        private readonly ISpaceService _spaceService;

        public TaskListController(ITaskListService taskListService, ISpaceService spaceService)
        {
            _taskListService = taskListService;
            _spaceService = spaceService;
        }

        [HttpGet]
        public IActionResult GetAll(long spaceId)
        {
            var userIdStr = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var userId = long.Parse(userIdStr);

            if (!_spaceService.UserHasPermission(spaceId, userId))
                return BadRequest(new { message = $"No permission for user with id: {userId}" });

            var taskLists = _taskListService.GetAllBySpaceId(spaceId);

            return Ok(taskLists);

        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskList taskList)
        {
            var userIdStr = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var userId = long.Parse(userIdStr);

            if (!_spaceService.UserHasPermission(taskList.SpaceId, userId))
                return BadRequest(new { message = $"No permission for user with id: {userId}" });


            _taskListService.Create(taskList);
            return Ok();
        }


    }
}
