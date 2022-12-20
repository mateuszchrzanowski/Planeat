using Microsoft.Extensions.Caching.Memory;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Users;
using Planeat.Infrastructure.Common;
using Planeat.Infrastructure.Extensions;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Handlers.Users
{
    public class LoginUserHandler : ICommandHandler<LoginUser>
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMemoryCache _cache;

        public LoginUserHandler(IUserService userService,
            IJwtTokenGenerator jwtTokenGenerator, IMemoryCache cache)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _cache = cache;
        }

        public async Task HandleAsync(LoginUser command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            var jwtToken = _jwtTokenGenerator.GenerateToken(user.Id,
                user.FirstName,
                user.LastName,
                user.RoleId);
            _cache.SetJwtToken(command.JwtTokenId, jwtToken);
        }
    }
}
