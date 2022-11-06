using Microsoft.AspNetCore.Mvc;
using Planeat.Infrastructure.Commands.Users;
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
        public async Task<UserDto> Get(string email)
        {
            return await _userService.GetAsync(email);
        }

        [HttpPost]
        public async Task Post(CreateUser request)
        {
            await _userService.RegisterAsync(request.Email, request.Username, request.Password);
        }
    }
}
