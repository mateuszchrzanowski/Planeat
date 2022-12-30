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
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        private readonly IUserService _userService;

        public ChangeUserPasswordHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(ChangeUserPassword command)
        {
            await _userService.ChangePasswordAsync(
                command.UserId, command.CurrentPassword, command.NewPassword);
        }
    }
}
