using Microsoft.AspNetCore.Mvc;
using Planeat.Infrastructure.DTO;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public UserDto Get(string email)
        {
            return _userService.Get(email);
        }
    }
}
