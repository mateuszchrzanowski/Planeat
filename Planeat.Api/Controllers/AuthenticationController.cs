using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Users;
using Planeat.Infrastructure.Common;
using Planeat.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Api.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;

        public AuthenticationController(ICommandDispatcher commandDispatcher, 
            IMemoryCache cache) : base(commandDispatcher)
        {
            _cache = cache;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUser command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await CommandDispatcher.DispatchAsync(command);

            return Created($"user/{command.Email}", null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //command.JwtTokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwtToken = _cache.GetJwtToken(command.JwtTokenId);

            return Ok(jwtToken);
        }
    }
}
