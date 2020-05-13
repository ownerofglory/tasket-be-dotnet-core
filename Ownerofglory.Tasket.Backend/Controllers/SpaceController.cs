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
    public class SpaceController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISpaceService _spaceService;

        public SpaceController(ISpaceService spaceService, IUserService userService)
        {
            _spaceService = spaceService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userIdStr = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var userId = long.Parse(userIdStr);


            var spaces = _spaceService.GetAllForUser(userId);

            return Ok(spaces);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Space space)
        {
            var userIdStr = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var userId = long.Parse(userIdStr);
            space.UserId = userId;

            _spaceService.Create(space);

            return Ok();
        }
    }
}
