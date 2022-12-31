using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Users;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Handlers.Users
{
    public class ChangeUserRoleHandler : ICommandHandler<ChangeUserRole>
    {
        private readonly IUserService _userService;

        public ChangeUserRoleHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(ChangeUserRole command)
        {
            await _userService.ChangeRoleAsync(command.UserId, command.RoleName);
        }
    }
}
