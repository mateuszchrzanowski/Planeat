using FluentValidation;
using FluentValidation.Results;
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
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IValidator<CreateUser> _createUserValidator;
        private readonly IValidator<LoginUser> _loginUserValidator;
        private readonly IMemoryCache _cache;

        public AuthenticationController(ICommandDispatcher commandDispatcher,
            IJwtTokenGenerator jwtTokenGenerator,
            IValidator<CreateUser> validator,
            IValidator<LoginUser> loginUserValidator, IMemoryCache cache) : base(commandDispatcher)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _createUserValidator = validator;
            _loginUserValidator = loginUserValidator;
            _cache = cache;
        }

        [HttpGet("token")]
        public IActionResult GetToken()
        {
            var token = _jwtTokenGenerator.GenerateToken(
                Guid.NewGuid(), "test first name", "test last name", 1);

            return Ok(token);
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

            command.JwtTokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwtToken = _cache.GetJwtToken(command.JwtTokenId);

            return Ok(jwtToken);
        }
    }
}
