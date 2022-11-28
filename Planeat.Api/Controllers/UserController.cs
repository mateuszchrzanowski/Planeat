using Microsoft.AspNetCore.Mvc;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Users;
using Planeat.Infrastructure.DTO;
using Planeat.Infrastructure.Services;
using Planeat.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<UserDto> users = await _userService.GetAllAsync();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            UserDto user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);
            
            return Created($"user/{command.Email}", null);
        }
    }
}
