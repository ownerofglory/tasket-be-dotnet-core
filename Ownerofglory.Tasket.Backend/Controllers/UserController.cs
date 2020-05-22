using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ownerofglory.Tasket.Backend.Data.Service;

namespace Ownerofglory.Tasket.Backend.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("info")]
        public IActionResult GetCurrent()
        {
            var userIdStr = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var userId = long.Parse(userIdStr);

            var user = _userService.GetById(userId);
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }
    }
}
