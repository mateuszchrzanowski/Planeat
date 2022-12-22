using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Users;
using Planeat.Infrastructure.Common;
using Planeat.Infrastructure.DTO;
using Planeat.Infrastructure.Extensions;
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
        private readonly IValidator<CreateUser> _validator;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserController(IUserService userService,
            ICommandDispatcher commandDispatcher,
            IValidator<CreateUser> validator, 
            IJwtTokenGenerator jwtTokenGenerator) : base(commandDispatcher)
        {
            _userService = userService;
            _validator = validator;
            _jwtTokenGenerator = jwtTokenGenerator;
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
    }
}
